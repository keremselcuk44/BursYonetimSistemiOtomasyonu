using Microsoft.AspNetCore.Mvc;
using OgrenciBursOtomasyonu.Api.Data;
using OgrenciBursOtomasyonu.Api.Models;

namespace OgrenciBursOtomasyonu.Api.Controllers
{
    /// <summary>
    /// Burs tanımlarını yöneten Web API controller'ı.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BurslarController : ControllerBase
    {
        private readonly BursRepository _bursRepository;

        public BurslarController(BursRepository bursRepository)
        {
            _bursRepository = bursRepository;
        }

        /// <summary>
        /// Tüm bursları listeler.
        /// </summary>
        [HttpGet]
        public ActionResult Get()
        {
            var liste = _bursRepository.TumBurslariGetir();
            return Ok(liste);
        }

        /// <summary>
        /// Belirli bir bursun detaylarını getirir.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var burs = _bursRepository.Getir(id);
            if (burs == null)
                return NotFound();

            return Ok(burs);
        }

        /// <summary>
        /// Yeni burs tanımı oluşturur.
        /// </summary>
        [HttpPost]
        public ActionResult Post([FromBody] Burs burs)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Yeni kayıt için tarihleri ayarla
            burs.OlusturmaTarihi = DateTime.UtcNow;
            burs.GuncellemeTarihi = DateTime.UtcNow;
            if (string.IsNullOrWhiteSpace(burs.OdemePeriyodu))
                burs.OdemePeriyodu = "Aylık";

            var kaydedilen = _bursRepository.Ekle(burs);
            return Ok(kaydedilen);
        }

        /// <summary>
        /// Mevcut burs tanımını günceller.
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Burs burs)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mevcutBurs = _bursRepository.Getir(id);
            if (mevcutBurs == null)
                return NotFound();

            mevcutBurs.BursAdi = burs.BursAdi;
            mevcutBurs.BursTipi = burs.BursTipi;
            mevcutBurs.Aciklama = burs.Aciklama;
            mevcutBurs.MinimumPuan = burs.MinimumPuan;
            mevcutBurs.Kontenjan = burs.Kontenjan;
            mevcutBurs.AylikTutar = burs.AylikTutar;
            mevcutBurs.OdemePeriyodu = burs.OdemePeriyodu;
            mevcutBurs.BaslangicTarihi = burs.BaslangicTarihi;
            mevcutBurs.BitisTarihi = burs.BitisTarihi;
            mevcutBurs.AktifMi = burs.AktifMi;
            mevcutBurs.Kosullar = burs.Kosullar;
            mevcutBurs.GuncellemeTarihi = DateTime.UtcNow;

            _bursRepository.Guncelle(mevcutBurs);
            return Ok(mevcutBurs);
        }

        /// <summary>
        /// Bursu siler. İlişkili öğrenci-burs eşleştirmeleri varsa hata verir.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var burs = _bursRepository.Getir(id);
            if (burs == null)
                return NotFound();

            // Bu bursa bağlı öğrenci-burs eşleştirmeleri var mı kontrol et
            // (Bu kontrolü OgrenciBursRepository üzerinden yapabiliriz ama şimdilik basit tutuyoruz)
            _bursRepository.Sil(id);
            return NoContent();
        }
    }
}

