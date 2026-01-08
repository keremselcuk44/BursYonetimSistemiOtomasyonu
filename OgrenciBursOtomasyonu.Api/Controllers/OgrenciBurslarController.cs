using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OgrenciBursOtomasyonu.Api.Data;
using OgrenciBursOtomasyonu.Api.Models;
using OgrenciBursOtomasyonu.Api.Services;

namespace OgrenciBursOtomasyonu.Api.Controllers
{
    /// <summary>
    /// Öğrenci-Burs eşleştirmelerini yöneten Web API controller'ı.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OgrenciBurslarController : ControllerBase
    {
        private readonly OgrenciBursRepository _ogrenciBursRepository;
        private readonly OgrenciRepository _ogrenciRepository;
        private readonly BursRepository _bursRepository;
        private readonly IGeminiMailService _geminiMailService;
        private readonly IEmailService _emailService;
        private readonly ILogger<OgrenciBurslarController> _logger;

        public OgrenciBurslarController(
            OgrenciBursRepository ogrenciBursRepository,
            OgrenciRepository ogrenciRepository,
            BursRepository bursRepository,
            IGeminiMailService geminiMailService,
            IEmailService emailService,
            ILogger<OgrenciBurslarController> logger)
        {
            _ogrenciBursRepository = ogrenciBursRepository;
            _ogrenciRepository = ogrenciRepository;
            _bursRepository = bursRepository;
            _geminiMailService = geminiMailService;
            _emailService = emailService;
            _logger = logger;
        }

        /// <summary>
        /// Tüm öğrenci-burs eşleştirmelerini listeler (navigation properties ile).
        /// </summary>
        [HttpGet]
        public ActionResult Get()
        {
            var liste = _ogrenciBursRepository.TumEslestirmeleriGetir();
            
            // Desktop için DTO formatına dönüştür
            var dtoListe = liste.Select(ob => new
            {
                Id = ob.Id,
                OgrenciId = ob.OgrenciId,
                OgrenciAd = ob.Ogrenci?.Ad ?? string.Empty,
                OgrenciSoyad = ob.Ogrenci?.Soyad ?? string.Empty,
                OgrenciTcKimlikNo = ob.Ogrenci?.TcKimlikNo ?? string.Empty,
                BursId = ob.BursId,
                BursAdi = ob.Burs?.BursAdi ?? string.Empty,
                AylikTutar = ob.Burs?.AylikTutar ?? 0,
                Onaylandi = ob.Onaylandi
            }).ToList();
            
            return Ok(dtoListe);
        }

        /// <summary>
        /// Belirli bir öğrencinin burs durumunu getirir.
        /// </summary>
        [HttpGet("ogrenci/{ogrenciId}")]
        public ActionResult GetByOgrenciId(int ogrenciId)
        {
            var ogrenciBurs = _ogrenciBursRepository.OgrenciyeGoreGetir(ogrenciId);
            if (ogrenciBurs == null)
                return NotFound(new { message = "Öğrencinin onaylanmış burs eşleştirmesi bulunamadı." });

            return Ok(ogrenciBurs);
        }

        /// <summary>
        /// Belirli bir bursa sahip tüm öğrencileri getirir.
        /// </summary>
        [HttpGet("burs/{bursId}")]
        public ActionResult GetByBursId(int bursId)
        {
            var eslestirmeler = _ogrenciBursRepository.TumEslestirmeleriGetir();
            var bursOgrencileri = eslestirmeler
                .Where(ob => ob.BursId == bursId && ob.Onaylandi)
                .Select(ob => new
                {
                    OgrenciBursId = ob.Id, // DELETE işlemi için gerekli
                    Id = ob.Ogrenci.Id,
                    TcKimlikNo = ob.Ogrenci.TcKimlikNo,
                    Ad = ob.Ogrenci.Ad,
                    Soyad = ob.Ogrenci.Soyad,
                    Puan = ob.Ogrenci.Puan,
                    Universite = ob.Ogrenci.Universite,
                    Bolum = ob.Ogrenci.Bolum
                })
                .ToList();

            return Ok(bursOgrencileri);
        }

        /// <summary>
        /// Yeni öğrenci-burs eşleştirmesi oluşturur.
        /// </summary>
        [HttpPost]
        public ActionResult Post([FromBody] OgrenciBursEslestirmeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Öğrenci ve burs var mı kontrol et
            var ogrenci = _ogrenciRepository.Getir(dto.OgrenciId);
            if (ogrenci == null)
                return NotFound(new { message = "Öğrenci bulunamadı." });

            var burs = _bursRepository.Getir(dto.BursId);
            if (burs == null)
                return NotFound(new { message = "Burs bulunamadı." });

            // Öğrencinin puanı burs minimum puanından yüksek mi kontrol et
            if (ogrenci.Puan < burs.MinimumPuan)
            {
                return BadRequest(new { message = $"Öğrencinin puanı ({ogrenci.Puan}) bu bursun minimum puanından ({burs.MinimumPuan}) düşük." });
            }

            // Öğrencinin zaten onaylanmış burs eşleştirmesi var mı kontrol et
            if (_ogrenciBursRepository.OgrenciBursAlmisMi(dto.OgrenciId))
            {
                return BadRequest(new { message = "Bu öğrencinin zaten onaylanmış bir burs eşleştirmesi var." });
            }

            // Burs kontenjan kontrolü
            var mevcutOgrenciSayisi = _ogrenciBursRepository.BursaKayitliOgrenciSayisi(dto.BursId);
            if (mevcutOgrenciSayisi >= burs.Kontenjan)
            {
                return BadRequest(new { message = $"Bu bursun kontenjanı dolmuş. Kontenjan: {burs.Kontenjan}, Mevcut öğrenci sayısı: {mevcutOgrenciSayisi}" });
            }

            var ogrenciBurs = new OgrenciBurs
            {
                OgrenciId = dto.OgrenciId,
                BursId = dto.BursId,
                Onaylandi = dto.Onaylandi
            };

            var kaydedilen = _ogrenciBursRepository.Ekle(ogrenciBurs);

            // Eğer burs onaylandıysa ve öğrencinin email adresi varsa mail gönder
            if (dto.Onaylandi && !string.IsNullOrWhiteSpace(ogrenci.Email))
            {
                _ = Task.Run(async () =>
                {
                    try
                    {
                        var (konu, icerik) = await _geminiMailService.BursAtamaMailIcerigiOlusturAsync(ogrenci, burs);
                        await _emailService.MailGonderAsync(ogrenci.Email, konu, icerik);
                        _logger.LogInformation("Burs atama maili gönderildi. Öğrenci: {OgrenciAd} {OgrenciSoyad}, Email: {Email}", 
                            ogrenci.Ad, ogrenci.Soyad, ogrenci.Email);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Burs atama maili gönderilirken hata oluştu. Öğrenci: {OgrenciAd} {OgrenciSoyad}, Email: {Email}", 
                            ogrenci.Ad, ogrenci.Soyad, ogrenci.Email);
                    }
                });
            }

            return Ok(kaydedilen);
        }

