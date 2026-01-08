using System;

namespace OgrenciBursOtomasyonu.Api.Models
{
    /// <summary>
    /// Burs tanımını temsil eder.
    /// </summary>
    public class Burs
    {
        public int Id { get; set; }
        public string BursAdi { get; set; } = string.Empty;
        public string BursTipi { get; set; } = string.Empty; // Temel, Yüksek Lisans, Doktora, Özel, vb.
        public string Aciklama { get; set; } = string.Empty; // Burs hakkında detaylı açıklama
        public int MinimumPuan { get; set; }
        public int Kontenjan { get; set; }
        public decimal AylikTutar { get; set; } // Aylık burs tutarı (TL)
        public string OdemePeriyodu { get; set; } = "Aylık"; // Aylık, Dönemlik, Yıllık
        public DateTime? BaslangicTarihi { get; set; } // Bursun başlangıç tarihi
        public DateTime? BitisTarihi { get; set; } // Bursun bitiş tarihi
        public bool AktifMi { get; set; } = true; // Burs aktif mi?
        public string Kosullar { get; set; } = string.Empty; // Burs koşulları ve gereksinimler
        public DateTime OlusturmaTarihi { get; set; } = DateTime.UtcNow; // Oluşturulma tarihi
        public DateTime? GuncellemeTarihi { get; set; } // Güncellenme tarihi
    }
}




