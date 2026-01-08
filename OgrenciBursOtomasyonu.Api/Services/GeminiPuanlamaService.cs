using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OgrenciBursOtomasyonu.Api.Models;

namespace OgrenciBursOtomasyonu.Api.Services
{
    public class GeminiPuanlamaService : IGeminiPuanlamaService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<GeminiPuanlamaService> _logger;
        private readonly string _apiKey;
        private static List<string>? _cachedModels = null;
        private static readonly System.Threading.SemaphoreSlim _semaphore = new System.Threading.SemaphoreSlim(1, 1);

        public GeminiPuanlamaService(
            HttpClient httpClient,
            IConfiguration configuration,
            ILogger<GeminiPuanlamaService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _apiKey = configuration["Gemini:ApiKey"]
                ?? throw new InvalidOperationException("Gemini ApiKey bulunamadı.");
        }

        // =========================================================
        // MEVCUT MODELLERİ ÖĞREN
        // =========================================================
        public async Task<List<string>> GetAvailableModelsAsync()
        {
            // Cache'den kontrol et
            if (_cachedModels != null && _cachedModels.Count > 0)
                return _cachedModels;

            // SemaphoreSlim kullan (async-friendly)
            await _semaphore.WaitAsync();
            try
            {
                // Double-check pattern
                if (_cachedModels != null && _cachedModels.Count > 0)
                    return _cachedModels;

                try
                {
                    string url = $"https://generativelanguage.googleapis.com/v1/models?key={_apiKey}";
                    _logger.LogInformation("Mevcut modeller sorgulanıyor...");

                    var response = await _httpClient.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        using var doc = JsonDocument.Parse(json);
                        var root = doc.RootElement;

                        if (root.TryGetProperty("models", out var models))
                        {
                            var modelList = new List<string>();
                            foreach (var model in models.EnumerateArray())
                            {
                                if (model.TryGetProperty("name", out var name))
                                {
                                    var modelName = name.GetString();
                                    if (!string.IsNullOrEmpty(modelName))
                                    {
                                        // "models/" prefix'ini kaldır
                                        var cleanName = modelName.Replace("models/", "");
                                        if (cleanName.Contains("gemini") && 
                                            (cleanName.Contains("flash") || cleanName.Contains("pro")))
                                        {
                                            modelList.Add(cleanName);
                                        }
                                    }
                                }
                            }
                            _cachedModels = modelList.OrderBy(m => m.Contains("pro") ? 0 : 1).ToList();
                            _logger.LogInformation("Bulunan modeller: {Models}", string.Join(", ", _cachedModels));
                            return _cachedModels;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "ListModels API çağrısı başarısız, varsayılan modeller kullanılacak");
                }

                // Fallback: Kesinlikle çalışan modeller
                _cachedModels = new List<string> 
                { 
                    "gemini-1.5-flash",
                    "gemini-1.5-pro"
                };
                return _cachedModels;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        // =========================================================
        // PUBLIC
        // =========================================================
        public async Task<(int Puan, string Rapor)> PuanHesaplaVeRaporOlusturAsync(Ogrenci ogrenci)
        {
            try
            {
                // API key kontrolü
                if (string.IsNullOrWhiteSpace(_apiKey))
                {
                    _logger.LogError("Gemini API Key bulunamadı!");
                    throw new InvalidOperationException("Gemini API Key yapılandırılmamış. Lütfen appsettings.json dosyasında 'Gemini:ApiKey' değerini kontrol edin.");
                }

                _logger.LogInformation("Gemini puanlama başlatılıyor. Öğrenci ID: {OgrenciId}", ogrenci.Id);
                
                string ogrenciMetni = BuildOgrenciMetni(ogrenci);

                // Yeni puanlama sistemi: Her kriter için ayrı puan al ve ağırlıklı ortalamayla birleştir
                int puan = await YeniPuanlamaSistemiAsync(ogrenci);
                _logger.LogInformation("Puan hesaplandı: {Puan}", puan);
                
                string rapor = await GeminiIleRaporOlusturAsync(ogrenciMetni, puan);
                _logger.LogInformation("Rapor oluşturuldu. Uzunluk: {Length}", rapor?.Length ?? 0);

                return (puan, rapor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gemini puanlama hatası. Hata mesajı: {Message}, StackTrace: {StackTrace}", 
                    ex.Message, ex.StackTrace);
                
                // Daha detaylı hata mesajı
                string hataMesaji = $"AI değerlendirmesi yapılamadı. Hata: {ex.Message}";
                if (ex.InnerException != null)
                {
                    hataMesaji += $" İç hata: {ex.InnerException.Message}";
                }
                
                throw new Exception(hataMesaji, ex);
            }
        }

        // =========================================================
        // YENİ PUANLAMA SİSTEMİ - AĞIRLIKLI ORTALAMA
        // =========================================================
        private async Task<int> YeniPuanlamaSistemiAsync(Ogrenci ogrenci)
        {
            try
            {
                // 1. Kardeş Sayısı Puanı (Kodda hesaplanıyor, AI'ya gerek yok)
                // Başlangıç: 15, Her kardeş için: +10, Max: 65
                int kardesPuan = 15 + (ogrenci.KardesSayisi * 10);
                if (kardesPuan > 65) kardesPuan = 65;
                double kardesAgirlikli = kardesPuan * 0.30; // %30 ağırlık
                _logger.LogInformation("Kardeş Sayısı: {Kardes}, Hesaplanan Puan: {Puan}, Ağırlıklı: {Agirlikli}", 
                    ogrenci.KardesSayisi, kardesPuan, kardesAgirlikli);

                // 2. AGNO, Hane Geliri ve 5 Klasik Soru için AI'dan puan al
                var aiPuanlar = await GeminiIleKriterPuanlariAlAsync(ogrenci);
                
                // 3. Ağırlıklı ortalamayı hesapla
                // AGNO: %30
                double agnoAgirlikli = aiPuanlar.AgnoPuan * 0.30;
                
                // Hane Geliri: %30
                double haneGeliriAgirlikli = aiPuanlar.HaneGeliriPuan * 0.30;
                
                // 5 Klasik Soru: Her biri %6 = Toplam %30
                double soru1Agirlikli = aiPuanlar.Soru1Puan * 0.06; // BursAlmaIhtiyaci
                double soru2Agirlikli = aiPuanlar.Soru2Puan * 0.06; // EgitimMasraflari
                double soru3Agirlikli = aiPuanlar.Soru3Puan * 0.06; // AkademikGelisim
                double soru4Agirlikli = aiPuanlar.Soru4Puan * 0.06; // ToplumaKatki
                double soru5Agirlikli = aiPuanlar.Soru5Puan * 0.06; // BesYilSonrasi

                // Toplam ağırlıklı puan
                double toplamPuan = agnoAgirlikli + haneGeliriAgirlikli + kardesAgirlikli +
                                  soru1Agirlikli + soru2Agirlikli + soru3Agirlikli + soru4Agirlikli + soru5Agirlikli;

                int hesaplananPuan = (int)Math.Round(toplamPuan);
                if (hesaplananPuan < 0) hesaplananPuan = 0;

                // Bonus sistemi: Her puan değeri için +5
                int bonusPuan = 5;

                int finalPuan = hesaplananPuan + bonusPuan;
                if (finalPuan > 100) finalPuan = 100; // Maksimum 100

                _logger.LogInformation("Final Puan Hesaplandı: AGNO({Agno})={AgnoAgirlikli:F2}, HaneGeliri({HaneGeliri})={HaneGeliriAgirlikli:F2}, " +
                    "Kardeş({KardesPuan})={KardesAgirlikli:F2}, Sorular({S1},{S2},{S3},{S4},{S5})={SorularToplam:F2}, " +
                    "Hesaplanan={Hesaplanan}, Bonus={Bonus}, TOPLAM={Final}",
                    aiPuanlar.AgnoPuan, agnoAgirlikli,
                    aiPuanlar.HaneGeliriPuan, haneGeliriAgirlikli,
                    kardesPuan, kardesAgirlikli,
                    aiPuanlar.Soru1Puan, aiPuanlar.Soru2Puan, aiPuanlar.Soru3Puan, 
                    aiPuanlar.Soru4Puan, aiPuanlar.Soru5Puan,
                    soru1Agirlikli + soru2Agirlikli + soru3Agirlikli + soru4Agirlikli + soru5Agirlikli,
                    hesaplananPuan, bonusPuan, finalPuan);

                return finalPuan;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Yeni puanlama sistemi hatası");
                return 0;
            }
        }

        // AI'dan her kriter için ayrı puan al
        private async Task<(int AgnoPuan, int HaneGeliriPuan, int Soru1Puan, int Soru2Puan, int Soru3Puan, int Soru4Puan, int Soru5Puan)> 
            GeminiIleKriterPuanlariAlAsync(Ogrenci ogrenci)
        {
            string prompt = $"""
Sen bir burs değerlendirme uzmanısın. Aşağıdaki öğrenci bilgilerini analiz edip HER KRİTER İÇİN 0-100 arası ayrı ayrı puanlar ver.

NOT: Bu puanlar daha sonra ağırlıklandırılacak:
- AGNO: %30 ağırlık
- Hane Geliri: %30 ağırlık
- Her Klasik Soru: %6 ağırlık (5 soru = toplam %30)
- Kardeş Sayısı: %10 ağırlık (sistem tarafından hesaplanacak, sen puanlama yapma)

PUANLAMA KURALLARI:

1. AGNO PUANI (0-100):
   AGNO en fazla 4.00 olabilir. 4.00'ı 100 puan olarak düşün ve ona göre orantılı puan ver.
   - 4.00 AGNO = 100 puan (mükemmel başarı)
   - 3.50-3.99 AGNO = 87-99 puan (çok iyi başarı, 4.00'a yakın)
   - 3.00-3.49 AGNO = 75-86 puan (iyi başarı)
   - 2.50-2.99 AGNO = 62-74 puan (orta başarı)
   - 2.00-2.49 AGNO = 50-61 puan (düşük başarı)
   - 2.00 altı AGNO = 0-49 puan (çok düşük başarı)
   
   ÖNEMLİ: 4.00 AGNO = 100 puan olmalı. Örneğin 3.80 AGNO ≈ 95 puan, 3.00 AGNO = 75 puan gibi.
   Öğrencinin AGNO'su: {ogrenci.Agno:F2} / 4.00

2. HANE GELİRİ PUANI (0-100):
   Ortalama aylık hane geliri: 35000 TL olarak kabul edilir.
   ÖNEMLİ: Gelir AZALDIKÇA puan ARTMALI (daha çok burs ihtiyacı var)
   
   - 0-10000 TL = 85-100 puan (çok düşük gelir, yüksek ihtiyaç)
   - 10001-20000 TL = 70-84 puan (düşük gelir, ihtiyaç var)
   - 20001-35000 TL = 50-69 puan (orta gelir, orta ihtiyaç, 35000 TL ortalama = 50 puan civarı)
   - 35001-50000 TL = 30-49 puan (orta-üst gelir, düşük ihtiyaç)
   - 50000+ TL = 0-29 puan (yüksek gelir, çok düşük ihtiyaç)
   
   Öğrencinin Hane Geliri: {ogrenci.HaneGeliri:F0} TL
   ÖNEMLİ: {ogrenci.HaneGeliri:F0} TL geliri 35000 TL ortalamasına göre değerlendir. Gelir ne kadar düşükse puan o kadar yüksek olmalı.

3-7. KLASİK SORULAR (Her biri 0-100):
   Her soru için cevabın kalitesine, detayına, samimiyetine ve hedef netliğine göre 0-100 arası puan ver:
   - Çok detaylı, samimi, hedefi net, gerçekçi, uzun ve anlamlı = 85-100 puan
   - İyi cevaplar, açıklayıcı, mantıklı, yeterli detay = 70-84 puan
   - Orta seviye cevaplar, yeterli ama eksik = 50-69 puan
   - Kısa, yetersiz, belirsiz, yüzeysel = 30-49 puan
   - Çok kısa veya boş, anlamsız = 0-29 puan

3. SORU 1 - Burs İhtiyacı:
{ogrenci.BursAlmaIhtiyaci}

4. SORU 2 - Eğitim Masrafları:
{ogrenci.EgitimMasraflari}

5. SORU 3 - Akademik Gelişim:
{ogrenci.AkademikGelisim}

6. SORU 4 - Topluma Katkı:
{ogrenci.ToplumaKatki}

7. SORU 5 - 5 Yıl Sonra:
{ogrenci.BesYilSonrasi}

ÖNEMLİ FORMAT KURALLARI:
- 7 adet puan döndürmelisin: AGNO|HaneGeliri|Soru1|Soru2|Soru3|Soru4|Soru5
- Her puan 0-100 arası tam sayı olmalı
- Puanlar arasında | (pipe) işareti kullan
- Başka hiçbir açıklama, başlık, yorum YAZMA
- Sadece şu format: sayı|sayı|sayı|sayı|sayı|sayı|sayı

ÖRNEK ÇIKTI:
85|70|90|75|80|85|90

ŞİMDİ 7 PUANI VER (Sadece format: sayı|sayı|sayı|sayı|sayı|sayı|sayı):
""";

            // Mevcut modelleri dinamik olarak al
            var models = await GetAvailableModelsAsync();
            
            if (models.Count == 0)
            {
                models = new List<string> { "gemini-1.5-flash", "gemini-1.5-pro" };
            }
            
            foreach (var modelName in models)
            {
                try
                {
                    _logger.LogInformation("Kriter puanları için model deneniyor: {Model}", modelName);
                    
                    string response = await GeminiRequestAsync(
                        prompt,
                        modelName,
                        100
                    );

                    _logger.LogInformation("Gemini yanıtı alındı: {Response}", response);

                    // Yanıtı parse et: AGNO|HaneGeliri|Soru1|Soru2|Soru3|Soru4|Soru5
                    var parts = response.Trim().Split('|');
                    if (parts.Length >= 7)
                    {
                        if (int.TryParse(parts[0].Trim(), out var agnoPuan) &&
                            int.TryParse(parts[1].Trim(), out var haneGeliriPuan) &&
                            int.TryParse(parts[2].Trim(), out var soru1Puan) &&
                            int.TryParse(parts[3].Trim(), out var soru2Puan) &&
                            int.TryParse(parts[4].Trim(), out var soru3Puan) &&
                            int.TryParse(parts[5].Trim(), out var soru4Puan) &&
                            int.TryParse(parts[6].Trim(), out var soru5Puan))
                        {
                            // Puanları 0-100 aralığına sınırla
                            agnoPuan = Math.Max(0, Math.Min(100, agnoPuan));
                            haneGeliriPuan = Math.Max(0, Math.Min(100, haneGeliriPuan));
                            soru1Puan = Math.Max(0, Math.Min(100, soru1Puan));
                            soru2Puan = Math.Max(0, Math.Min(100, soru2Puan));
                            soru3Puan = Math.Max(0, Math.Min(100, soru3Puan));
                            soru4Puan = Math.Max(0, Math.Min(100, soru4Puan));
                            soru5Puan = Math.Max(0, Math.Min(100, soru5Puan));

                            _logger.LogInformation("Kriter puanları başarıyla parse edildi: AGNO={Agno}, HaneGeliri={HaneGeliri}, " +
                                "Sorular=({S1},{S2},{S3},{S4},{S5})",
                                agnoPuan, haneGeliriPuan, soru1Puan, soru2Puan, soru3Puan, soru4Puan, soru5Puan);

                            return (agnoPuan, haneGeliriPuan, soru1Puan, soru2Puan, soru3Puan, soru4Puan, soru5Puan);
                        }
                    }

                    // Alternatif: Her satırda bir sayı olabilir
                    var lines = response.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    var numbers = new List<int>();
                    foreach (var line in lines)
                    {
                        // Satırdaki ilk 0-100 arası sayıyı bul
                        var match = Regex.Match(line, @"\b([0-9]|[1-9][0-9]|100)\b");
                        if (match.Success && int.TryParse(match.Value, out var num) && num >= 0 && num <= 100)
                        {
                            numbers.Add(num);
                        }
                    }

                    if (numbers.Count >= 7)
                    {
                        _logger.LogInformation("Kriter puanları satırlardan parse edildi");
                        return (numbers[0], numbers[1], numbers[2], numbers[3], numbers[4], numbers[5], numbers[6]);
                    }
                    else if (numbers.Count > 0)
                    {
                        _logger.LogWarning("Yeterli puan bulunamadı. Bulunan: {Count} puan. Yanıt: {Response}", numbers.Count, response);
                    }
                    else
                    {
                        _logger.LogWarning("Hiç puan bulunamadı. Yanıt: {Response}", response);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Model {Model} ile kriter puanları başarısız, bir sonraki denenecek", modelName);
                }
            }

            _logger.LogError("Tüm modeller denendi, kriter puanları alınamadı. Varsayılan değerler dönülüyor.");
            // Varsayılan değerler (0 puan)
            return (0, 0, 0, 0, 0, 0, 0);
        }

        // =========================================================
        // RAPOR
        // =========================================================
        private async Task<string> GeminiIleRaporOlusturAsync(string ogrenciMetni, int puan)
        {
            string prompt = $"""
Sen bir burs değerlendirme uzmanısın. Aşağıdaki öğrenci için DETAYLI ve KAPSAMLI bir burs değerlendirme raporu yaz. Rapor en az 250-300 kelime olmalı ve TAMAMLANMALI.

ÖNEMLİ KURALLAR:
- Markdown formatı KULLANMA (**, #, gibi işaretler kullanma)
- Başlık yazma, direkt rapor metnine başla
- Düz metin formatında yaz
- Paragraflar arasında boş satır bırak
- Türkçe karakterleri doğru kullan
- Raporu YARIDA KESME, TAMAMLA

Rapor içeriği DETAYLI olarak şunları içermeli:

1. MADDİ DURUM ANALİZİ (En az 50-60 kelime):
   - Hane geliri seviyesi ve aile ekonomik durumu
   - Kardeş sayısının maddi yüke etkisi
   - Eğitim masraflarını karşılama zorluğu
   - Burs ihtiyacının aciliyeti ve önemi

2. AKADEMİK BAŞARI DEĞERLENDİRMESİ (En az 50-60 kelime):
   - AGNO değerinin analizi ve akademik performans
   - Üniversite ve bölüm bilgisi
   - Sınıf seviyesi ve akademik ilerleme
   - Akademik hedefler ve potansiyel

3. KİŞİSEL GELİŞİM VE HEDEFLER (En az 60-70 kelime):
   - Klasik sorulara verilen cevapların detaylı analizi
   - Öğrencinin samimiyeti ve hedef netliği
   - Akademik gelişim çabaları
   - Topluma katkı potansiyeli
   - 5 yıllık hedef ve planların değerlendirmesi

4. GENEL DEĞERLENDİRME VE ÖNERİ (En az 50-60 kelime):
   - Burs uygunluğu hakkında kapsamlı görüş
   - Öğrencinin güçlü yönleri
   - İyileştirilmesi gereken alanlar (varsa)
   - Burs verilmesi durumunda beklenen faydalar
   - Sonuç ve öneri

Puan: {puan}/100

Öğrenci Bilgileri:
{ogrenciMetni}

ŞİMDİ DETAYLI RAPORU YAZ (En az 250-300 kelime, TAMAMLA):
""";

            // Mevcut modelleri dinamik olarak al
            var models = await GetAvailableModelsAsync();
            
            // Eğer hiç model yoksa, kesinlikle çalışan modelleri kullan
            if (models.Count == 0)
            {
                models = new List<string> { "gemini-1.5-flash", "gemini-1.5-pro" };
            }
            
            foreach (var modelName in models)
            {
                try
                {
                    _logger.LogInformation("Rapor oluşturma için model deneniyor: {Model}", modelName);
                    
                    // Rate limiting: Her model denemesi arasında kısa bir bekleme
                    await Task.Delay(300);
                    
                    var rapor = await GeminiRequestAsync(
                        prompt,
                        modelName,
                        1200  // Daha uzun raporlar için token limiti artırıldı
                    );

                    if (!string.IsNullOrWhiteSpace(rapor))
                    {
                        // Markdown işaretlerini temizle
                        rapor = TemizleMarkdown(rapor);
                        
                        // Raporun minimum uzunluğunu kontrol et (en az 200 kelime olmalı)
                        var kelimeSayisi = rapor.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
                        
                        if (kelimeSayisi < 150)
                        {
                            _logger.LogWarning("Rapor çok kısa ({Kelime} kelime), bir sonraki model deneniyor", kelimeSayisi);
                            continue; // Bir sonraki modeli dene
                        }
                        
                        _logger.LogInformation("Rapor başarıyla oluşturuldu. Uzunluk: {Karakter} karakter, {Kelime} kelime", rapor.Length, kelimeSayisi);
                        return rapor;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Model {Model} ile rapor oluşturma başarısız, bir sonraki denenecek. Hata: {Message}", modelName, ex.Message);
                }
            }

            _logger.LogError("Tüm modeller denendi, rapor oluşturma başarısız.");
            return "Rapor oluşturulamadı. Lütfen daha sonra tekrar deneyin.";
        }

        // =========================================================
        // GEMINI CORE - 2025 Güncel Format (Retry mekanizması ile)
        // =========================================================
        private async Task<string> GeminiRequestAsync(string prompt, string model, int maxTokens)
        {
            // Model adını düzelt (eğer "models/" prefix'i yoksa ekle)
            string modelPath = model.StartsWith("models/") ? model : $"models/{model}";
            
            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                },
                generationConfig = new
                {
                    temperature = 0.2,
                    maxOutputTokens = maxTokens
                }
            };

            // ÖNCE v1 API versiyonunu dene (2025'te daha stabil ve çalışan)
            // v1beta artık birçok model için desteklenmiyor
            string url = $"https://generativelanguage.googleapis.com/v1/{modelPath}:generateContent?key={_apiKey}";

            // API key kontrolü (URL'den önce)
            if (string.IsNullOrWhiteSpace(_apiKey))
            {
                _logger.LogError("Gemini API Key boş!");
                throw new InvalidOperationException("Gemini API Key bulunamadı. Lütfen appsettings.json dosyasında 'Gemini:ApiKey' değerini kontrol edin.");
            }

            // API key format kontrolü
            if (!_apiKey.StartsWith("AIzaSy", StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogWarning("Gemini API Key formatı beklenmeyen bir formatta. API key 'AIzaSy' ile başlamalı.");
            }

            _logger.LogInformation("Gemini API çağrısı yapılıyor. Model: {Model}, API: v1", model);

            // Rate limiting için kısa bir bekleme (her istek arasında)
            await Task.Delay(500); // 500ms bekleme

            // Retry mekanizması: 3 deneme, exponential backoff
            int maxRetries = 3;
            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    var response = await _httpClient.PostAsJsonAsync(url, requestBody);
                    var json = await response.Content.ReadAsStringAsync();

                    _logger.LogInformation("Gemini API yanıtı alındı. Status: {Status}, Body uzunluğu: {Length}", 
                        response.StatusCode, json?.Length ?? 0);

                    if (!response.IsSuccessStatusCode)
                    {
                        // API key hatası kontrolü
                        bool isApiKeyError = json.Contains("API_KEY_INVALID") || 
                                           json.Contains("API key") || 
                                           json.Contains("authentication") ||
                                           response.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                                           response.StatusCode == System.Net.HttpStatusCode.Forbidden;

                        if (isApiKeyError)
                        {
                            _logger.LogError("Gemini API Key hatası! Status: {Status}, Body: {Body}", response.StatusCode, json);
                            throw new InvalidOperationException($"Gemini API Key geçersiz veya yetkisiz. Lütfen appsettings.json dosyasındaki 'Gemini:ApiKey' değerini kontrol edin. Hata: {json}");
                        }

                        // Rate limit veya quota hatası kontrolü
                        bool isRateLimit = response.StatusCode == System.Net.HttpStatusCode.TooManyRequests ||
                                         response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable ||
                                         (json.Contains("429") || json.Contains("quota") || json.Contains("rate limit"));

                        if (isRateLimit && attempt < maxRetries)
                        {
                            // Exponential backoff: 2^attempt saniye bekle
                            int delaySeconds = (int)Math.Pow(2, attempt);
                            _logger.LogWarning(
                                "Gemini API rate limit hatası (deneme {Attempt}/{MaxRetries}). {Delay} saniye bekleniyor...",
                                attempt, maxRetries, delaySeconds
                            );
                            await Task.Delay(delaySeconds * 1000);
                            continue; // Tekrar dene
                        }

                        _logger.LogError(
                            "Gemini API HATASI (API: v1)\nStatus: {Status}\nBody: {Body}",
                            response.StatusCode,
                            json
                        );
                        throw new Exception($"Gemini API çağrısı başarısız. Status: {response.StatusCode}, Mesaj: {json}");
                    }

                    using var doc = JsonDocument.Parse(json);
                    var root = doc.RootElement;

                    // ERROR kontrolü
                    if (root.TryGetProperty("error", out var error))
                    {
                        string msg = error.TryGetProperty("message", out var m)
                            ? m.GetString()!
                            : "Gemini bilinmeyen hata";

                        // API key hatası kontrolü
                        bool isApiKeyError = msg.Contains("API_KEY_INVALID") || 
                                           msg.Contains("API key") || 
                                           msg.Contains("authentication") ||
                                           msg.Contains("permission") ||
                                           msg.Contains("403") ||
                                           msg.Contains("401") ||
                                           msg.Contains("PERMISSION_DENIED");

                        if (isApiKeyError)
                        {
                            _logger.LogError("Gemini API Key hatası! Error mesajı: {Message}, Full JSON: {Json}", msg, json);
                            throw new InvalidOperationException($"Gemini API Key geçersiz veya yetkisiz. Lütfen appsettings.json dosyasındaki 'Gemini:ApiKey' değerini kontrol edin. Hata: {msg}");
                        }

                        // Rate limit hatası ise retry yap
                        bool isRateLimit = msg.Contains("429") || msg.Contains("quota") || msg.Contains("rate limit");
                        if (isRateLimit && attempt < maxRetries)
                        {
                            int delaySeconds = (int)Math.Pow(2, attempt);
                            _logger.LogWarning(
                                "Gemini API rate limit hatası (deneme {Attempt}/{MaxRetries}). {Delay} saniye bekleniyor...",
                                attempt, maxRetries, delaySeconds
                            );
                            await Task.Delay(delaySeconds * 1000);
                            continue; // Tekrar dene
                        }

                        _logger.LogError("Gemini API Error (API: v1): {Message}, Full JSON: {Json}", msg, json);
                        throw new Exception($"Gemini API Error: {msg}");
                    }

                    // candidates yoksa
                    if (!root.TryGetProperty("candidates", out var candidates) ||
                        candidates.GetArrayLength() == 0)
                    {
                        _logger.LogError("Gemini boş cevap döndü (API: v1). JSON: {Json}", json);
                        throw new Exception("Gemini boş cevap döndü.");
                    }

                    var candidate = candidates[0];

                    // NORMAL YOL - content.parts.text
                    if (candidate.TryGetProperty("content", out var content) &&
                        content.TryGetProperty("parts", out var parts))
                    {
                        foreach (var part in parts.EnumerateArray())
                        {
                            if (part.TryGetProperty("text", out var text))
                            {
                                var result = text.GetString();
                                if (!string.IsNullOrWhiteSpace(result))
                                {
                                    _logger.LogInformation("Gemini başarılı yanıt alındı (API: v1). Uzunluk: {Length}", result.Length);
                                    return result.Trim();
                                }
                            }
                        }
                }

                    // FALLBACK - output_text (bazı modeller için)
                    if (candidate.TryGetProperty("output_text", out var output))
                    {
                        var result = output.GetString();
                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            _logger.LogInformation("Gemini fallback yanıt alındı (API: v1). Uzunluk: {Length}", result.Length);
                            return result.Trim();
                        }
                    }

                    _logger.LogError("Gemini geçerli metin döndürmedi (API: v1). JSON: {Json}", json);
                    throw new Exception("Gemini geçerli metin döndürmedi.");
                }
                catch (Exception ex) when (attempt < maxRetries)
                {
                    // Rate limit veya geçici hatalar için retry yap
                    bool isRetryable = ex.Message.Contains("429") || 
                                     ex.Message.Contains("quota") || 
                                     ex.Message.Contains("rate limit") ||
                                     ex.Message.Contains("timeout") ||
                                     ex is System.Net.Http.HttpRequestException;

                    if (isRetryable)
                    {
                        int delaySeconds = (int)Math.Pow(2, attempt);
                        _logger.LogWarning(
                            ex,
                            "Gemini API hatası (deneme {Attempt}/{MaxRetries}). {Delay} saniye bekleniyor... Hata: {Message}",
                            attempt, maxRetries, delaySeconds, ex.Message
                        );
                        await Task.Delay(delaySeconds * 1000);
                        continue; // Tekrar dene
                    }
                    
                    // Retry edilemeyen hata, yukarı fırlat
                    _logger.LogError(ex, "Gemini API çağrısı başarısız oldu (retry edilemez). Model: {Model}", model);
                    throw;
                }
            }

            // Tüm denemeler başarısız oldu
            _logger.LogError("Gemini API çağrısı {MaxRetries} denemede başarısız oldu. Model: {Model}", maxRetries, model);
            throw new Exception($"Gemini API çağrısı {maxRetries} denemede başarısız oldu.");
        }

