using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OgrenciBursOtomasyonu.Api.Models;

namespace OgrenciBursOtomasyonu.Api.Services
{
    public class GeminiMailService : IGeminiMailService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<GeminiMailService> _logger;
        private readonly string _apiKey;

        public GeminiMailService(
            HttpClient httpClient,
            IConfiguration configuration,
            ILogger<GeminiMailService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _apiKey = configuration["Gemini:ApiKey"]
                ?? throw new InvalidOperationException("Gemini ApiKey bulunamadı.");
        }

        public async Task<(string Konu, string Icerik)> BursAtamaMailIcerigiOlusturAsync(Ogrenci ogrenci, Burs burs)
        {
            try
            {
                string prompt = $"""
Sen bir burs yönetim sistemi için profesyonel ve samimi bir mail içeriği oluştur.

ÖĞRENCİ BİLGİLERİ:
- Ad Soyad: {ogrenci.Ad} {ogrenci.Soyad}
- Üniversite: {ogrenci.Universite}
- Bölüm: {ogrenci.Bolum}
- Sınıf: {ogrenci.Sinif}

BURS BİLGİLERİ:
- Burs Adı: {burs.BursAdi}
- Aylık Tutar: {burs.AylikTutar:F2} TL

ÖNEMLİ KURALLAR:
- Mail samimi ama profesyonel olmalı
- Türkçe karakterleri doğru kullan
- Öğrenciyi tebrik et
- Burs detaylarını açıkça belirt
- İletişim için bilgi ver
- Markdown formatı KULLANMA (**, #, gibi işaretler kullanma)
- HTML formatında yaz (basit HTML etiketleri kullanabilirsin: <p>, <br>, <strong>, <ul>, <li>)

Mail içeriği şu bölümleri içermeli:
1. Tebrik ve hoş geldin mesajı
2. Burs bilgileri (adı ve aylık tutarı)
3. Bursun önemi ve öğrencinin başarısı hakkında kısa bir değerlendirme
4. İletişim bilgileri ve sorular için yönlendirme
5. İyi dilekler

ŞİMDİ MAİLİ ŞU FORMATTA DÖNDÜR:
KONU: [Mail konusu buraya]
İÇERİK: [Mail içeriği buraya - HTML formatında]

ÖRNEK FORMAT:
KONU: Burs Başvurunuz Onaylandı - {burs.BursAdi}
İÇERİK: <p>Sayın {ogrenci.Ad} {ogrenci.Soyad},</p>...

ŞİMDİ MAİLİ OLUŞTUR:
""";

                string response = await GeminiRequestAsync(prompt, "gemini-1.5-flash", 800);

                // Yanıttan konu ve içeriği ayır
                var (konu, icerik) = ParseMailResponse(response, ogrenci, burs);

                return (konu, icerik);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gemini mail içeriği oluşturma hatası");
                
                // Fallback: Basit bir mail içeriği döndür
                string fallbackKonu = $"Burs Başvurunuz Onaylandı - {burs.BursAdi}";
                string fallbackIcerik = $@"
<p>Sayın {ogrenci.Ad} {ogrenci.Soyad},</p>

<p>Burs başvurunuz değerlendirilmiş ve <strong>{burs.BursAdi}</strong> bursuna hak kazandığınızı bildirmekten mutluluk duyarız.</p>

<p><strong>Burs Detayları:</strong></p>
<ul>
    <li>Burs Adı: {burs.BursAdi}</li>
    <li>Aylık Tutar: {burs.AylikTutar:F2} TL</li>
</ul>

<p>Başarılarınızın devamını dileriz.</p>

<p>Saygılarımızla,<br>
Burs Yönetim Sistemi</p>
";

                return (fallbackKonu, fallbackIcerik);
            }
        }

