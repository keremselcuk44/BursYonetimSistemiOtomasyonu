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
    /// Öğrenci detay bilgilerini ve AI raporunu gösteren form.
    /// </summary>
    public partial class FrmOgrenciDetay : XtraForm
    {
        private readonly HttpClient _httpClient = new();
        private readonly int _ogrenciId;

        public FrmOgrenciDetay(int ogrenciId)
        {
            _ogrenciId = ogrenciId;
            InitializeComponent();
            Activated += FrmOgrenciDetay_Activated;
        }

        private async void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            await OgrenciDetaylariniYukleAsync();
        }

        private async void FrmOgrenciDetay_Activated(object sender, EventArgs e)
        {
            await OgrenciDetaylariniYukleAsync();
        }

        private async Task OgrenciDetaylariniYukleAsync()
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

                // Temel bilgileri göster
                lblTc.Text = ogrenci.TcKimlikNo;
                lblAdSoyad.Text = $"{ogrenci.Ad} {ogrenci.Soyad}";
                lblYas.Text = ogrenci.Yas > 0 ? ogrenci.Yas.ToString() : "Belirtilmemiş";
                lblUniversite.Text = ogrenci.Universite;
                lblBolum.Text = ogrenci.Bolum;
                lblSinif.Text = ogrenci.Sinif;
                lblAgno.Text = ogrenci.Agno.ToString("F2");
                lblKardesSayisi.Text = ogrenci.KardesSayisi.ToString();
                lblHaneGeliri.Text = ogrenci.HaneGeliri.ToString("N2") + " TL";
                lblPuan.Text = ogrenci.Puan.ToString();
                
                // İletişim bilgileri
                lblEmail.Text = string.IsNullOrWhiteSpace(ogrenci.Email) ? "Belirtilmemiş" : ogrenci.Email;
                lblTelefon.Text = string.IsNullOrWhiteSpace(ogrenci.Telefon) ? "Belirtilmemiş" : ogrenci.Telefon;
                lblIban.Text = string.IsNullOrWhiteSpace(ogrenci.Iban) ? "Belirtilmemiş" : FormatIban(ogrenci.Iban);

                // Resmi göster
                ResmiGoster(ogrenci.ResimYolu);

                // AI Raporunu göster
                memoAiRaporu.Text = string.IsNullOrWhiteSpace(ogrenci.AiRaporu) 
                    ? "Henüz AI raporu oluşturulmamış." 
                    : ogrenci.AiRaporu;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Bağlantı hatası: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Base64 string olarak gelen resmi PictureEdit'e yükler.
        /// </summary>
        private void ResmiGoster(string resimBase64)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(resimBase64))
                {
                    if (pictureEditResim != null)
                        pictureEditResim.Image = null;
                    return;
                }

                if (pictureEditResim == null)
                    return;

                // Base64 string'den image oluştur
                string base64Data = resimBase64;
                
                if (resimBase64.StartsWith("data:image"))
                {
                    // data:image/png;base64,xxxxx formatından base64 kısmını al
                    base64Data = resimBase64.Split(',')[1];
                }

                var imageBytes = Convert.FromBase64String(base64Data);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    pictureEditResim.Image = System.Drawing.Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                // Resim yüklenemezse boş bırak
                if (pictureEditResim != null)
                    pictureEditResim.Image = null;
                System.Diagnostics.Debug.WriteLine($"Resim yükleme hatası: {ex.Message}");
            }
        }

        /// <summary>
        /// IBAN'ı formatlı gösterir (TR00 0000 0000 0000 0000 0000 00).
        /// </summary>
        private string FormatIban(string iban)
        {
            if (string.IsNullOrWhiteSpace(iban))
                return string.Empty;

            // Boşlukları temizle
            iban = iban.Replace(" ", "").ToUpper();
            
            // 4'lü gruplar halinde formatla
            if (iban.Length >= 4)
            {
                var formatted = iban.Substring(0, 4);
                for (int i = 4; i < iban.Length; i += 4)
                {
                    var remaining = iban.Length - i;
                    var length = remaining >= 4 ? 4 : remaining;
                    formatted += " " + iban.Substring(i, length);
                }
                return formatted;
            }
            
            return iban;
        }
    }
}

