using OgrenciBursOtomasyonu.Api.Models;

namespace OgrenciBursOtomasyonu.Api.Services
{
    /// <summary>
    /// Gemini API kullanarak burs bildirim maili içeriği oluşturan servis sözleşmesi.
    /// </summary>
    public interface IGeminiMailService
    {
        /// <summary>
        /// Öğrenciye burs atandığında gönderilecek mail içeriğini Gemini API ile oluşturur.
        /// </summary>
        /// <param name="ogrenci">Burs alan öğrenci</param>
        /// <param name="burs">Atanan burs</param>
        /// <returns>Mail konusu ve içeriği</returns>
        Task<(string Konu, string Icerik)> BursAtamaMailIcerigiOlusturAsync(Ogrenci ogrenci, Burs burs);

        /// <summary>
        /// Öğrenci burstan çıkarıldığında gönderilecek mail içeriğini Gemini API ile oluşturur.
        /// </summary>
        /// <param name="ogrenci">Burstan çıkarılan öğrenci</param>
        /// <param name="burs">Çıkarıldığı burs</param>
        /// <returns>Mail konusu ve içeriği</returns>
        Task<(string Konu, string Icerik)> BursCikarmaMailIcerigiOlusturAsync(Ogrenci ogrenci, Burs burs);
    }
}

