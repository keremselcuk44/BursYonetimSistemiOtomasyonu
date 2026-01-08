using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using OgrenciBursOtomasyonu.Api.Models;

namespace OgrenciBursOtomasyonu.Desktop
{
    /// <summary>
    /// Bursların listelendiği ve detaylarının gösterildiği form.
    /// Seçilen bursun detayları ve bu bursu alan öğrenciler gösterilir.
    /// </summary>
    public partial class FrmBursListe : XtraForm
    {
        private readonly HttpClient _httpClient = new();

        public FrmBursListe()
        {
            InitializeComponent();
            Activated += FrmBursListe_Activated;
        }

        private async void FrmBursListe_Load(object sender, EventArgs e)
        {
            await BurslariYukleAsync();
        }

        private async void FrmBursListe_Activated(object sender, EventArgs e)
        {
            await BurslariYukleAsync();
            
            // Eğer bir burs seçiliyse, öğrencileri de yenile
            var burs = gridViewBurslar.GetFocusedRow() as Burs;
            if (burs != null)
            {
                await OgrencileriYukleAsync(burs.Id);
            }
        }

        private async Task BurslariYukleAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://localhost:5215/api/burslar");
                if (response.IsSuccessStatusCode)
                {
                    var burslar = await response.Content.ReadFromJsonAsync<List<Burs>>()
                        ?? new List<Burs>();
                    gridControlBurslar.DataSource = burslar;
                }
                else
                {
                    XtraMessageBox.Show($"API'den veri alınamadı. Durum: {response.StatusCode}",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Bağlantı hatası: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void gridViewBurslar_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var burs = gridViewBurslar.GetFocusedRow() as Burs;
            if (burs == null)
                return;

            // Burs detaylarını göster
            lblBursAdi.Text = $"Burs Adı: {burs.BursAdi}";
            lblMinimumPuan.Text = $"Minimum Puan: {burs.MinimumPuan}";
            lblKontenjan.Text = $"Kontenjan: {burs.Kontenjan}";
            lblAylikTutar.Text = $"Aylık Tutar: {burs.AylikTutar:N2} TL";

            // Bu bursu alan öğrencileri yükle
            await OgrencileriYukleAsync(burs.Id);
        }

        private async Task OgrencileriYukleAsync(int bursId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://localhost:5215/api/ogrenciburslar/burs/{bursId}");
                if (response.IsSuccessStatusCode)
                {
                    var ogrenciler = await response.Content.ReadFromJsonAsync<List<BursOgrenciDto>>()
                        ?? new List<BursOgrenciDto>();
                    gridControlOgrenciler.DataSource = ogrenciler;
                    
                    lblOgrenciSayisi.Text = $"Bu Bursu Alan Öğrenci Sayısı: {ogrenciler.Count}";
                }
                else
                {
                    gridControlOgrenciler.DataSource = new List<BursOgrenciDto>();
                    lblOgrenciSayisi.Text = "Bu Bursu Alan Öğrenci Sayısı: 0";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Öğrenci bilgileri yüklenirken hata: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnYenile_Click(object sender, EventArgs e)
        {
            await BurslariYukleAsync();
            
            // Eğer bir burs seçiliyse, öğrencileri de yenile
            var burs = gridViewBurslar.GetFocusedRow() as Burs;
            if (burs != null)
            {
                await OgrencileriYukleAsync(burs.Id);
            }
        }

        private async void btnBursProgramindanCikar_Click(object sender, EventArgs e)
        {
            var ogrenci = gridViewOgrenciler.GetFocusedRow() as BursOgrenciDto;
            if (ogrenci == null || ogrenci.OgrenciBursId == 0)
            {
                XtraMessageBox.Show("Lütfen bir öğrenci seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mevcut bursu al
            var burs = gridViewBurslar.GetFocusedRow() as Burs;
            if (burs == null)
            {
                XtraMessageBox.Show("Lütfen bir burs seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var onay = XtraMessageBox.Show(
                    $"{ogrenci.Ad} {ogrenci.Soyad} öğrencisini {burs.BursAdi} burs programından çıkarmak istediğinize emin misiniz?\n\nÖğrenciye mail gönderilecektir.",
                    "Burs Programından Çıkarma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (onay != DialogResult.Yes)
                    return;

                // DELETE işlemini yap
                var deleteResponse = await _httpClient.DeleteAsync($"http://localhost:5215/api/ogrenciburslar/{ogrenci.OgrenciBursId}");
                
                if (deleteResponse.IsSuccessStatusCode || deleteResponse.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    XtraMessageBox.Show("Öğrenci burs programından çıkarıldı. Öğrenciye mail gönderildi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Listeyi yenile
                    await OgrencileriYukleAsync(burs.Id);
                }
                else
                {
                    var hataMesaji = await deleteResponse.Content.ReadAsStringAsync();
                    XtraMessageBox.Show($"Burs programından çıkarma hatası: {hataMesaji}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Burs programından çıkarma hatası: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void gridViewBurslar_DoubleClick(object sender, EventArgs e)
        {
            var burs = gridViewBurslar.GetFocusedRow() as Burs;
            if (burs != null)
            {
                using (var frm = new FrmBursTanimla(burs.Id))
                {
                    frm.ShowDialog();
                }
                await BurslariYukleAsync();
            }
        }

        private async void btnBursDuzenle_Click(object sender, EventArgs e)
        {
            var burs = gridViewBurslar.GetFocusedRow() as Burs;
            if (burs == null)
            {
                XtraMessageBox.Show("Lütfen düzenlemek istediğiniz bir burs seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var frm = new FrmBursTanimla(burs.Id))
            {
                frm.ShowDialog();
            }
            await BurslariYukleAsync();
        }
    }

    /// <summary>
    /// Burs alan öğrenci DTO.
    /// </summary>
    public class BursOgrenciDto
    {
        public int OgrenciBursId { get; set; } // DELETE işlemi için gerekli
        public int Id { get; set; }
        public string TcKimlikNo { get; set; } = string.Empty;
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;
        public int Puan { get; set; }
        public string Universite { get; set; } = string.Empty;
        public string Bolum { get; set; } = string.Empty;
    }
}