        /// <summary>
        /// Öğrenci-burs eşleştirmesini onaylar veya reddeder.
        /// </summary>
        [HttpPut("{id}/onay")]
        public ActionResult Onayla(int id, [FromBody] bool onaylandi)
        {
            var ogrenciBurs = _ogrenciBursRepository.Getir(id);
            if (ogrenciBurs == null)
                return NotFound();

            bool oncekiOnayDurumu = ogrenciBurs.Onaylandi;
            ogrenciBurs.Onaylandi = onaylandi;
            _ogrenciBursRepository.Guncelle(ogrenciBurs);

            // Eğer burs onaylandıysa ve öğrencinin email adresi varsa mail gönder
            // (Sadece önceki durum false iken true yapıldığında gönder, tekrar göndermeyi önlemek için)
            if (onaylandi && !oncekiOnayDurumu && ogrenciBurs.Ogrenci != null && !string.IsNullOrWhiteSpace(ogrenciBurs.Ogrenci.Email))
            {
                var ogrenci = ogrenciBurs.Ogrenci;
                var burs = ogrenciBurs.Burs;

                _ = Task.Run(async () =>
                {
                    try
                    {
                        var (konu, icerik) = await _geminiMailService.BursAtamaMailIcerigiOlusturAsync(ogrenci, burs);
                        await _emailService.MailGonderAsync(ogrenci.Email, konu, icerik);
                        _logger.LogInformation("Burs onay maili gönderildi. Öğrenci: {OgrenciAd} {OgrenciSoyad}, Email: {Email}", 
                            ogrenci.Ad, ogrenci.Soyad, ogrenci.Email);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Burs onay maili gönderilirken hata oluştu. Öğrenci: {OgrenciAd} {OgrenciSoyad}, Email: {Email}", 
                            ogrenci.Ad, ogrenci.Soyad, ogrenci.Email);
                    }
                });
            }

            return Ok(ogrenciBurs);
        }

        /// <summary>
        /// Öğrenci-burs eşleştirmesini siler ve öğrenciye mail gönderir.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // Silmeden önce öğrenci ve burs bilgilerini al
            var ogrenciBurs = _ogrenciBursRepository.Getir(id);
            if (ogrenciBurs == null)
                return NotFound(new { message = "Burs eşleştirmesi bulunamadı." });

            // Sadece onaylanmış eşleştirmeler için mail gönder
            bool mailGonderilecek = ogrenciBurs.Onaylandi && 
                                    ogrenciBurs.Ogrenci != null && 
                                    ogrenciBurs.Burs != null &&
                                    !string.IsNullOrWhiteSpace(ogrenciBurs.Ogrenci.Email);

            // Mail gönderimi için bilgileri kaydet (null-safe)
            Ogrenci? ogrenci = ogrenciBurs.Ogrenci;
            Burs? burs = ogrenciBurs.Burs;

            // Eşleştirmeyi sil
            _ogrenciBursRepository.Sil(id);

            // Eğer onaylanmış bir eşleştirme silindiyse ve öğrencinin email adresi varsa mail gönder
            if (mailGonderilecek && ogrenci != null && burs != null)
            {
                _ = Task.Run(async () =>
                {
                    try
                    {
                        var (konu, icerik) = await _geminiMailService.BursCikarmaMailIcerigiOlusturAsync(ogrenci, burs);
                        await _emailService.MailGonderAsync(ogrenci.Email, konu, icerik);
                        _logger.LogInformation("Burs çıkarma maili gönderildi. Öğrenci: {OgrenciAd} {OgrenciSoyad}, Email: {Email}, Burs: {BursAdi}", 
                            ogrenci.Ad, ogrenci.Soyad, ogrenci.Email, burs.BursAdi);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Burs çıkarma maili gönderilirken hata oluştu. Öğrenci: {OgrenciAd} {OgrenciSoyad}, Email: {Email}, Burs: {BursAdi}", 
                            ogrenci.Ad, ogrenci.Soyad, ogrenci.Email, burs.BursAdi);
                    }
                });
            }

            return NoContent();
        }
    }

    /// <summary>
    /// Öğrenci-Burs eşleştirmesi için DTO.
    /// </summary>
    public class OgrenciBursEslestirmeDto
    {
        public int OgrenciId { get; set; }
        public int BursId { get; set; }
        public bool Onaylandi { get; set; } = false;
    }
}

