using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OgrenciBursOtomasyonu.Api.Models;

namespace OgrenciBursOtomasyonu.Api.Data
{
    /// <summary>
    /// SQL Server veritabanı kullanarak öğrenci-burs eşleştirmelerini yöneten repository sınıfı.
    /// </summary>
    public class OgrenciBursRepository
    {
        private readonly ApplicationDbContext _context;

        public OgrenciBursRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Tüm öğrenci-burs eşleştirmelerini getirir (navigation properties ile).
        /// </summary>
        public IReadOnlyList<OgrenciBurs> TumEslestirmeleriGetir()
        {
            return _context.OgrenciBurslar
                .Include(ob => ob.Ogrenci)
                .Include(ob => ob.Burs)
                .ToList();
        }

        /// <summary>
        /// Belirli bir öğrencinin burs eşleştirmesini getirir.
        /// </summary>
        public OgrenciBurs? OgrenciyeGoreGetir(int ogrenciId)
        {
            return _context.OgrenciBurslar
                .Include(ob => ob.Ogrenci)
                .Include(ob => ob.Burs)
                .FirstOrDefault(ob => ob.OgrenciId == ogrenciId && ob.Onaylandi);
        }

        /// <summary>
        /// ID'ye göre öğrenci-burs eşleştirmesini getirir.
        /// </summary>
        public OgrenciBurs? Getir(int id)
        {
            return _context.OgrenciBurslar
                .Include(ob => ob.Ogrenci)
                .Include(ob => ob.Burs)
                .FirstOrDefault(ob => ob.Id == id);
        }

        /// <summary>
        /// Yeni öğrenci-burs eşleştirmesi oluşturur.
        /// </summary>
        public OgrenciBurs Ekle(OgrenciBurs ogrenciBurs)
        {
            _context.OgrenciBurslar.Add(ogrenciBurs);
            _context.SaveChanges();
            return ogrenciBurs;
        }

        /// <summary>
        /// Öğrenci-burs eşleştirmesini günceller.
        /// </summary>
        public void Guncelle(OgrenciBurs ogrenciBurs)
        {
            _context.OgrenciBurslar.Update(ogrenciBurs);
            _context.SaveChanges();
        }

        /// <summary>
        /// Öğrenci-burs eşleştirmesini siler. İlişkili BursOdemeTakip kayıtlarını da siler.
        /// </summary>
        public void Sil(int id)
        {
            var ogrenciBurs = _context.OgrenciBurslar.Find(id);
            if (ogrenciBurs != null)
            {
                // Önce ilişkili BursOdemeTakip kayıtlarını sil
                var odemeTakipleri = _context.BursOdemeTakipleri
                    .Where(ot => ot.OgrenciBursId == id)
                    .ToList();
                
                _context.BursOdemeTakipleri.RemoveRange(odemeTakipleri);
                
                // Sonra OgrenciBurs kaydını sil
                _context.OgrenciBurslar.Remove(ogrenciBurs);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Belirli bir öğrencinin mevcut burs eşleştirmesini kontrol eder.
        /// </summary>
        public bool OgrenciBursAlmisMi(int ogrenciId)
        {
            return _context.OgrenciBurslar.Any(ob => ob.OgrenciId == ogrenciId && ob.Onaylandi);
        }

        /// <summary>
        /// Belirli bir burstan kaç öğrenci aldığını sayar (onaylanmış eşleştirmeler).
        /// </summary>
        public int BursaKayitliOgrenciSayisi(int bursId)
        {
            return _context.OgrenciBurslar.Count(ob => ob.BursId == bursId && ob.Onaylandi);
        }
    }
}

