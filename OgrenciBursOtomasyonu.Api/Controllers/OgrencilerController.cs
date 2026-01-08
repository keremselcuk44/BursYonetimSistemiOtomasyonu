using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OgrenciBursOtomasyonu.Api.Data;
using OgrenciBursOtomasyonu.Api.Models;
using OgrenciBursOtomasyonu.Api.Services;

namespace OgrenciBursOtomasyonu.Api.Controllers
{
    /// <summary>
    /// Öğrenci başvurularını yöneten Web API controller'ı.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OgrencilerController : ControllerBase
    {
        private readonly IOgrenciService _ogrenciService;
        private readonly OgrenciBursRepository _ogrenciBursRepository;
        private readonly BursOdemeTakipRepository _odemeTakipRepository;

        private readonly BursRepository _bursRepository;

        public OgrencilerController(IOgrenciService ogrenciService, OgrenciBursRepository ogrenciBursRepository, BursOdemeTakipRepository odemeTakipRepository, BursRepository bursRepository)
        {
            _ogrenciService = ogrenciService;
            _ogrenciBursRepository = ogrenciBursRepository;
            _odemeTakipRepository = odemeTakipRepository;
            _bursRepository = bursRepository;
        }

        /// <summary>
        /// Yeni öğrenci burs başvurusu alır, Gemini ile puanlar ve sonucu döndürür.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Ogrenci>> BasvuruYap([FromBody] Ogrenci ogrenci)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var sonuc = await _ogrenciService.BasvuruOlusturAsync(ogrenci);
                return Ok(sonuc);
            }
            catch (Exception ex)
            {
                // Gemini API hatası veya diğer hatalar için detaylı mesaj döndür
                return StatusCode(500, new { 
                    message = $"Başvuru işlemi sırasında hata oluştu: {ex.Message}",
                    detail = ex.ToString(),
                    innerException = ex.InnerException?.Message
                });
            }
        }

        /// <summary>
        /// Tüm öğrencileri listeler (masaüstü veya yönetici ekranları için kullanılabilir).
        /// Burs durumlarını da içerir.
        /// </summary>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var ogrenciler = _ogrenciService.TumOgrencileriGetir();
                var eslestirmeler = _ogrenciBursRepository.TumEslestirmeleriGetir();

                // Her öğrenci için burs durumunu kontrol et
                var sonuc = ogrenciler.Select(ogrenci =>
                {
                    var eslestirme = eslestirmeler.FirstOrDefault(ob => ob.OgrenciId == ogrenci.Id && ob.Onaylandi);
                    return new OgrenciListeDto
                    {
                        Id = ogrenci.Id,
                        TcKimlikNo = ogrenci.TcKimlikNo,
                        Ad = ogrenci.Ad,
                        Soyad = ogrenci.Soyad,
                        Email = ogrenci.Email,
                        Yas = ogrenci.Yas,
                        Puan = ogrenci.Puan,
                        BursDurumu = eslestirme != null ? "Burs alıyor" : "Burs almıyor",
                        BursAdi = eslestirme?.Burs?.BursAdi ?? string.Empty
                    };
                }).ToList();

                return Ok(sonuc);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Sunucu hatası: {ex.Message}", detail = ex.ToString() });
            }
        }

        /// <summary>
        /// Belirli bir öğrencinin detaylarını getirir (AI raporu dahil).
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var ogrenci = _ogrenciService.Getir(id);
            if (ogrenci == null)
                return NotFound();

            return Ok(ogrenci);
        }

        /// <summary>
        /// Öğrencinin genel bilgilerini günceller (puanlama alanlarına dokunmadan).
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] OgrenciGuncelleDto dto)
        {
            var guncellenen = await _ogrenciService.GuncelleGenelBilgilerAsync(id, dto);
            if (guncellenen == null)
                return NotFound();

            return Ok(guncellenen);
        }

        /// <summary>
        /// Öğrenciyi ve tüm ilişkili kayıtlarını (BursOdemeTakip, OgrenciBurs) siler.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var silindi = await _ogrenciService.SilAsync(id);
            if (!silindi)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// TC Kimlik No veya Email ile öğrenci bilgilerini ve burs durumunu getirir (Web sayfası için).
        /// </summary>
        [HttpGet("sorgula")]
        public ActionResult Sorgula([FromQuery] string? tcKimlikNo, [FromQuery] string? email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tcKimlikNo) && string.IsNullOrWhiteSpace(email))
                    return BadRequest(new { message = "TC Kimlik No veya Email adresi gerekli." });

                var ogrenci = _ogrenciService.TcVeyaEmailIleGetir(tcKimlikNo?.Trim(), email?.Trim());
                if (ogrenci == null)
                    return NotFound(new { message = "Öğrenci bulunamadı." });

                // Öğrencinin burs durumunu kontrol et
                var ogrenciBurs = _ogrenciBursRepository.OgrenciyeGoreGetir(ogrenci.Id);
                
                // Burs varsa ödeme takip bilgilerini de getir
                decimal toplamOdenen = 0;
                if (ogrenciBurs != null)
                {
                    toplamOdenen = _odemeTakipRepository.ToplamOdenenTutar(ogrenciBurs.Id);
                }

                return Ok(new
                {
                    ogrenci = new
                    {
                        ogrenci.Id,
                        ogrenci.TcKimlikNo,
                        ogrenci.Ad,
                        ogrenci.Soyad,
                        ogrenci.Email,
                        ogrenci.Telefon,
                        ogrenci.Yas,
                        ogrenci.Universite,
                        ogrenci.Bolum,
                        ogrenci.Sinif,
                        ogrenci.Agno,
                        ogrenci.Puan
                    },
                    bursDurumu = ogrenciBurs != null ? new
                    {
                        bursAdi = ogrenciBurs.Burs?.BursAdi ?? string.Empty,
                        bursTipi = ogrenciBurs.Burs?.BursTipi ?? string.Empty,
                        aylikTutar = ogrenciBurs.Burs?.AylikTutar ?? 0,
                        odemePeriyodu = ogrenciBurs.Burs?.OdemePeriyodu ?? string.Empty,
                        aciklama = ogrenciBurs.Burs?.Aciklama ?? string.Empty,
                        kosullar = ogrenciBurs.Burs?.Kosullar ?? string.Empty,
                        baslangicTarihi = ogrenciBurs.Burs?.BaslangicTarihi,
                        bitisTarihi = ogrenciBurs.Burs?.BitisTarihi,
                        toplamOdenenTutar = toplamOdenen
                    } : null,
                    bursVarMi = ogrenciBurs != null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Sunucu hatası: {ex.Message}", detail = ex.ToString() });
            }
        }

        /// <summary>
        /// Dashboard için istatistikleri getirir (toplam öğrenci sayısı, bursiyer sayısı, toplam burs sayısı, ödeme bilgileri).
        /// </summary>
        [HttpGet("istatistikler")]
        public ActionResult GetIstatistikler()
        {
            try
            {
                var toplamOgrenci = _ogrenciService.TumOgrencileriGetir().Count;
                var eslestirmeler = _ogrenciBursRepository.TumEslestirmeleriGetir();
                var bursiyerSayisi = eslestirmeler.Count(ob => ob.Onaylandi);
                var toplamBurs = _bursRepository.TumBurslariGetir().Count;

                // Toplam ödenen tutarı hesapla
                decimal toplamOdeme = 0;
                int bekleyenOdeme = 0;
                
                foreach (var eslestirme in eslestirmeler.Where(ob => ob.Onaylandi))
                {
                    var odemeTakipleri = _odemeTakipRepository.OgrenciBursaGoreGetir(eslestirme.Id);
                    var odenenSayisi = odemeTakipleri.Count(ot => ot.OdendiMi);
                    var bekleyenSayisi = odemeTakipleri.Count(ot => !ot.OdendiMi);
                    
                    if (eslestirme.Burs != null)
                    {
                        toplamOdeme += odenenSayisi * eslestirme.Burs.AylikTutar;
                        bekleyenOdeme += bekleyenSayisi;
                    }
                }

                return Ok(new
                {
                    toplamOgrenci,
                    bursiyerSayisi,
                    toplamBurs,
                    toplamOdeme,
                    bekleyenOdeme
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Sunucu hatası: {ex.Message}", detail = ex.ToString() });
            }
        }

        /// <summary>
        /// Son eklenen öğrencileri getirir (dashboard için).
        /// </summary>
        [HttpGet("son-eklenen")]
        public ActionResult GetSonEklenenler([FromQuery] int adet = 10)
        {
            try
            {
                var ogrenciler = _ogrenciService.TumOgrencileriGetir();
                var eslestirmeler = _ogrenciBursRepository.TumEslestirmeleriGetir();

                // ID'ye göre sırala (en yeni en üstte) ve ilk N tanesini al
                var sonEklenenler = ogrenciler
                    .OrderByDescending(o => o.Id)
                    .Take(adet)
                    .Select(ogrenci =>
                    {
                        var eslestirme = eslestirmeler.FirstOrDefault(ob => ob.OgrenciId == ogrenci.Id && ob.Onaylandi);
                        return new OgrenciListeDto
                        {
                            Id = ogrenci.Id,
                            TcKimlikNo = ogrenci.TcKimlikNo,
                            Ad = ogrenci.Ad,
                            Soyad = ogrenci.Soyad,
                            Email = ogrenci.Email,
                            Yas = ogrenci.Yas,
                            Puan = ogrenci.Puan,
                            BursDurumu = eslestirme != null ? "Burs alıyor" : "Burs almıyor",
                            BursAdi = eslestirme?.Burs?.BursAdi ?? string.Empty
                        };
                    }).ToList();

                return Ok(sonEklenenler);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Sunucu hatası: {ex.Message}", detail = ex.ToString() });
            }
        }

        /// <summary>
        /// Puan dağılımını getirir (dashboard için).
        /// </summary>
        [HttpGet("puan-dagilimi")]
        public ActionResult GetPuanDagilimi()
        {
            try
            {
                var ogrenciler = _ogrenciService.TumOgrencileriGetir();
                
                // Puan aralıklarına göre grupla
                var dagilim = new[]
                {
                    new { Aralik = "0-20", Alt = 0, Ust = 20, Sayi = 0 },
                    new { Aralik = "21-40", Alt = 21, Ust = 40, Sayi = 0 },
                    new { Aralik = "41-60", Alt = 41, Ust = 60, Sayi = 0 },
                    new { Aralik = "61-80", Alt = 61, Ust = 80, Sayi = 0 },
                    new { Aralik = "81-100", Alt = 81, Ust = 100, Sayi = 0 }
                }.Select(aralik => new
                {
                    aralik.Aralik,
                    Sayi = ogrenciler.Count(o => o.Puan >= aralik.Alt && o.Puan <= aralik.Ust)
                }).ToList();

                return Ok(dagilim);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Sunucu hatası: {ex.Message}", detail = ex.ToString() });
            }
        }

        /// <summary>
        /// Aylık ödeme trendini getirir (dashboard için).
        /// </summary>
        [HttpGet("aylik-odeme-trendi")]
        public ActionResult GetAylikOdemeTrendi([FromQuery] int aySayisi = 6)
        {
            try
            {
                var eslestirmeler = _ogrenciBursRepository.TumEslestirmeleriGetir()
                    .Where(ob => ob.Onaylandi)
                    .ToList();

                var trend = new List<object>();
                var bugun = DateTime.Now;
                
                for (int i = aySayisi - 1; i >= 0; i--)
                {
                    var tarih = bugun.AddMonths(-i);
                    var ay = tarih.Month;
                    var yil = tarih.Year;
                    var ayAdi = new System.Globalization.CultureInfo("tr-TR").DateTimeFormat.GetMonthName(ay);
                    
                    decimal toplamTutar = 0;
                    int odemeSayisi = 0;
                    
                    foreach (var eslestirme in eslestirmeler)
                    {
                        if (eslestirme.Burs == null) continue;
                        
                        var odemeTakip = _odemeTakipRepository.Getir(eslestirme.Id, ay, yil);
                        if (odemeTakip != null && odemeTakip.OdendiMi)
                        {
                            toplamTutar += eslestirme.Burs.AylikTutar;
                            odemeSayisi++;
                        }
                    }
                    
                    trend.Add(new
                    {
                        Ay = ayAdi,
                        Yil = yil,
                        ToplamTutar = toplamTutar,
                        OdemeSayisi = odemeSayisi
                    });
                }

                return Ok(trend);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Sunucu hatası: {ex.Message}", detail = ex.ToString() });
            }
        }

        /// <summary>
        /// Gemini API bağlantısını test eder (sadece test amaçlı).
        /// </summary>
        [HttpGet("test-gemini")]
        public async Task<ActionResult> TestGemini()
        {
            try
            {
                // Basit bir test prompt'u ile Gemini API'yi test et
                var testPrompt = "Merhaba, bu bir test mesajıdır. Lütfen 'Test başarılı' yazın.";
                
                // GeminiPuanlamaService'i kullanarak test yap
                // Not: Bu endpoint sadece geliştirme amaçlıdır
                return Ok(new { 
                    message = "Gemini API test endpoint'i. Gerçek test için bir öğrenci başvurusu yapın.",
                    note = "API key kontrolü için appsettings.json dosyasını kontrol edin."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Test hatası: {ex.Message}", detail = ex.ToString() });
            }
        }
    }
}




