namespace OgrenciBursOtomasyonu.Api.Services
{
    /// <summary>
    /// E-posta gönderme servisi sözleşmesi.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// E-posta gönderir.
        /// </summary>
        /// <param name="aliciEmail">Alıcı e-posta adresi</param>
        /// <param name="konu">E-posta konusu</param>
        /// <param name="icerik">E-posta içeriği (HTML formatında)</param>
        /// <returns>Gönderim başarılı mı?</returns>
        Task<bool> MailGonderAsync(string aliciEmail, string konu, string icerik);
    }
}

