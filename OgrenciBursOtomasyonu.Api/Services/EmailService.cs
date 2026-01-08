using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OgrenciBursOtomasyonu.Api.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpKullaniciAdi;
        private readonly string _smtpSifre;
        private readonly string _gondericiEmail;
        private readonly string _gondericiAdi;
        private readonly bool _enableSsl;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;

            // SMTP ayarlarını appsettings.json'dan oku
            _smtpServer = _configuration["Email:SmtpServer"] ?? "smtp.gmail.com";
            _smtpPort = int.Parse(_configuration["Email:SmtpPort"] ?? "587");
            _smtpKullaniciAdi = _configuration["Email:SmtpKullaniciAdi"] ?? string.Empty;
            _smtpSifre = _configuration["Email:SmtpSifre"] ?? string.Empty;
            
            // Gönderen email: Önce GondericiEmail'e bak, yoksa SmtpKullaniciAdi kullan
            var gondericiEmailConfig = _configuration["Email:GondericiEmail"];
            _gondericiEmail = !string.IsNullOrWhiteSpace(gondericiEmailConfig) 
                ? gondericiEmailConfig 
                : (!string.IsNullOrWhiteSpace(_smtpKullaniciAdi) ? _smtpKullaniciAdi : "noreply@bursotomasyonu.com");
            
            _gondericiAdi = _configuration["Email:GondericiAdi"] ?? "Burs Yönetim Sistemi";
            _enableSsl = bool.Parse(_configuration["Email:EnableSsl"] ?? "true");
            
            _logger.LogInformation("Email servisi yapılandırıldı. SMTP: {Server}:{Port}, Gönderen: {GondericiAdi} <{GondericiEmail}>", 
                _smtpServer, _smtpPort, _gondericiAdi, _gondericiEmail);
        }

        public async Task<bool> MailGonderAsync(string aliciEmail, string konu, string icerik)
        {
            // E-posta adresi kontrolü
            if (string.IsNullOrWhiteSpace(aliciEmail) || !IsValidEmail(aliciEmail))
            {
                _logger.LogWarning("Geçersiz e-posta adresi: {Email}", aliciEmail);
                return false;
            }

            // SMTP ayarları kontrolü
            if (string.IsNullOrWhiteSpace(_smtpKullaniciAdi) || string.IsNullOrWhiteSpace(_smtpSifre))
            {
                _logger.LogWarning("SMTP ayarları yapılandırılmamış. Mail gönderilemedi.");
                return false;
            }

            try
            {
                using var smtpClient = new SmtpClient(_smtpServer, _smtpPort)
                {
                    EnableSsl = _enableSsl,
                    Credentials = new NetworkCredential(_smtpKullaniciAdi, _smtpSifre),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Timeout = 30000 // 30 saniye timeout
                };

                using var mailMessage = new MailMessage
                {
                    From = new MailAddress(_gondericiEmail, _gondericiAdi),
                    Subject = konu,
                    Body = icerik,
                    IsBodyHtml = true,
                    Priority = MailPriority.Normal
                };

                mailMessage.To.Add(aliciEmail);

                _logger.LogInformation("Mail gönderiliyor. Alıcı: {Alici}, Konu: {Konu}", aliciEmail, konu);

                await smtpClient.SendMailAsync(mailMessage);

                _logger.LogInformation("Mail başarıyla gönderildi. Alıcı: {Alici}", aliciEmail);
                return true;
            }
            catch (SmtpException ex)
            {
                _logger.LogError(ex, "SMTP hatası. Alıcı: {Alici}, Hata: {Message}", aliciEmail, ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Mail gönderme hatası. Alıcı: {Alici}, Hata: {Message}", aliciEmail, ex.Message);
                return false;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}

