using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OgrenciBursOtomasyonu.Desktop.Views.Common;

namespace OgrenciBursOtomasyonu.Desktop
{
    /// <summary>
    /// Uygulama açılışında kullanıcı girişi alınan form.
    /// </summary>
    public partial class FrmGiris : XtraForm
    {
        private readonly HttpClient _httpClient = new();

        public FrmGiris()
        {
            // Logo artık proje resource'undan geldiği için ek bir yükleme yapmamıza gerek yok
            InitializeComponent();
        }

        private async void btnGiris_Click(object sender, EventArgs e)
        {
            await GirisYapAsync();
        }

        private void chkSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            txtSifre.Properties.PasswordChar = chkSifreGoster.Checked ? '\0' : '•';
            txtSifre.Refresh();
        }

        private void txtKullaniciAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSifre.Focus();
                e.Handled = true;
            }
        }

        private async void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await GirisYapAsync();
                e.Handled = true;
            }
        }

        private async Task GirisYapAsync()
        {
            try
            {
                btnGiris.Enabled = false;

                var request = new LoginRequestDto
                {
                    KullaniciAdi = txtKullaniciAdi.Text.Trim(),
                    Sifre = txtSifre.Text
                };

                var response = await _httpClient.PostAsJsonAsync("http://localhost:5215/api/kullanicilar/login", request);
                if (!response.IsSuccessStatusCode)
                {
                    var mesaj = await response.Content.ReadAsStringAsync();
                    XtraMessageBox.Show($"Giriş başarısız.\n{mesaj}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var sonuc = await response.Content.ReadFromJsonAsync<LoginResponseDto>();
                if (sonuc == null || !sonuc.Basarili)
                {
                    XtraMessageBox.Show(sonuc?.Mesaj ?? "Giriş doğrulanamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UserSession.SetKullanici(sonuc.KullaniciAdi);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Bağlantı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGiris.Enabled = true;
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