        public async Task<(string Konu, string Icerik)> BursCikarmaMailIcerigiOlusturAsync(Ogrenci ogrenci, Burs burs)
        {
            try
            {
                string prompt = $"""
Sen bir burs yönetim sistemi için profesyonel ve nazik bir mail içeriği oluştur.

ÖĞRENCİ BİLGİLERİ:
- Ad Soyad: {ogrenci.Ad} {ogrenci.Soyad}
- Üniversite: {ogrenci.Universite}
- Bölüm: {ogrenci.Bolum}
- Sınıf: {ogrenci.Sinif}

BURS BİLGİLERİ:
- Burs Adı: {burs.BursAdi}
- Aylık Tutar: {burs.AylikTutar:F2} TL

ÖNEMLİ KURALLAR:
- Mail nazik, saygılı ve profesyonel olmalı
- Türkçe karakterleri doğru kullan
- Öğrenciyi üzmemeli ama durumu açıkça belirtmeli
- Burs programından çıkarıldığı bilgisini net bir şekilde ilet
- Gelecekteki başvurular için umut verici olmalı
- Markdown formatı KULLANMA (**, #, gibi işaretler kullanma)
- HTML formatında yaz (basit HTML etiketleri kullanabilirsin: <p>, <br>, <strong>, <ul>, <li>)

Mail içeriği şu bölümleri içermeli:
1. Saygılı bir giriş ve durum bildirimi
2. Burs programından çıkarıldığı bilgisi
3. Çıkarılma nedeni hakkında genel bir açıklama (detay vermeden)
4. Gelecekteki başvurular için teşvik edici mesaj
5. İletişim bilgileri ve sorular için yönlendirme
6. İyi dilekler

ŞİMDİ MAİLİ ŞU FORMATTA DÖNDÜR:
KONU: [Mail konusu buraya]
İÇERİK: [Mail içeriği buraya - HTML formatında]

ÖRNEK FORMAT:
KONU: Burs Programından Çıkarılma - {burs.BursAdi}
İÇERİK: <p>Sayın {ogrenci.Ad} {ogrenci.Soyad},</p>...

ŞİMDİ MAİLİ OLUŞTUR:
""";

                string response = await GeminiRequestAsync(prompt, "gemini-1.5-flash", 800);

                // Yanıttan konu ve içeriği ayır
                var (konu, icerik) = ParseMailResponseCikarma(response, ogrenci, burs);

                return (konu, icerik);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gemini burs çıkarma mail içeriği oluşturma hatası");
                
                // Fallback: Basit bir mail içeriği döndür
                string fallbackKonu = $"Burs Programından Çıkarılma - {burs.BursAdi}";
                string fallbackIcerik = $@"
<p>Sayın {ogrenci.Ad} {ogrenci.Soyad},</p>

<p><strong>{burs.BursAdi}</strong> burs programından çıkarıldığınızı bildirmek isteriz.</p>

<p>Bu karar, burs yönetim politikaları ve mevcut durum değerlendirmesi doğrultusunda alınmıştır.</p>

<p>Gelecekteki başvurularınız için başarılar dileriz.</p>

<p>Herhangi bir sorunuz olursa lütfen bizimle iletişime geçmekten çekinmeyin.</p>

<p>Saygılarımızla,<br>
Burs Yönetim Sistemi</p>
";

                return (fallbackKonu, fallbackIcerik);
            }
        }

