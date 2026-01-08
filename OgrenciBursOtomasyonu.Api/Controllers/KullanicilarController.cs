using Microsoft.AspNetCore.Mvc;
using OgrenciBursOtomasyonu.Api.Data;
using OgrenciBursOtomasyonu.Api.Models;
using OgrenciBursOtomasyonu.Api.Services;

namespace OgrenciBursOtomasyonu.Api.Controllers
{
    /// <summary>
    /// Kullanıcı giriş ve yönetim işlemleri.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class KullanicilarController : ControllerBase
    {
        private readonly KullaniciRepository _kullaniciRepository;

        public KullanicilarController(KullaniciRepository kullaniciRepository)
        {
            _kullaniciRepository = kullaniciRepository;
        }

        /// <summary>
        /// Basit kullanıcı doğrulama endpoint'i.
        /// </summary>
        [HttpPost("login")]
        public ActionResult<LoginResponseDto> Login([FromBody] LoginRequestDto request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.KullaniciAdi) || string.IsNullOrWhiteSpace(request.Sifre))
            {
                return BadRequest(new LoginResponseDto
                {
                    Basarili = false,
                    Mesaj = "Kullanıcı adı ve şifre zorunludur."
                });
            }

            var sifreHash = PasswordHasher.Hash(request.Sifre);
            var kullanici = _kullaniciRepository.Dogrula(request.KullaniciAdi.Trim(), sifreHash);
            if (kullanici == null)
            {
                return Unauthorized(new LoginResponseDto
                {
                    Basarili = false,
                    Mesaj = "Kullanıcı adı veya şifre hatalı."
                });
            }

            return Ok(new LoginResponseDto
            {
                Basarili = true,
                Mesaj = "Giriş başarılı.",
                KullaniciAdi = kullanici.KullaniciAdi
            });
        }

        /// <summary>
        /// Tüm kullanıcıları listeler.
        /// </summary>
        [HttpGet]
        public ActionResult Get()
        {
            var liste = _kullaniciRepository.TumKullanicilar()
                .Select(k => new
                {
                    k.Id,
                    k.KullaniciAdi,
                    k.Aktif,
                    k.OlusturmaTarihi
                })
                .ToList();

            return Ok(liste);
        }

        /// <summary>
        /// Belirli bir kullanıcıyı getirir.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var k = _kullaniciRepository.Getir(id);
            if (k == null)
                return NotFound();

            return Ok(new
            {
                k.Id,
                k.KullaniciAdi,
                k.Aktif,
                k.OlusturmaTarihi
            });
        }

        /// <summary>
        /// Yeni kullanıcı oluşturur.
        /// </summary>
        [HttpPost]
        public ActionResult Create([FromBody] KullaniciCreateDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.KullaniciAdi) || string.IsNullOrWhiteSpace(dto.Sifre))
            {
                return BadRequest("Kullanıcı adı ve şifre zorunludur.");
            }

            var yeni = new Kullanici
            {
                KullaniciAdi = dto.KullaniciAdi.Trim(),
                SifreHash = PasswordHasher.Hash(dto.Sifre),
                Aktif = dto.Aktif
            };

            var kaydedilen = _kullaniciRepository.Ekle(yeni);

            return Ok(new
            {
                kaydedilen.Id,
                kaydedilen.KullaniciAdi,
                kaydedilen.Aktif,
                kaydedilen.OlusturmaTarihi
            });
        }

        /// <summary>
        /// Var olan kullanıcıyı günceller (şifre boş gelirse değişmez).
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] KullaniciUpdateDto dto)
        {
            var mevcut = _kullaniciRepository.Getir(id);
            if (mevcut == null)
                return NotFound();

            mevcut.KullaniciAdi = dto.KullaniciAdi?.Trim() ?? mevcut.KullaniciAdi;
            mevcut.Aktif = dto.Aktif;

            if (!string.IsNullOrWhiteSpace(dto.YeniSifre))
            {
                mevcut.SifreHash = PasswordHasher.Hash(dto.YeniSifre);
            }

            _kullaniciRepository.Guncelle(mevcut);

            return Ok(new
            {
                mevcut.Id,
                mevcut.KullaniciAdi,
                mevcut.Aktif,
                mevcut.OlusturmaTarihi
            });
        }

        /// <summary>
        /// Kullanıcıyı siler.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var kullanici = _kullaniciRepository.Getir(id);
            if (kullanici == null)
                return NotFound();

            _kullaniciRepository.Sil(id);
            return NoContent();
        }
    }
}

