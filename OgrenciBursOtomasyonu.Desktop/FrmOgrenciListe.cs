using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace OgrenciBursOtomasyonu.Desktop
{
    /// <summary>
    /// Öğrencilerin listelendiği grid ekranı.
    /// Web API'den öğrenci listesi çekilir.
    /// </summary>
    public partial class FrmOgrenciListe : XtraForm
    {
        private readonly HttpClient _httpClient = new();

        public FrmOgrenciListe()
        {
            InitializeComponent();
            Activated += FrmOgrenciListe_Activated;
        }

        private async void FrmOgrenciListe_Load(object sender, EventArgs e)
        {
            await OgrencileriYukleAsync();
        }

        private async void FrmOgrenciListe_Activated(object sender, EventArgs e)
        {
            await OgrencileriYukleAsync();
        }

        private async Task OgrencileriYukleAsync()
        {
            try
            {
                var url = "http://localhost:5215/api/ogrenciler";
                var response = await _httpClient.GetAsync(url);
                
                if (response.IsSuccessStatusCode)
                {
                    var ogrenciListesi = await response.Content.ReadFromJsonAsync<List<OgrenciDto>>() 
                                         ?? new List<OgrenciDto>();
                    gridControl1.DataSource = ogrenciListesi;
                }
                else
                {
                    XtraMessageBox.Show($"API'den veri alınamadı. Durum: {response.StatusCode}", 
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridControl1.DataSource = new List<OgrenciDto>();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Bağlantı hatası: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gridControl1.DataSource = new List<OgrenciDto>();
            }
        }

        private async void btnYenile_Click(object sender, EventArgs e)
        {
            await OgrencileriYukleAsync();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2 && e.RowHandle >= 0)
            {
                var row = gridView1.GetRow(e.RowHandle) as OgrenciDto;
                if (row != null && row.Id > 0)
                {
                    // Her seferinde yeni detay formu aç (seçilen öğrenciye göre)
                    var frm = new FrmOgrenciDetay(row.Id) { MdiParent = MdiParent };
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                }
            }
        }

    }

    /// <summary>
    /// Masaüstü tarafında gridde kullanılacak basit DTO.
    /// </summary>
    public class OgrenciDto
    {
        public int Id { get; set; }
        public string TcKimlikNo { get; set; } = string.Empty;
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Yas { get; set; }
        public int Puan { get; set; }
        public string BursDurumu { get; set; } = string.Empty;
        public string BursAdi { get; set; } = string.Empty;
    }
}




