using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OgrenciBursOtomasyonu.Api.Data;
using OgrenciBursOtomasyonu.Api.Models;

namespace OgrenciBursOtomasyonu.Api.Controllers
{
    /// <summary>
    /// Burs ödeme takibini yöneten Web API controller'ı.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BursOdemeTakipController : ControllerBase
    {
        private readonly BursOdemeTakipRepository _odemeTakipRepository;
        private readonly OgrenciBursRepository _ogrenciBursRepository;

        public BursOdemeTakipController(
            BursOdemeTakipRepository odemeTakipRepository,
            OgrenciBursRepository ogrenciBursRepository)
        {
            _odemeTakipRepository = odemeTakipRepository;
            _ogrenciBursRepository = ogrenciBursRepository;
        }

        /// <summary>
        /// Belirli bir öğrenci-burs eşleştirmesi için ödeme takiplerini getirir.
        /// </summary>
        [HttpGet("ogrenciburs/{ogrenciBursId}")]
        public ActionResult GetByOgrenciBursId(int ogrenciBursId)
        {
            var takipler = _odemeTakipRepository.OgrenciBursaGoreGetir(ogrenciBursId);
            var toplamOdenen = _odemeTakipRepository.ToplamOdenenTutar(ogrenciBursId);
            
            // DTO'ya dönüştür
            var takipDtoList = takipler.Select(t => new BursOdemeTakipDto
            {
                Id = t.Id,
                OgrenciBursId = t.OgrenciBursId,
                Ay = t.Ay,
                Yil = t.Yil,
                OdendiMi = t.OdendiMi,
                OdemeTarihi = t.OdemeTarihi
            }).ToList();
            
            return Ok(new
            {
                takipler = takipDtoList,
                toplamOdenenTutar = toplamOdenen
            });
        }

        /// <summary>
        /// Burs ödemesini onaylar (belirli ay-yıl için).
        /// </summary>
        [HttpPost("onayla")]
        public ActionResult OdemeOnayla([FromBody] OdemeOnayDto dto)
        {
            var ogrenciBurs = _ogrenciBursRepository.Getir(dto.OgrenciBursId);
            if (ogrenciBurs == null)
                return NotFound(new { message = "Öğrenci-burs eşleştirmesi bulunamadı." });

            if (dto.Ay < 1 || dto.Ay > 12)
                return BadRequest(new { message = "Ay değeri 1-12 arası olmalıdır." });

            if (dto.Yil < 1900 || dto.Yil > 2100)
                return BadRequest(new { message = "Yıl değeri 1900-2100 arası olmalıdır." });

            var takip = _odemeTakipRepository.OdemeOnayla(dto.OgrenciBursId, dto.Ay, dto.Yil);
            
            // DTO'ya dönüştür
            var takipDto = new BursOdemeTakipDto
            {
                Id = takip.Id,
                OgrenciBursId = takip.OgrenciBursId,
                Ay = takip.Ay,
                Yil = takip.Yil,
                OdendiMi = takip.OdendiMi,
                OdemeTarihi = takip.OdemeTarihi
            };
            
            return Ok(takipDto);
        }

        /// <summary>
        /// Burs ödemesini iptal eder.
        /// </summary>
        [HttpPost("iptal")]
        public ActionResult OdemeIptal([FromBody] OdemeIptalDto dto)
        {
            _odemeTakipRepository.OdemeIptal(dto.OgrenciBursId, dto.Ay, dto.Yil);
            return Ok(new { message = "Ödeme iptal edildi." });
        }
    }

    /// <summary>
    /// Ödeme onay DTO.
    /// </summary>
    public class OdemeOnayDto
    {
        public int OgrenciBursId { get; set; }
        public int Ay { get; set; }
        public int Yil { get; set; }
    }

    /// <summary>
    /// Ödeme iptal DTO.
    /// </summary>
    public class OdemeIptalDto
    {
        public int OgrenciBursId { get; set; }
        public int Ay { get; set; }
        public int Yil { get; set; }
    }

    /// <summary>
    /// Burs ödeme takip DTO (API response için).
    /// </summary>
    public class BursOdemeTakipDto
    {
        public int Id { get; set; }
        public int OgrenciBursId { get; set; }
        public int Ay { get; set; }
        public int Yil { get; set; }
        public bool OdendiMi { get; set; }
        public DateTime? OdemeTarihi { get; set; }
    }
}

