namespace OgrenciBursOtomasyonu.Desktop
{
    /// <summary>
    /// Oturumda giriş yapan kullanıcı bilgisi.
    /// </summary>
    public static class UserSession
    {
        public static string KullaniciAdi { get; private set; } = string.Empty;
        public static bool GirisYapildi { get; private set; }

        public static void SetKullanici(string kullaniciAdi)
        {
            KullaniciAdi = kullaniciAdi;
            GirisYapildi = true;
        }
    }
}

