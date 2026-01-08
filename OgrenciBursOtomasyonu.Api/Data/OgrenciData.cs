using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OgrenciBursOtomasyonu.Api.Models;

namespace OgrenciBursOtomasyonu.Api.Data
{
    /// <summary>
    /// SQL Server veritabanı kullanarak öğrenci verilerini yöneten repository sınıfı.
    /// </summary>
    public class OgrenciRepository
    {
        private readonly ApplicationDbContext _context;

        public OgrenciRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IReadOnlyList<Ogrenci> TumOgrencileriGetir()
        {
            return _context.Ogrenciler.ToList();
        }

        public Ogrenci? Getir(int id)
        {
            return _context.Ogrenciler.FirstOrDefault(o => o.Id == id);
        }

        public Ogrenci Ekle(Ogrenci ogrenci)
        {
            _context.Ogrenciler.Add(ogrenci);
            _context.SaveChanges();
            return ogrenci;
        }

        public void Guncelle(Ogrenci ogrenci)
        {
            _context.Ogrenciler.Update(ogrenci);
            _context.SaveChanges();
        }

        public void Sil(int id)
        {
            var ogrenci = _context.Ogrenciler.Find(id);
            if (ogrenci != null)
            {
                _context.Ogrenciler.Remove(ogrenci);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// TC Kimlik No veya Email ile öğrenci getirir.
        /// </summary>
        public Ogrenci? TcVeyaEmailIleGetir(string? tcKimlikNo, string? email)
        {
            if (!string.IsNullOrWhiteSpace(tcKimlikNo))
            {
                return _context.Ogrenciler.FirstOrDefault(o => o.TcKimlikNo == tcKimlikNo.Trim());
            }
            
            if (!string.IsNullOrWhiteSpace(email))
            {
                return _context.Ogrenciler.FirstOrDefault(o => o.Email == email.Trim());
            }

            return null;
        }
    }
}




