namespace OgrenciBursOtomasyonu.Api.Models
{
    /// <summary>
    /// Burs ödeme takibini temsil eder.
    /// Her öğrenci-burs eşleştirmesi için aylık ödeme durumu tutulur.
    /// </summary>
    public class BursOdemeTakip
    {
        public int Id { get; set; }
        public int OgrenciBursId { get; set; } // Hangi öğrenci-burs eşleştirmesi
        public int Ay { get; set; } // 1-12 arası (Ocak-Aralık)
        public int Yil { get; set; } // Örn: 2024, 2025
        public bool OdendiMi { get; set; } // Bu ay ödendi mi?
        public DateTime? OdemeTarihi { get; set; } // Ödeme onaylandığı tarih

        // Navigation property
        public OgrenciBurs OgrenciBurs { get; set; } = null!;
    }
}

