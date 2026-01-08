using Microsoft.EntityFrameworkCore;

namespace OgrenciBursOtomasyonu.Api.Data
{
    /// <summary>
    /// Unit of Work pattern implementation. Tüm repository'leri tek bir yerden yönetir.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private OgrenciRepository? _ogrenciler;
        private BursRepository? _burslar;
        private OgrenciBursRepository? _ogrenciBurslar;
        private BursOdemeTakipRepository? _bursOdemeTakipleri;
        private KullaniciRepository? _kullanicilar;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Öğrenci repository'si.
        /// </summary>
        public OgrenciRepository Ogrenciler
        {
            get
            {
                _ogrenciler ??= new OgrenciRepository(_context);
                return _ogrenciler;
            }
        }

        /// <summary>
        /// Burs repository'si.
        /// </summary>
        public BursRepository Burslar
        {
            get
            {
                _burslar ??= new BursRepository(_context);
                return _burslar;
            }
        }

        /// <summary>
        /// Öğrenci-Burs eşleştirme repository'si.
        /// </summary>
        public OgrenciBursRepository OgrenciBurslar
        {
            get
            {
                _ogrenciBurslar ??= new OgrenciBursRepository(_context);
                return _ogrenciBurslar;
            }
        }

        /// <summary>
        /// Burs ödeme takip repository'si.
        /// </summary>
        public BursOdemeTakipRepository BursOdemeTakipleri
        {
            get
            {
                _bursOdemeTakipleri ??= new BursOdemeTakipRepository(_context);
                return _bursOdemeTakipleri;
            }
        }

        /// <summary>
        /// Kullanıcı repository'si.
        /// </summary>
        public KullaniciRepository Kullanicilar
        {
            get
            {
                _kullanicilar ??= new KullaniciRepository(_context);
                return _kullanicilar;
            }
        }

        /// <summary>
        /// Değişiklikleri veritabanına kaydet.
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

