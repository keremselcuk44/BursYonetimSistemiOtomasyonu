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
    /// Kişisel bilgileri düzenlenecek öğrencilerin listelendiği ekran.
    /// Sadece genel bilgiler düzenlenir, burs puanı ve analiz raporu burada gösterilmez.
    /// </summary>
    public partial class FrmOgrenciDuzenleListe : XtraForm
    {
        private readonly HttpClient _httpClient = new();

        public FrmOgrenciDuzenleListe()
        {
            InitializeComponent();
            Activated += FrmOgrenciDuzenleListe_Activated;
        }

        private async void FrmOgrenciDuzenleListe_Load(object sender, EventArgs e)
        {
            await OgrencileriYukleAsync();
        }

        private async void FrmOgrenciDuzenleListe_Activated(object sender, EventArgs e)
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
                    OgrenciyiDuzenle(row.Id);
                }
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            var row = gridView1.GetFocusedRow() as OgrenciDto;
            if (row == null || row.Id <= 0)
            {
                XtraMessageBox.Show("Lütfen listeden bir öğrenci seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OgrenciyiDuzenle(row.Id);
        }

        private void OgrenciyiDuzenle(int ogrenciId)
        {
            // Her zaman yeni bir düzenleme formu aç (id değişikliğini yansıtmak için)
            var frm = new FrmOgrenciDuzenle(ogrenciId) { MdiParent = MdiParent };
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}