        // =========================================================
        // HELPER
        // =========================================================
        private static string BuildOgrenciMetni(Ogrenci o)
        {
            return $"""
AGNO: {o.Agno:F2} / 4.00
Hane Geliri: {o.HaneGeliri:F0} TL
Kardeş Sayısı: {o.KardesSayisi}

Burs İhtiyacı:
{o.BursAlmaIhtiyaci}

Eğitim Masrafları:
{o.EgitimMasraflari}

Akademik Gelişim:
{o.AkademikGelisim}

Topluma Katkı:
{o.ToplumaKatki}

5 Yıl Sonra:
{o.BesYilSonrasi}
""";
        }

        // =========================================================
        // MARKDOWN TEMİZLEME
        // =========================================================
        private static string TemizleMarkdown(string metin)
        {
            if (string.IsNullOrWhiteSpace(metin))
                return metin;

            // Markdown işaretlerini temizle
            metin = metin.Replace("**", "");           // Kalın yazı
            metin = metin.Replace("*", "");            // İtalik
            metin = metin.Replace("####", "");        // Alt-alt-alt başlık (önce uzun olanı)
            metin = metin.Replace("###", "");         // Alt-alt başlık
            metin = metin.Replace("##", "");          // Alt başlık
            metin = metin.Replace("#", "");           // Başlık
            metin = metin.Replace("___", "");         // Alt çizgi
            metin = metin.Replace("__", "");          // Alt çizgi
            metin = metin.Replace("~~", "");          // Üstü çizili
            metin = metin.Replace("```", "");         // Kod bloğu (önce uzun olanı)
            metin = metin.Replace("`", "");          // Kod bloğu
            metin = metin.Replace("[", "");          // Link başlangıcı
            metin = metin.Replace("]", "");          // Link sonu
            metin = metin.Replace("(", "");          // Link URL başlangıcı
            metin = metin.Replace(")", "");          // Link URL sonu

            // Satır içindeki fazla boşlukları temizle (ama paragraflar arası boş satırları koru)
            var satirlar = metin.Split(new[] { '\n', '\r' }, StringSplitOptions.None);
            var temizSatirlar = new List<string>();
            
            foreach (var satir in satirlar)
            {
                // Satır içindeki fazla boşlukları temizle
                var temizSatir = Regex.Replace(satir.Trim(), @"\s+", " ");
                if (!string.IsNullOrWhiteSpace(temizSatir) || temizSatirlar.Count == 0 || !string.IsNullOrWhiteSpace(temizSatirlar[temizSatirlar.Count - 1]))
                {
                    temizSatirlar.Add(temizSatir);
                }
            }
            
            metin = string.Join("\n", temizSatirlar);
            
            // Satır başındaki ve sonundaki boşlukları temizle
            metin = metin.Trim();

            return metin;
        }
    }
}
