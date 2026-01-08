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
    /// Yeni burs tanımı yapılmasını veya mevcut burs düzenlenmesini sağlayan form.
    /// </summary>
    public partial class FrmBursTanimla : XtraForm
    {
        private readonly HttpClient _httpClient = new();
        private readonly int? _bursId;
        private bool _duzenlemeModu => _bursId.HasValue;

        public FrmBursTanimla()
        {
            InitializeComponent();
            Text = "Burs Tanımla";
            labelControlBaslik.Text = "BURS TANIMLA";
        }

        public FrmBursTanimla(int bursId) : this()
        {
            // bursId > 0 ise düzenleme modu, 0 veya altı ise yeni kayıt
            if (bursId > 0)
            {
                _bursId = bursId;
                Text = "Burs Düzenle";
                labelControlBaslik.Text = "BURS DÜZENLE";
            }
            else
            {
                _bursId = null;
                Text = "Burs Tanımla";
                labelControlBaslik.Text = "BURS TANIMLA";
            }
            Activated += FrmBursTanimla_Activated;
        }

        private async void FrmBursTanimla_Load(object sender, EventArgs e)
        {
            if (_duzenlemeModu)
            {
                await BursuYukleAsync(_bursId!.Value);
            }
            else
            {
                // Varsayılan değerleri ayarla
                chkAktifMi.Checked = true;
                cmbOdemePeriyodu.EditValue = "Aylık";
            }
        }

        private async void FrmBursTanimla_Activated(object sender, EventArgs e)
        {
            if (_duzenlemeModu)
            {
                await BursuYukleAsync(_bursId!.Value);
            }
        }

        private async Task BursuYukleAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://localhost:5215/api/burslar/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var burs = await response.Content.ReadFromJsonAsync<Burs>();
                    if (burs != null)
                    {
                        txtBursAdi.Text = burs.BursAdi;
                        cmbBursTipi.EditValue = burs.BursTipi;
                        memoAciklama.Text = burs.Aciklama;
                        spinMinimumPuan.Value = burs.MinimumPuan;
                        spinKontenjan.Value = burs.Kontenjan;
                        spinAylikTutar.Value = burs.AylikTutar;
                        cmbOdemePeriyodu.EditValue = string.IsNullOrWhiteSpace(burs.OdemePeriyodu) ? "Aylık" : burs.OdemePeriyodu;
                        
                        if (burs.BaslangicTarihi.HasValue)
                            dateBaslangicTarihi.EditValue = burs.BaslangicTarihi.Value;
                        else
                            dateBaslangicTarihi.EditValue = null;

                        if (burs.BitisTarihi.HasValue)
                            dateBitisTarihi.EditValue = burs.BitisTarihi.Value;
                        else
                            dateBitisTarihi.EditValue = null;

                        chkAktifMi.Checked = burs.AktifMi;
                        memoKosullar.Text = burs.Kosullar;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Burs bilgileri yüklenemedi.", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Bağlantı hatası: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            // Validasyon
            if (string.IsNullOrWhiteSpace(txtBursAdi.Text))
            {
                XtraMessageBox.Show("Burs adı zorunludur.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBursAdi.Focus();
                return;
            }

            if (spinMinimumPuan.Value < 0 || spinMinimumPuan.Value > 100)
            {
                XtraMessageBox.Show("Minimum puan 0-100 arasında olmalıdır.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spinMinimumPuan.Focus();
                return;
            }

            if (spinKontenjan.Value < 1)
            {
                XtraMessageBox.Show("Kontenjan en az 1 olmalıdır.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spinKontenjan.Focus();
                return;
            }

            if (spinAylikTutar.Value <= 0)
            {
                XtraMessageBox.Show("Aylık tutar 0'dan büyük olmalıdır.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spinAylikTutar.Focus();
                return;
            }

            // Başlangıç tarihi bitiş tarihinden sonra olamaz
            if (dateBaslangicTarihi.EditValue != null && dateBitisTarihi.EditValue != null)
            {
                var baslangic = (DateTime)dateBaslangicTarihi.EditValue;
                var bitis = (DateTime)dateBitisTarihi.EditValue;
                if (baslangic > bitis)
                {
                    XtraMessageBox.Show("Başlangıç tarihi bitiş tarihinden sonra olamaz.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                var burs = new Burs
                {
                    BursAdi = txtBursAdi.Text.Trim(),
                    BursTipi = cmbBursTipi.EditValue?.ToString() ?? string.Empty,
                    Aciklama = memoAciklama.Text.Trim(),
                    MinimumPuan = (int)spinMinimumPuan.Value,
                    Kontenjan = (int)spinKontenjan.Value,
                    AylikTutar = (decimal)spinAylikTutar.Value,
                    OdemePeriyodu = cmbOdemePeriyodu.EditValue?.ToString() ?? "Aylık",
                    BaslangicTarihi = dateBaslangicTarihi.EditValue as DateTime?,
                    BitisTarihi = dateBitisTarihi.EditValue as DateTime?,
                    AktifMi = chkAktifMi.Checked,
                    Kosullar = memoKosullar.Text.Trim()
                };

                HttpResponseMessage response;
                if (_duzenlemeModu)
                {
                    // Düzenleme modu - PUT
                    var url = $"http://localhost:5215/api/burslar/{_bursId}";
                    response = await _httpClient.PutAsJsonAsync(url, burs);
                }
                else
                {
                    // Yeni kayıt modu - POST
                    var url = "http://localhost:5215/api/burslar";
                    response = await _httpClient.PostAsJsonAsync(url, burs);
                }

                if (response.IsSuccessStatusCode)
                {
                    var mesaj = _duzenlemeModu ? "Burs başarıyla güncellendi." : "Burs tanımı başarıyla kaydedildi.";
                    XtraMessageBox.Show(mesaj, "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    var hataMesaji = await response.Content.ReadAsStringAsync();
                    XtraMessageBox.Show($"Hata: {response.StatusCode}\n{hataMesaji}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Bağlantı hatası: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