        private (string Konu, string Icerik) ParseMailResponse(string response, Ogrenci ogrenci, Burs burs)
        {
            try
            {
                // KONU: ve İÇERİK: etiketlerini ara
                var lines = response.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                string konu = $"Burs Başvurunuz Onaylandı - {burs.BursAdi}";
                string icerik = string.Empty;
                bool icerikBasladi = false;

                foreach (var line in lines)
                {
                    var trimmedLine = line.Trim();
                    
                    if (trimmedLine.StartsWith("KONU:", StringComparison.OrdinalIgnoreCase))
                    {
                        konu = trimmedLine.Substring(5).Trim();
                        if (konu.StartsWith(":"))
                            konu = konu.Substring(1).Trim();
                    }
                    else if (trimmedLine.StartsWith("İÇERİK:", StringComparison.OrdinalIgnoreCase) || 
                             trimmedLine.StartsWith("ICERIK:", StringComparison.OrdinalIgnoreCase))
                    {
                        icerikBasladi = true;
                        var icerikBaslangic = trimmedLine.IndexOf(":") + 1;
                        if (icerikBaslangic < trimmedLine.Length)
                        {
                            icerik += trimmedLine.Substring(icerikBaslangic).Trim() + "\n";
                        }
                    }
                    else if (icerikBasladi)
                    {
                        icerik += trimmedLine + "\n";
                    }
                }

                // Eğer içerik bulunamadıysa, tüm yanıtı içerik olarak kullan
                if (string.IsNullOrWhiteSpace(icerik))
                {
                    icerik = response.Trim();
                }

                // HTML formatını kontrol et ve düzelt
                if (!icerik.Contains("<p>") && !icerik.Contains("<div>"))
                {
                    // HTML formatına çevir
                    var paragraflar = icerik.Split(new[] { "\n\n", "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    icerik = string.Join("\n", paragraflar.Select(p => $"<p>{p.Trim()}</p>"));
                }

                return (konu, icerik.Trim());
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Mail yanıtı parse edilemedi, fallback kullanılıyor");
                
                string fallbackKonu = $"Burs Başvurunuz Onaylandı - {burs.BursAdi}";
                string fallbackIcerik = $@"
<p>Sayın {ogrenci.Ad} {ogrenci.Soyad},</p>
<p>Burs başvurunuz onaylanmıştır. <strong>{burs.BursAdi}</strong> bursuna hak kazandınız.</p>
<p>Aylık tutar: {burs.AylikTutar:F2} TL</p>
<p>Başarılarınızın devamını dileriz.</p>
";

                return (fallbackKonu, fallbackIcerik);
            }
        }

        private (string Konu, string Icerik) ParseMailResponseCikarma(string response, Ogrenci ogrenci, Burs burs)
        {
            try
            {
                // KONU: ve İÇERİK: etiketlerini ara
                var lines = response.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                string konu = $"Burs Programından Çıkarılma - {burs.BursAdi}";
                string icerik = string.Empty;
                bool icerikBasladi = false;

                foreach (var line in lines)
                {
                    var trimmedLine = line.Trim();
                    
                    if (trimmedLine.StartsWith("KONU:", StringComparison.OrdinalIgnoreCase))
                    {
                        konu = trimmedLine.Substring(5).Trim();
                        if (konu.StartsWith(":"))
                            konu = konu.Substring(1).Trim();
                    }
                    else if (trimmedLine.StartsWith("İÇERİK:", StringComparison.OrdinalIgnoreCase) || 
                             trimmedLine.StartsWith("ICERIK:", StringComparison.OrdinalIgnoreCase))
                    {
                        icerikBasladi = true;
                        var icerikBaslangic = trimmedLine.IndexOf(":") + 1;
                        if (icerikBaslangic < trimmedLine.Length)
                        {
                            icerik += trimmedLine.Substring(icerikBaslangic).Trim() + "\n";
                        }
                    }
                    else if (icerikBasladi)
                    {
                        icerik += trimmedLine + "\n";
                    }
                }

                // Eğer içerik bulunamadıysa, tüm yanıtı içerik olarak kullan
                if (string.IsNullOrWhiteSpace(icerik))
                {
                    icerik = response.Trim();
                }

                // HTML formatını kontrol et ve düzelt
                if (!icerik.Contains("<p>") && !icerik.Contains("<div>"))
                {
                    // HTML formatına çevir
                    var paragraflar = icerik.Split(new[] { "\n\n", "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    icerik = string.Join("\n", paragraflar.Select(p => $"<p>{p.Trim()}</p>"));
                }

                return (konu, icerik.Trim());
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Burs çıkarma mail yanıtı parse edilemedi, fallback kullanılıyor");
                
                string fallbackKonu = $"Burs Programından Çıkarılma - {burs.BursAdi}";
                string fallbackIcerik = $@"
<p>Sayın {ogrenci.Ad} {ogrenci.Soyad},</p>
<p><strong>{burs.BursAdi}</strong> burs programından çıkarıldığınızı bildirmek isteriz.</p>
<p>Gelecekteki başvurularınız için başarılar dileriz.</p>
";

                return (fallbackKonu, fallbackIcerik);
            }
        }

        private async Task<string> GeminiRequestAsync(string prompt, string model, int maxTokens)
        {
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
                    temperature = 0.7,
                    maxOutputTokens = maxTokens
                }
            };

            string url = $"https://generativelanguage.googleapis.com/v1/{modelPath}:generateContent?key={_apiKey}";

            _logger.LogInformation("Gemini mail içeriği için API çağrısı yapılıyor. Model: {Model}", model);

            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, requestBody);
                var json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Gemini API hatası. Status: {Status}, Body: {Body}", response.StatusCode, json);
                    throw new Exception($"Gemini API çağrısı başarısız. Status: {response.StatusCode}");
                }

                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                if (root.TryGetProperty("error", out var error))
                {
                    string msg = error.TryGetProperty("message", out var m) ? m.GetString()! : "Gemini bilinmeyen hata";
                    _logger.LogError("Gemini API Error: {Message}", msg);
                    throw new Exception($"Gemini API Error: {msg}");
                }

                if (!root.TryGetProperty("candidates", out var candidates) || candidates.GetArrayLength() == 0)
                {
                    _logger.LogError("Gemini boş cevap döndü. JSON: {Json}", json);
                    throw new Exception("Gemini boş cevap döndü.");
                }

                var candidate = candidates[0];

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
                                _logger.LogInformation("Gemini mail içeriği başarıyla alındı. Uzunluk: {Length}", result.Length);
                                return result.Trim();
                            }
                        }
                    }
                }

                throw new Exception("Gemini geçerli metin döndürmedi.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gemini API çağrısı başarısız oldu. Model: {Model}", model);
                throw;
            }
        }
    }
}

