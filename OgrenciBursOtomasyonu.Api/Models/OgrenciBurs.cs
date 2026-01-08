namespace OgrenciBursOtomasyonu.Api.Models
{
    /// <summary>
    /// Öğrenci ve burs eşleştirmesini temsil eder.
    /// </summary>
    public class OgrenciBurs
    {
        public int Id { get; set; }
        public int OgrenciId { get; set; }
        public int BursId { get; set; }
        public bool Onaylandi { get; set; }

        // Navigation properties
        public Ogrenci Ogrenci { get; set; } = null!;
        public Burs Burs { get; set; } = null!;
    }
}




