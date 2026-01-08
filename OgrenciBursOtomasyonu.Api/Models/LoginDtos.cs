namespace OgrenciBursOtomasyonu.Api.Models
{
    /// <summary>
    /// Giriş isteği DTO'su.
    /// </summary>
    public class LoginRequestDto
    {
        public string KullaniciAdi { get; set; } = string.Empty;
        public string Sifre { get; set; } = string.Empty;
    }

    /// <summary>
    /// Giriş yanıtı DTO'su.
    /// </summary>
    public class LoginResponseDto
    {
        public bool Basarili { get; set; }
        public string Mesaj { get; set; } = string.Empty;
        public string KullaniciAdi { get; set; } = string.Empty;
    }
}

