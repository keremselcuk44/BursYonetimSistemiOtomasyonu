namespace OgrenciBursOtomasyonu.Api.Models
{
    /// <summary>
    /// Yeni kullanıcı oluşturma isteği DTO'su.
    /// </summary>
    public class KullaniciCreateDto
    {
        public string KullaniciAdi { get; set; } = string.Empty;
        public string Sifre { get; set; } = string.Empty;
        public bool Aktif { get; set; } = true;
    }

    /// <summary>
    /// Var olan kullanıcıyı güncelleme isteği DTO'su.
    /// </summary>
    public class KullaniciUpdateDto
    {
        public string KullaniciAdi { get; set; } = string.Empty;
        /// <summary>
        /// Boş bırakılırsa şifre değiştirilmez.
        /// </summary>
        public string YeniSifre { get; set; } = string.Empty;
        public bool Aktif { get; set; } = true;
    }
}


