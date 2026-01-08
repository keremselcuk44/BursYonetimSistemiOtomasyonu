using System.Linq;
using OgrenciBursOtomasyonu.Api.Models;

namespace OgrenciBursOtomasyonu.Api.Data
{
    /// <summary>
    /// Kullanıcı doğrulama ve sorgulama işlemleri için repository.
    /// </summary>
    public class KullaniciRepository
    {
        private readonly ApplicationDbContext _context;

        public KullaniciRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Kullanıcı adı ve hash'lenmiş şifre ile kullanıcı getirir.
        /// </summary>
        public Kullanici? Dogrula(string kullaniciAdi, string sifreHash)
        {
            return _context.Kullanicilar
                           .FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi
                                              && k.SifreHash == sifreHash
                                              && k.Aktif);
        }

        /// <summary>
        /// Tüm kullanıcıları listeler.
        /// </summary>
        public IQueryable<Kullanici> TumKullanicilar()
        {
            return _context.Kullanicilar.OrderBy(k => k.KullaniciAdi);
        }

        /// <summary>
        /// Id'ye göre kullanıcı getirir.
        /// </summary>
        public Kullanici? Getir(int id)
        {
            return _context.Kullanicilar.FirstOrDefault(k => k.Id == id);
        }

        /// <summary>
        /// Yeni kullanıcı ekler.
        /// </summary>
        public Kullanici Ekle(Kullanici kullanici)
        {
            _context.Kullanicilar.Add(kullanici);
            _context.SaveChanges();
            return kullanici;
        }

        /// <summary>
        /// Var olan kullanıcıyı günceller.
        /// </summary>
        public void Guncelle(Kullanici kullanici)
        {
            _context.Kullanicilar.Update(kullanici);
            _context.SaveChanges();
        }

        /// <summary>
        /// Kullanıcıyı siler.
        /// </summary>
        public void Sil(int id)
        {
            var kullanici = _context.Kullanicilar.Find(id);
            if (kullanici != null)
            {
                _context.Kullanicilar.Remove(kullanici);
                _context.SaveChanges();
            }
        }
    }
}

