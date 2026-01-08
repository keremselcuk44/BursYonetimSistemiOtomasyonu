using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OgrenciBursOtomasyonu.Api.Data;
using OgrenciBursOtomasyonu.Api.Models;
using OgrenciBursOtomasyonu.Api.Services;

namespace OgrenciBursOtomasyonu.Api
{
    /// <summary>
    /// Öğrenci kayıt işlemini ve Gemini puanlamasını yöneten servis.
    /// </summary>
    public class OgrenciService : IOgrenciService
    {
        private readonly IGeminiPuanlamaService _geminiPuanlamaService;
        private readonly OgrenciRepository _ogrenciRepository;
        private readonly ApplicationDbContext _context;

        public OgrenciService(IGeminiPuanlamaService geminiPuanlamaService, OgrenciRepository ogrenciRepository, ApplicationDbContext context)
        {
            _geminiPuanlamaService = geminiPuanlamaService;
            _ogrenciRepository = ogrenciRepository;
            _context = context;
        }

        public async Task<Ogrenci> BasvuruOlusturAsync(Ogrenci ogrenci)
        {
            // İlk kayıtta puan 0 ve rapor boş
            ogrenci.Puan = 0;
            ogrenci.AiRaporu = string.Empty;

            // Önce öğrenci kaydını SQL Server'a kaydet
            var kaydedilen = _ogrenciRepository.Ekle(ogrenci);

            try
            {
                // Ardından Gemini'den puan ve rapor iste
                var (puan, rapor) = await _geminiPuanlamaService.PuanHesaplaVeRaporOlusturAsync(kaydedilen);
                kaydedilen.Puan = puan;
                kaydedilen.AiRaporu = rapor;

                // Puan ve raporu veritabanına güncelle
                _ogrenciRepository.Guncelle(kaydedilen);
            }
            catch (Exception ex)
            {
                // Gemini API hatası durumunda öğrenci kaydı yine de kaydedilir
                // Ancak puan 0 ve rapor hata mesajı olarak kaydedilir
                kaydedilen.Puan = 0;
                kaydedilen.AiRaporu = $"AI analizi yapılamadı: {ex.Message}";
                _ogrenciRepository.Guncelle(kaydedilen);
                
                // Hatayı yukarı fırlat ki controller'da yakalanabilsin
                throw new Exception($"Gemini API hatası: {ex.Message}", ex);
            }

            return kaydedilen;
        }

        public IReadOnlyList<Ogrenci> TumOgrencileriGetir()
        {
            return _ogrenciRepository.TumOgrencileriGetir();
        }

        public Ogrenci? Getir(int id)
        {
            return _ogrenciRepository.Getir(id);
        }

        public Ogrenci? TcVeyaEmailIleGetir(string? tcKimlikNo, string? email)
        {
            return _ogrenciRepository.TcVeyaEmailIleGetir(tcKimlikNo, email);
        }

        /// <summary>
        /// Öğrencinin genel bilgilerini günceller. Puan, klasik sorular ve AI raporuna dokunulmaz.
        /// </summary>
        public Task<Ogrenci?> GuncelleGenelBilgilerAsync(int id, OgrenciGuncelleDto dto)
        {
            // Şu an için işlem tamamen senkron; imzayı bozmamak için Task sonucuna sarıyoruz.
            var ogrenci = _ogrenciRepository.Getir(id);
            if (ogrenci == null)
                return Task.FromResult<Ogrenci?>(null);

            ogrenci.Ad = dto.Ad;
            ogrenci.Soyad = dto.Soyad;
            ogrenci.Universite = dto.Universite;
            ogrenci.Bolum = dto.Bolum;
            ogrenci.Sinif = dto.Sinif;
            ogrenci.Yas = dto.Yas;
            ogrenci.Email = dto.Email;
            ogrenci.Telefon = dto.Telefon;
            ogrenci.Iban = dto.Iban;
            ogrenci.ResimYolu = dto.ResimYolu;

            _ogrenciRepository.Guncelle(ogrenci);
            return Task.FromResult<Ogrenci?>(ogrenci);
        }

        /// <summary>
        /// Öğrenciyi ve tüm ilişkili kayıtlarını (BursOdemeTakip, OgrenciBurs) siler.
        /// </summary>
        public async Task<bool> SilAsync(int id)
        {
            var ogrenci = _ogrenciRepository.Getir(id);
            if (ogrenci == null)
                return false;

            // Önce bu öğrenciye ait tüm OgrenciBurs kayıtlarını bul
            var ogrenciBurslar = _context.OgrenciBurslar
                .Where(ob => ob.OgrenciId == id)
                .ToList();

            // Her OgrenciBurs kaydı için BursOdemeTakip kayıtlarını sil
            foreach (var ogrenciBurs in ogrenciBurslar)
            {
                var odemeTakipleri = _context.BursOdemeTakipleri
                    .Where(ot => ot.OgrenciBursId == ogrenciBurs.Id)
                    .ToList();
                
                _context.BursOdemeTakipleri.RemoveRange(odemeTakipleri);
            }

            // OgrenciBurs kayıtlarını sil
            _context.OgrenciBurslar.RemoveRange(ogrenciBurslar);

            // Öğrenciyi sil
            _context.Ogrenciler.Remove(ogrenci);

            // Tüm değişiklikleri tek seferde kaydet
            await _context.SaveChangesAsync();

            return true;
        }
    }
}




