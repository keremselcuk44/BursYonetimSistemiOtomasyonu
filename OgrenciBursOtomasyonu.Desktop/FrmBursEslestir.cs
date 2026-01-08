using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace OgrenciBursOtomasyonu.Desktop
{
    /// <summary>
    /// Öğrenci-Burs eşleştirme formu.
    /// Uygun bursları öğrencilerle eşleştirme yapılır.
    /// </summary>
    public partial class FrmBursEslestir : XtraForm
    {
        private readonly HttpClient _httpClient = new();

        public FrmBursEslestir()
        {
            InitializeComponent();
            Activated += FrmBursEslestir_Activated;
            GridViewlariYapilandir();
        }

        private void GridViewlariYapilandir()
        {
            // Öğrenci GridView kolonlarını yapılandır
            gridViewOgrenciler.Columns.Clear();
            var colOgrenciId = gridViewOgrenciler.Columns.AddField("Id");
            colOgrenciId.Caption = "ID";
            colOgrenciId.Visible = false;

            var colOgrenciAd = gridViewOgrenciler.Columns.AddField("Ad");
            colOgrenciAd.Caption = "Ad";
            colOgrenciAd.VisibleIndex = 0;
            colOgrenciAd.Width = 120;

            var colOgrenciSoyad = gridViewOgrenciler.Columns.AddField("Soyad");
            colOgrenciSoyad.Caption = "Soyad";
            colOgrenciSoyad.VisibleIndex = 1;
            colOgrenciSoyad.Width = 120;

            var colOgrenciTc = gridViewOgrenciler.Columns.AddField("TcKimlikNo");
            colOgrenciTc.Caption = "TC Kimlik No";
            colOgrenciTc.VisibleIndex = 2;
            colOgrenciTc.Width = 120;

            var colOgrenciEmail = gridViewOgrenciler.Columns.AddField("Email");
            colOgrenciEmail.Caption = "E-posta";
            colOgrenciEmail.VisibleIndex = 3;
            colOgrenciEmail.Width = 200;

            var colOgrenciPuan = gridViewOgrenciler.Columns.AddField("Puan");
            colOgrenciPuan.Caption = "Puan";
            colOgrenciPuan.VisibleIndex = 4;
            colOgrenciPuan.Width = 80;
            colOgrenciPuan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colOgrenciPuan.DisplayFormat.FormatString = "N0";

            // Burs GridView kolonlarını yapılandır
            gridViewBurslar.Columns.Clear();
            var colBursId = gridViewBurslar.Columns.AddField("Id");
            colBursId.Caption = "ID";
            colBursId.Visible = false;

            var colBursAdi = gridViewBurslar.Columns.AddField("BursAdi");
            colBursAdi.Caption = "Burs Adı";
            colBursAdi.VisibleIndex = 0;
            colBursAdi.Width = 200;

            var colMinimumPuan = gridViewBurslar.Columns.AddField("MinimumPuan");
            colMinimumPuan.Caption = "Minimum Puan";
            colMinimumPuan.VisibleIndex = 1;
            colMinimumPuan.Width = 120;
            colMinimumPuan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colMinimumPuan.DisplayFormat.FormatString = "N0";

            var colKontenjan = gridViewBurslar.Columns.AddField("Kontenjan");
            colKontenjan.Caption = "Kontenjan";
            colKontenjan.VisibleIndex = 2;
            colKontenjan.Width = 100;
            colKontenjan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colKontenjan.DisplayFormat.FormatString = "N0";

            var colAylikTutar = gridViewBurslar.Columns.AddField("AylikTutar");
            colAylikTutar.Caption = "Aylık Tutar";
            colAylikTutar.VisibleIndex = 3;
            colAylikTutar.Width = 150;
            colAylikTutar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colAylikTutar.DisplayFormat.FormatString = "C2";
        }

        private async void FrmBursEslestir_Load(object sender, EventArgs e)
        {
            await YukleAsync();
        }

        private async void FrmBursEslestir_Activated(object sender, EventArgs e)
        {
            await YukleAsync();
        }

        private async Task YukleAsync()
        {
            try
            {
                // Öğrencileri yükle
                var ogrenciResponse = await _httpClient.GetAsync("http://localhost:5215/api/ogrenciler");
                if (ogrenciResponse.IsSuccessStatusCode)
                {
                    var ogrenciler = await ogrenciResponse.Content.ReadFromJsonAsync<List<OgrenciDto>>()
                        ?? new List<OgrenciDto>();
                    
                    // Burs almayan öğrencileri filtrele
                    var bursAlmayanOgrenciler = ogrenciler.Where(o => o.BursDurumu != "Burs alıyor").ToList();
                    gridControlOgrenciler.DataSource = bursAlmayanOgrenciler;
                }

                // Bursları yükle
                var bursResponse = await _httpClient.GetAsync("http://localhost:5215/api/burslar");
                if (bursResponse.IsSuccessStatusCode)
                {
                    var burslar = await bursResponse.Content.ReadFromJsonAsync<List<BursDto>>()
                        ?? new List<BursDto>();
                    gridControlBurslar.DataSource = burslar;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Veri yükleme hatası: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEslestir_Click(object sender, EventArgs e)
        {
            var ogrenci = gridViewOgrenciler.GetFocusedRow() as OgrenciDto;
            var burs = gridViewBurslar.GetFocusedRow() as BursDto;

            if (ogrenci == null)
            {
                XtraMessageBox.Show("Lütfen bir öğrenci seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (burs == null)
            {
                XtraMessageBox.Show("Lütfen bir burs seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Puan kontrolü
            if (ogrenci.Puan < burs.MinimumPuan)
            {
                XtraMessageBox.Show(
                    $"Öğrencinin puanı ({ogrenci.Puan}) bu bursun minimum puanından ({burs.MinimumPuan}) düşük.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kontenjan kontrolü (API'den mevcut öğrenci sayısını al)
            try
            {
                var kontenjanResponse = await _httpClient.GetAsync($"http://localhost:5215/api/ogrenciburslar/burs/{burs.Id}");
                if (kontenjanResponse.IsSuccessStatusCode)
                {
                    var mevcutOgrenciler = await kontenjanResponse.Content.ReadFromJsonAsync<List<object>>() ?? new List<object>();
                    if (mevcutOgrenciler.Count >= burs.Kontenjan)
                    {
                        XtraMessageBox.Show(
                            $"Bu bursun kontenjanı dolmuş.\nKontenjan: {burs.Kontenjan}\nMevcut öğrenci sayısı: {mevcutOgrenciler.Count}",
                            "Kontenjan Dolu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch
            {
                // Kontenjan kontrolü başarısız olsa bile devam et, API tarafında kontrol edilecek
            }

            // Eşleştirme onayı
            var onay = XtraMessageBox.Show(
                $"{ogrenci.Ad} {ogrenci.Soyad} öğrencisini {burs.BursAdi} bursu ile eşleştirmek istiyor musunuz?",
                "Eşleştirme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay != DialogResult.Yes)
                return;

            try
            {
                // Eşleştirme yap
                var eslestirmeDto = new
                {
                    OgrenciId = ogrenci.Id,
                    BursId = burs.Id,
                    Onaylandi = true // Direkt onayla
                };

                var response = await _httpClient.PostAsJsonAsync(
                    "http://localhost:5215/api/ogrenciburslar", eslestirmeDto);

                if (response.IsSuccessStatusCode)
                {
                    XtraMessageBox.Show("Eşleştirme başarıyla yapıldı.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await YukleAsync(); // Listeyi yenile
                }
                else
                {
                    var hataMesajiJson = await response.Content.ReadAsStringAsync();
                    // JSON'dan message alanını parse et
                    var hataMesaji = hataMesajiJson;
                    try
                    {
                        // Basit JSON parse ({"message":"..."} formatı için)
                        if (hataMesajiJson.Contains("\"message\""))
                        {
                            var startIndex = hataMesajiJson.IndexOf("\"message\"") + 11;
                            var endIndex = hataMesajiJson.IndexOf("\"", startIndex);
                            if (endIndex > startIndex)
                            {
                                hataMesaji = hataMesajiJson.Substring(startIndex, endIndex - startIndex);
                            }
                        }
                    }
                    catch { }
                    
                    XtraMessageBox.Show($"Eşleştirme hatası: {hataMesaji}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Eşleştirme hatası: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            _ = YukleAsync();
        }
    }

    /// <summary>
    /// Burs DTO.
    /// </summary>
    public class BursDto
    {
        public int Id { get; set; }
        public string BursAdi { get; set; } = string.Empty;
        public int MinimumPuan { get; set; }
        public int Kontenjan { get; set; }
        public decimal AylikTutar { get; set; }
    }
}

