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
    /// Kullanıcı listeleme, ekleme, güncelleme ve silme işlemleri için form.
    /// </summary>
    public partial class FrmKullaniciIslemleri : XtraForm
    {
        private readonly HttpClient _httpClient = new();
        private List<KullaniciDto> _kullanicilar = new();
        private KullaniciDto _seciliKullanici;

        public FrmKullaniciIslemleri()
        {
            InitializeComponent();
        }

        private async void FrmKullaniciIslemleri_Load(object sender, EventArgs e)
        {
            await KullanicilariYukleAsync();
        }

        private async void FrmKullaniciIslemleri_Activated(object sender, EventArgs e)
        {
            await KullanicilariYukleAsync();
        }

        private async Task KullanicilariYukleAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://localhost:5215/api/kullanicilar");
                response.EnsureSuccessStatusCode();

                var liste = await response.Content.ReadFromJsonAsync<List<KullaniciDto>>();
                _kullanicilar = liste ?? new List<KullaniciDto>();
                gridControlKullanicilar.DataSource = _kullanicilar;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Kullanıcı listesi yüklenemedi: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Embedded kullanım (MainForm module view) için dışarıdan liste yenileme imkanı sağlar.
        /// </summary>
        public Task RefreshKullanicilarAsync()
        {
            return KullanicilariYukleAsync();
        }

        private void gridViewKullanicilar_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _seciliKullanici = gridViewKullanicilar.GetFocusedRow() as KullaniciDto;
            if (_seciliKullanici != null)
            {
                txtKullaniciAdi.Text = _seciliKullanici.KullaniciAdi;
                chkAktif.Checked = _seciliKullanici.Aktif;
                txtYeniSifre.Text = string.Empty;
                txtOlusturmaTarihi.Text = _seciliKullanici.OlusturmaTarihi.ToString("dd.MM.yyyy HH:mm");
                btnSil.Enabled = true;
            }
            else
            {
                btnSil.Enabled = false;
            }
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            // Validasyon
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text))
            {
                XtraMessageBox.Show("Kullanıcı adı zorunludur.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKullaniciAdi.Focus();
                return;
            }

            if (_seciliKullanici == null)
            {
                // Yeni kullanıcı oluşturma
                if (string.IsNullOrWhiteSpace(txtYeniSifre.Text))
                {
                    XtraMessageBox.Show("Yeni kullanıcı için şifre zorunludur.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtYeniSifre.Focus();
                    return;
                }

                await YeniKullaniciOlusturAsync();
            }
            else
            {
                // Kullanıcı güncelleme
                await KullaniciGuncelleAsync();
            }
        }

        private async Task YeniKullaniciOlusturAsync()
        {
            try
            {
                var dto = new KullaniciCreateDtoDesktop
                {
                    KullaniciAdi = txtKullaniciAdi.Text.Trim(),
                    Sifre = txtYeniSifre.Text,
                    Aktif = chkAktif.Checked
                };

                var response = await _httpClient.PostAsJsonAsync("http://localhost:5215/api/kullanicilar", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var hata = await response.Content.ReadAsStringAsync();
                    XtraMessageBox.Show($"Kullanıcı kaydedilemedi:\n{hata}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                XtraMessageBox.Show("Kullanıcı başarıyla eklendi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await KullanicilariYukleAsync();
                btnYeni_Click(null, null); // Formu temizle
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Kullanıcı kaydedilirken hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task KullaniciGuncelleAsync()
        {
            try
            {
                var dto = new KullaniciUpdateDtoDesktop
                {
                    KullaniciAdi = txtKullaniciAdi.Text.Trim(),
                    YeniSifre = txtYeniSifre.Text,
                    Aktif = chkAktif.Checked
                };

                var url = $"http://localhost:5215/api/kullanicilar/{_seciliKullanici.Id}";
                var response = await _httpClient.PutAsJsonAsync(url, dto);
                if (!response.IsSuccessStatusCode)
                {
                    var hata = await response.Content.ReadAsStringAsync();
                    XtraMessageBox.Show($"Kullanıcı güncellenemedi:\n{hata}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                XtraMessageBox.Show("Kullanıcı başarıyla güncellendi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await KullanicilariYukleAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Kullanıcı güncellenirken hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            _seciliKullanici = null;
            txtKullaniciAdi.Text = string.Empty;
            txtYeniSifre.Text = string.Empty;
            chkAktif.Checked = true;
            txtOlusturmaTarihi.Text = string.Empty;
            btnSil.Enabled = false;
            gridViewKullanicilar.ClearSelection();
        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            if (_seciliKullanici == null)
            {
                XtraMessageBox.Show("Lütfen silmek istediğiniz bir kullanıcı seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = XtraMessageBox.Show(
                $"'{_seciliKullanici.KullaniciAdi}' kullanıcısını silmek istediğinizden emin misiniz?\n\n" +
                "Bu işlem geri alınamaz.",
                "Kullanıcı Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
                return;

            try
            {
                var url = $"http://localhost:5215/api/kullanicilar/{_seciliKullanici.Id}";
                var response = await _httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    XtraMessageBox.Show("Kullanıcı başarıyla silindi.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await KullanicilariYukleAsync();
                    btnYeni_Click(null, null); // Formu temizle
                }
                else
                {
                    var hata = await response.Content.ReadAsStringAsync();
                    XtraMessageBox.Show($"Kullanıcı silinemedi:\n{hata}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Silme işlemi sırasında hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnYenile_Click(object sender, EventArgs e)
        {
            await KullanicilariYukleAsync();
        }
    }

    /// <summary>
    /// Grid için kullanıcı DTO'su (API anonim tipine karşılık).
    /// </summary>
    public class KullaniciDto
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; } = string.Empty;
        public bool Aktif { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
    }

    public class KullaniciCreateDtoDesktop
    {
        public string KullaniciAdi { get; set; } = string.Empty;
        public string Sifre { get; set; } = string.Empty;
        public bool Aktif { get; set; }
    }

    public class KullaniciUpdateDtoDesktop
    {
        public string KullaniciAdi { get; set; } = string.Empty;
        public string YeniSifre { get; set; } = string.Empty;
        public bool Aktif { get; set; }
    }
}
