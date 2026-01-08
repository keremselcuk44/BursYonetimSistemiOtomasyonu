using System.Threading.Tasks;
using OgrenciBursOtomasyonu.Api.Models;

namespace OgrenciBursOtomasyonu.Api.Services
{
    /// <summary>
    /// Gemini API kullanarak öğrencinin burs puanını hesaplayan ve özet rapor oluşturan servis sözleşmesi.
    /// </summary>
    public interface IGeminiPuanlamaService
    {
        Task<(int Puan, string Rapor)> PuanHesaplaVeRaporOlusturAsync(Ogrenci ogrenci);
        Task<List<string>> GetAvailableModelsAsync();
    }
}




