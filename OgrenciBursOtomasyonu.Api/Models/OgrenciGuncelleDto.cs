namespace OgrenciBursOtomasyonu.Api.Models
{
    /// <summary>
    /// Öğrencinin genel bilgilerini güncellemek için kullanılan DTO.
    /// Puanlama ve klasik soru alanlarına dokunulmaz.
    /// </summary>
    public class OgrenciGuncelleDto
    {
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;
        public string Universite { get; set; } = string.Empty;
        public string Bolum { get; set; } = string.Empty;
        public string Sinif { get; set; } = string.Empty;
        /// <summary>
        /// Öğrencinin yaşı (yıl cinsinden).
        /// </summary>
        public int Yas { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public string Iban { get; set; } = string.Empty;
        /// <summary>
        /// Base64 string veya dosya yolu.
        /// </summary>
        public string ResimYolu { get; set; } = string.Empty;
    }
}


