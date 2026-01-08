using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OgrenciBursOtomasyonu.Api.Models;

namespace OgrenciBursOtomasyonu.Desktop
{
    /// <summary>
    /// Öğrencinin genel bilgilerini ve fotoğrafını düzenlemek için form.
    /// </summary>
    public partial class FrmOgrenciDuzenle : XtraForm
    {
        private readonly HttpClient _httpClient = new();
        private readonly int _ogrenciId;
        private string _mevcutResimBase64 = string.Empty;

        public FrmOgrenciDuzenle(int ogrenciId)
        {
            _ogrenciId = ogrenciId;
            InitializeComponent();
            Activated += FrmOgrenciDuzenle_Activated;
        }

        private async void FrmOgrenciDuzenle_Load(object sender, EventArgs e)
        {
            await OgrenciyiYukleAsync();
        }

        private async void FrmOgrenciDuzenle_Activated(object sender, EventArgs e)
        {
            await OgrenciyiYukleAsync();
        }

        private async Task OgrenciyiYukleAsync()
        {
            try
            {
                var url = $"http://localhost:5215/api/ogrenciler/{_ogrenciId}";
                var ogrenci = await _httpClient.GetFromJsonAsync<Ogrenci>(url);
                if (ogrenci == null)
                {
                    XtraMessageBox.Show("Öğrenci bulunamadı.", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                txtTc.Text = ogrenci.TcKimlikNo;
                txtAd.Text = ogrenci.Ad;
                txtSoyad.Text = ogrenci.Soyad;
                txtYas.Text = ogrenci.Yas > 0 ? ogrenci.Yas.ToString() : "";
                txtUniversite.Text = ogrenci.Universite;
                txtBolum.Text = ogrenci.Bolum;
                txtSinif.Text = ogrenci.Sinif;
                txtEmail.Text = ogrenci.Email;
                txtTelefon.Text = ogrenci.Telefon;
                txtIban.Text = ogrenci.Iban;

                _mevcutResimBase64 = ogrenci.ResimYolu;
                ResmiGoster(_mevcutResimBase64);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Bağlantı hatası: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResmiGoster(string resimBase64)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(resimBase64))
                {
                    pictureEditResim.Image = null;
                    return;
                }

                string base64Data = resimBase64;
                if (resimBase64.StartsWith("data:image"))
                {
                    base64Data = resimBase64.Split(',')[1];
                }

                var bytes = Convert.FromBase64String(base64Data);
                using (var ms = new System.IO.MemoryStream(bytes))
                {
                    pictureEditResim.Image = System.Drawing.Image.FromStream(ms);
                }
            }
            catch
            {
                pictureEditResim.Image = null;
            }
        }

        private async void btnFotoYukle_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var bytes = System.IO.File.ReadAllBytes(ofd.FileName);
                _mevcutResimBase64 = Convert.ToBase64String(bytes);
                ResmiGoster(_mevcutResimBase64);

                // Fotoğraf yüklendiğinde veritabanına da hemen kaydet
                await OgrenciyiGuncelleAsync(gorselDegisti: true);
            }
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var basarili = await OgrenciyiGuncelleAsync();
                if (basarili)
                {
                    XtraMessageBox.Show("Öğrenci bilgileri güncellendi.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Güncelleme sırasında hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Form üzerindeki alanlara göre öğrenciyi API üzerinden günceller.
        /// </summary>
        private async Task<bool> OgrenciyiGuncelleAsync(bool gorselDegisti = false)
        {
            var dto = new
            {
                Ad = txtAd.Text.Trim(),
                Soyad = txtSoyad.Text.Trim(),
                Yas = int.TryParse(txtYas.Text.Trim(), out int yas) ? yas : 0,
                Universite = txtUniversite.Text.Trim(),
                Bolum = txtBolum.Text.Trim(),
                Sinif = txtSinif.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Telefon = txtTelefon.Text.Trim(),
                Iban = txtIban.Text.Trim(),
                ResimYolu = _mevcutResimBase64
            };

            var url = $"http://localhost:5215/api/ogrenciler/{_ogrenciId}";
            var response = await _httpClient.PutAsJsonAsync(url, dto);
            if (!response.IsSuccessStatusCode)
            {
                var hata = await response.Content.ReadAsStringAsync();
                var mesajBaslik = gorselDegisti ? "Fotoğraf güncellenemedi" : "Öğrenci güncellenemedi";
                XtraMessageBox.Show($"{mesajBaslik}:\n{hata}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Fotoğraf değiştiyse kullanıcıya ekstra bilgi verebiliriz
            if (gorselDegisti)
            {
                XtraMessageBox.Show("Fotoğraf başarıyla güncellendi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return true;
        }

    }
}


