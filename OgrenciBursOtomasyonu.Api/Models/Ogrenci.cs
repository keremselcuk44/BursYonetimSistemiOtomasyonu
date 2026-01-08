namespace OgrenciBursOtomasyonu.Api.Models
{
    /// <summary>
    /// Öğrenci temel bilgileri ve burs puanı modelini temsil eder.
    /// </summary>
    public class Ogrenci
    {
        public int Id { get; set; }
        public string TcKimlikNo { get; set; } = string.Empty;
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;
        public string Universite { get; set; } = string.Empty;
        public string Bolum { get; set; } = string.Empty;
        public string Sinif { get; set; } = string.Empty; // Hazırlık, 1, 2, 3, 4
        public decimal Agno { get; set; } // Akademik Genel Not Ortalaması (0-4 arası)
        public int KardesSayisi { get; set; }
        public decimal HaneGeliri { get; set; } // Aylık hane geliri

        /// <summary>
        /// Öğrencinin yaşı (yıl cinsinden).
        /// </summary>
        public int Yas { get; set; }

        // Klasik sorular (ağırlıklı puanlama için)
        public string BursAlmaIhtiyaci { get; set; } = string.Empty; // Burs alma ihtiyacını kısaca açıklar mısın?
        public string EgitimMasraflari { get; set; } = string.Empty; // Eğitim masraflarını şu ana kadar nasıl karşıladın?
        public string AkademikGelisim { get; set; } = string.Empty; // Kendini akademik olarak geliştirmek için neler yapıyorsun?
        public string ToplumaKatki { get; set; } = string.Empty; // Aldığın eğitimin topluma nasıl katkı sağlayacağını düşünüyorsun?
        public string BesYilSonrasi { get; set; } = string.Empty; // Kendini 5 yıl sonra nerede görüyorsun?

        // Gemini tarafından hesaplanan puan (0–100)
        public int Puan { get; set; } = 0;

        // AI tarafından oluşturulan özet rapor
        public string AiRaporu { get; set; } = string.Empty;

        // İletişim ve resim bilgileri
        public string Email { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public string Iban { get; set; } = string.Empty;
        public string ResimYolu { get; set; } = string.Empty; // Resim dosya yolu veya base64 string
    }
}




