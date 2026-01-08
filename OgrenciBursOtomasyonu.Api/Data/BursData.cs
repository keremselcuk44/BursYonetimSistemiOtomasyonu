using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OgrenciBursOtomasyonu.Api.Models;

namespace OgrenciBursOtomasyonu.Api.Data
{
    /// <summary>
    /// SQL Server veritabanı kullanarak burs verilerini yöneten repository sınıfı.
    /// </summary>
    public class BursRepository
    {
        private readonly ApplicationDbContext _context;

        public BursRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IReadOnlyList<Burs> TumBurslariGetir()
        {
            return _context.Burslar.ToList();
        }

        public Burs? Getir(int id)
        {
            return _context.Burslar.FirstOrDefault(b => b.Id == id);
        }

        public Burs Ekle(Burs burs)
        {
            _context.Burslar.Add(burs);
            _context.SaveChanges();
            return burs;
        }

        public void Guncelle(Burs burs)
        {
            _context.Burslar.Update(burs);
            _context.SaveChanges();
        }

        public void Sil(int id)
        {
            var burs = _context.Burslar.Find(id);
            if (burs != null)
            {
                _context.Burslar.Remove(burs);
                _context.SaveChanges();
            }
        }
    }
}




