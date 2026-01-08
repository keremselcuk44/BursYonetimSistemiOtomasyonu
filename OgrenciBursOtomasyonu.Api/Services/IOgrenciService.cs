using System.Collections.Generic;
using System.Threading.Tasks;
using OgrenciBursOtomasyonu.Api.Models;

namespace OgrenciBursOtomasyonu.Api.Services
{
    /// <summary>
    /// Öğrenci ile ilgili iş kurallarını içeren servis sözleşmesi.
    /// </summary>
    public interface IOgrenciService
    {
        Task<Ogrenci> BasvuruOlusturAsync(Ogrenci ogrenci);
        IReadOnlyList<Ogrenci> TumOgrencileriGetir();
        Ogrenci? Getir(int id);
        Ogrenci? TcVeyaEmailIleGetir(string? tcKimlikNo, string? email);
        Task<Ogrenci?> GuncelleGenelBilgilerAsync(int id, OgrenciGuncelleDto dto);
        Task<bool> SilAsync(int id);
    }
}




