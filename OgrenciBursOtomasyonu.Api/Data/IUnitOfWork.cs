namespace OgrenciBursOtomasyonu.Api.Data
{
    /// <summary>
    /// Unit of Work pattern interface. Tüm repository'lere merkezi erişim sağlar.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Öğrenci repository'si.
        /// </summary>
        OgrenciRepository Ogrenciler { get; }

        /// <summary>
        /// Burs repository'si.
        /// </summary>
        BursRepository Burslar { get; }

        /// <summary>
        /// Öğrenci-Burs eşleştirme repository'si.
        /// </summary>
        OgrenciBursRepository OgrenciBurslar { get; }

        /// <summary>
        /// Burs ödeme takip repository'si.
        /// </summary>
        BursOdemeTakipRepository BursOdemeTakipleri { get; }

        /// <summary>
        /// Kullanıcı repository'si.
        /// </summary>
        KullaniciRepository Kullanicilar { get; }

        /// <summary>
        /// Değişiklikleri veritabanına kaydet.
        /// </summary>
        void SaveChanges();
    }
}

