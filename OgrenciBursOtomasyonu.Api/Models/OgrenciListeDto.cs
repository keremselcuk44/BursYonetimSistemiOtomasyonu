namespace OgrenciBursOtomasyonu.Api.Models
{
    /// <summary>
    /// Öğrenci listesi için DTO (burs durumu dahil).
    /// </summary>
    public class OgrenciListeDto
    {
        public int Id { get; set; }
        public string TcKimlikNo { get; set; } = string.Empty;
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Yas { get; set; }
        public int Puan { get; set; }
        public string BursDurumu { get; set; } = string.Empty;
        public string BursAdi { get; set; } = string.Empty;
    }
}

