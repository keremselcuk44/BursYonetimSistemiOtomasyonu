using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OgrenciBursOtomasyonu.Api.Models;

namespace OgrenciBursOtomasyonu.Api.Data
{
    /// <summary>
    /// Burs ödeme takibini yöneten repository sınıfı.
    /// </summary>
    public class BursOdemeTakipRepository
    {
        private readonly ApplicationDbContext _context;

        public BursOdemeTakipRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Belirli bir öğrenci-burs eşleştirmesi için ödeme takiplerini getirir.
        /// </summary>
        public IReadOnlyList<BursOdemeTakip> OgrenciBursaGoreGetir(int ogrenciBursId)
        {
            return _context.BursOdemeTakipleri
                .Where(ot => ot.OgrenciBursId == ogrenciBursId)
                .OrderByDescending(ot => ot.Yil)
                .ThenByDescending(ot => ot.Ay)
                .ToList();
        }

        /// <summary>
        /// Belirli bir ay-yıl için ödeme kaydını getirir.
        /// </summary>
        public BursOdemeTakip? Getir(int ogrenciBursId, int ay, int yil)
        {
            return _context.BursOdemeTakipleri
                .FirstOrDefault(ot => ot.OgrenciBursId == ogrenciBursId && ot.Ay == ay && ot.Yil == yil);
        }

        /// <summary>
        /// Yeni ödeme takip kaydı oluşturur veya günceller.
        /// </summary>
        public BursOdemeTakip OdemeOnayla(int ogrenciBursId, int ay, int yil)
        {
            var mevcut = Getir(ogrenciBursId, ay, yil);
            if (mevcut != null)
            {
                mevcut.OdendiMi = true;
                mevcut.OdemeTarihi = DateTime.Now;
                _context.BursOdemeTakipleri.Update(mevcut);
                _context.SaveChanges();
                return mevcut;
            }
            else
            {
                var yeni = new BursOdemeTakip
                {
                    OgrenciBursId = ogrenciBursId,
                    Ay = ay,
                    Yil = yil,
                    OdendiMi = true,
                    OdemeTarihi = DateTime.Now
                };
                _context.BursOdemeTakipleri.Add(yeni);
                _context.SaveChanges();
                return yeni;
            }
        }

        /// <summary>
        /// Ödeme kaydını iptal eder.
        /// </summary>
        public void OdemeIptal(int ogrenciBursId, int ay, int yil)
        {
            var mevcut = Getir(ogrenciBursId, ay, yil);
            if (mevcut != null)
            {
                mevcut.OdendiMi = false;
                mevcut.OdemeTarihi = null;
                _context.BursOdemeTakipleri.Update(mevcut);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Belirli bir öğrenci-burs eşleştirmesi için ödenen toplam tutarı hesaplar.
        /// </summary>
        public decimal ToplamOdenenTutar(int ogrenciBursId)
        {
            var odemeSayisi = _context.BursOdemeTakipleri.Count(ot => ot.OgrenciBursId == ogrenciBursId && ot.OdendiMi);
            
            // OgrenciBurs ve Burs bilgilerini al
            var ogrenciBurs = _context.OgrenciBurslar
                .Include(ob => ob.Burs)
                .FirstOrDefault(ob => ob.Id == ogrenciBursId);

            if (ogrenciBurs?.Burs == null)
                return 0;

            return odemeSayisi * ogrenciBurs.Burs.AylikTutar;
        }
    }
}

