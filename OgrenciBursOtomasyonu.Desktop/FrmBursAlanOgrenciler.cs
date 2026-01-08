using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OgrenciBursOtomasyonu.Api.Models;

namespace OgrenciBursOtomasyonu.Desktop
{
    /// <summary>
    /// Burs alan öğrencilerin listelendiği ve ödeme takiplerinin yapıldığı form.
    /// </summary>
    public partial class FrmBursAlanOgrenciler : XtraForm
    {
        private readonly HttpClient _httpClient = new();
        private readonly int? _selectedOgrenciBursId; // Seçili öğrenci burs ID'si (opsiyonel)
        private OgrenciBursDto _currentOgrenciBurs = null; // Mevcut öğrenci-burs eşleştirmesi

        public FrmBursAlanOgrenciler(int? selectedOgrenciBursId = null)
        {
            _selectedOgrenciBursId = selectedOgrenciBursId;
            try
            {
                InitializeComponent();
                Activated += FrmBursAlanOgrenciler_Activated;
            }
            catch (Exception ex)
            {
                // InitializeComponent hatası - logla ve göster
                string hataMesaji = $"Form başlatılırken hata:\n\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}";
                System.IO.File.AppendAllText("hata_log.txt", $"[{DateTime.Now}] {hataMesaji}\n\n");
                
                MessageBox.Show(hataMesaji, "Form Başlatma Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // Hatayı yukarı fırlat (global handler yakalayacak)
            }
        }

        private async void FrmBursAlanOgrenciler_Load(object sender, EventArgs e)
        {
            try
            {
                // Mevcut ay ve yıl bilgilerini ayarla
                spinAy.Value = DateTime.Now.Month;
                spinYil.Value = DateTime.Now.Year;
                
                await OgrenciBilgileriniYukleAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Form yüklenirken hata oluştu: {ex.Message}\n\nDetay: {ex}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void FrmBursAlanOgrenciler_Activated(object sender, EventArgs e)
        {
            await OgrenciBilgileriniYukleAsync();
        }

        private async Task OgrenciBilgileriniYukleAsync()
        {
            try
            {
                if (!_selectedOgrenciBursId.HasValue)
                {
                    // Öğrenci seçilmemişse temizle
                    OgrenciBilgileriniTemizle();
                    return;
                }

                
                // Öğrenci-burs eşleştirmesini al
                var response = await _httpClient.GetAsync("http://localhost:5215/api/ogrenciburslar").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var eslestirmeler = await response.Content.ReadFromJsonAsync<List<OgrenciBursDto>>().ConfigureAwait(false)
                        ?? new List<OgrenciBursDto>();
                    
                    _currentOgrenciBurs = eslestirmeler.FirstOrDefault(e => e.Id == _selectedOgrenciBursId.Value && e.Onaylandi);
                    
                    if (_currentOgrenciBurs == null)
                    {
                        XtraMessageBox.Show("Seçilen öğrenci-burs eşleştirmesi bulunamadı.", "Hata",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        OgrenciBilgileriniTemizle();
                        return;
                    }

                    // Öğrenci detaylarını yükle
                    await OgrenciDetaylariniYukleAsync(_currentOgrenciBurs.OgrenciId);
                    
                    // Burs bilgilerini göster
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            lblAylikTutar.Text = $"Aylık Tutar: {_currentOgrenciBurs.AylikTutar:N2} TL";
                        }));
                    }
                    else
                    {
                        lblAylikTutar.Text = $"Aylık Tutar: {_currentOgrenciBurs.AylikTutar:N2} TL";
                    }
                    
                    // Ödeme takiplerini yükle
                    await OdemeTakipleriniYukleAsync(_currentOgrenciBurs.Id);
                    
                }
                else
                {
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            XtraMessageBox.Show($"API'den veri alınamadı. Durum: {response.StatusCode}",
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                    else
                    {
                        XtraMessageBox.Show($"API'den veri alınamadı. Durum: {response.StatusCode}",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        XtraMessageBox.Show($"Bağlantı hatası: {ex.Message}\n\nDetay: {ex}",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                else
                {
                    XtraMessageBox.Show($"Bağlantı hatası: {ex.Message}\n\nDetay: {ex}",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task OgrenciDetaylariniYukleAsync(int ogrenciId)
        {
            try
            {
                var url = $"http://localhost:5215/api/ogrenciler/{ogrenciId}";
                var ogrenci = await _httpClient.GetFromJsonAsync<Ogrenci>(url).ConfigureAwait(false);

                if (ogrenci == null)
                {
                    OgrenciBilgileriniTemizle();
                    return;
                }

                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        OgrenciBilgileriniGoster(ogrenci);
                    }));
                }
                else
                {
                    OgrenciBilgileriniGoster(ogrenci);
                }
            }
            catch (Exception ex)
            {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        XtraMessageBox.Show($"Öğrenci bilgileri yüklenirken hata: {ex.Message}",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                else
                {
                    XtraMessageBox.Show($"Öğrenci bilgileri yüklenirken hata: {ex.Message}",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OgrenciBilgileriniGoster(Ogrenci ogrenci)
        {
            // Öğrenci bilgilerini göster
            lblOgrenciAdSoyad.Text = $"{ogrenci.Ad} {ogrenci.Soyad}";
            lblOgrenciTc.Text = ogrenci.TcKimlikNo;
            lblOgrenciEmail.Text = string.IsNullOrWhiteSpace(ogrenci.Email) ? "-" : ogrenci.Email;
            lblOgrenciTelefon.Text = string.IsNullOrWhiteSpace(ogrenci.Telefon) ? "-" : ogrenci.Telefon;
            lblOgrenciUniversite.Text = string.IsNullOrWhiteSpace(ogrenci.Universite) ? "-" : 
                (!string.IsNullOrWhiteSpace(ogrenci.Bolum) ? $"{ogrenci.Universite} - {ogrenci.Bolum}" : ogrenci.Universite);

            // Resmi göster
            ResmiGoster(ogrenci.ResimYolu);
        }

        private void OgrenciBilgileriniTemizle()
        {
            lblOgrenciAdSoyad.Text = "Öğrenci Seçin";
            lblOgrenciTc.Text = "-";
            lblOgrenciEmail.Text = "-";
            lblOgrenciTelefon.Text = "-";
            lblOgrenciUniversite.Text = "-";
            lblAylikTutar.Text = "Aylık Tutar: 0,00 TL";
            lblToplamOdenen.Text = "Toplam Ödenen: 0,00 TL";
            pictureEditOgrenciResim.Image = null;
            gridControlOdemeTakip.DataSource = new List<BursOdemeTakipDto>();
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
                    if (pictureEditOgrenciResim != null)
                        pictureEditOgrenciResim.Image = null;
                    return;
                }

                if (pictureEditOgrenciResim == null)
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
                    pictureEditOgrenciResim.Image = System.Drawing.Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                // Resim yüklenemezse boş bırak
                if (pictureEditOgrenciResim != null)
                    pictureEditOgrenciResim.Image = null;
                System.Diagnostics.Debug.WriteLine($"Resim yükleme hatası: {ex.Message}");
            }
        }

        private async Task OdemeTakipleriniYukleAsync(int ogrenciBursId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://localhost:5215/api/bursodemetakip/ogrenciburs/{ogrenciBursId}").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    
                    try
                    {
                        // JSON string'i debug için loglaya biliriz
                        // System.Diagnostics.Debug.WriteLine($"API Response: {jsonString}");
                        
                        var jsonDoc = System.Text.Json.JsonDocument.Parse(jsonString);
                        
                        // Takipler listesini al
                        List<BursOdemeTakipDto> takipler = new List<BursOdemeTakipDto>();
                        if (jsonDoc.RootElement.TryGetProperty("takipler", out var takiplerProperty))
                        {
                            if (takiplerProperty.ValueKind == System.Text.Json.JsonValueKind.Array)
                            {
                                foreach (var item in takiplerProperty.EnumerateArray())
                                {
                                    try
                                    {
                                        var takipDto = new BursOdemeTakipDto
                                        {
                                            Id = item.TryGetProperty("id", out var idProp) ? idProp.GetInt32() : 
                                                 item.TryGetProperty("Id", out var idProp2) ? idProp2.GetInt32() : 0,
                                            OgrenciBursId = item.TryGetProperty("ogrenciBursId", out var ogbIdProp) ? ogbIdProp.GetInt32() :
                                                           item.TryGetProperty("OgrenciBursId", out var ogbIdProp2) ? ogbIdProp2.GetInt32() : 0,
                                            Ay = item.TryGetProperty("ay", out var ayProp) ? ayProp.GetInt32() :
                                                 item.TryGetProperty("Ay", out var ayProp2) ? ayProp2.GetInt32() : 0,
                                            Yil = item.TryGetProperty("yil", out var yilProp) ? yilProp.GetInt32() :
                                                  item.TryGetProperty("Yil", out var yilProp2) ? yilProp2.GetInt32() : 0,
                                            OdendiMi = item.TryGetProperty("odendiMi", out var odendiProp) ? odendiProp.GetBoolean() :
                                                       item.TryGetProperty("OdendiMi", out var odendiProp2) ? odendiProp2.GetBoolean() : false,
                                            OdemeTarihi = item.TryGetProperty("odemeTarihi", out var tarihProp) && tarihProp.ValueKind != System.Text.Json.JsonValueKind.Null ?
                                                         (tarihProp.TryGetDateTime(out var dt) ? dt : (DateTime?)null) :
                                                         (item.TryGetProperty("OdemeTarihi", out var tarihProp2) && tarihProp2.ValueKind != System.Text.Json.JsonValueKind.Null ?
                                                          (tarihProp2.TryGetDateTime(out var dt2) ? dt2 : (DateTime?)null) : null)
                                        };
                                        
                                        // Geçerli değerleri kontrol et
                                        if (takipDto.Ay >= 1 && takipDto.Ay <= 12 && takipDto.Yil >= 1900 && takipDto.Yil <= 2100)
                                        {
                                            takipler.Add(takipDto);
                                        }
                                    }
                                    catch
                                    {
                                        // Bu öğeyi atla
                                        continue;
                                    }
                                }
                            }
                        }
                        
                        // Verileri grid'e yükle
                        var sortedTakipler = takipler.OrderByDescending(t => t.Yil).ThenByDescending(t => t.Ay).ToList();
                        
                        // Toplam ödenen tutarı al
                        decimal toplamOdenen = 0;
                        if (jsonDoc.RootElement.TryGetProperty("toplamOdenenTutar", out var toplamProperty))
                        {
                            if (toplamProperty.ValueKind == System.Text.Json.JsonValueKind.Number)
                            {
                                toplamOdenen = toplamProperty.GetDecimal();
                            }
                        }
                        
                        if (InvokeRequired)
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                gridControlOdemeTakip.DataSource = sortedTakipler;
                                lblToplamOdenen.Text = $"Toplam Ödenen: {toplamOdenen:N2} TL";
                            }));
                        }
                        else
                        {
                            gridControlOdemeTakip.DataSource = sortedTakipler;
                            lblToplamOdenen.Text = $"Toplam Ödenen: {toplamOdenen:N2} TL";
                        }
                    }
                    catch (System.Text.Json.JsonException)
                    {
                        // JSON parse hatası - direkt liste olarak dene
                        try
                        {
                            var takipler = System.Text.Json.JsonSerializer.Deserialize<List<BursOdemeTakipDto>>(jsonString)
                                ?? new List<BursOdemeTakipDto>();
                            var sortedTakipler = takipler.Where(t => t.Ay >= 1 && t.Ay <= 12 && t.Yil >= 1900 && t.Yil <= 2100)
                                .OrderByDescending(t => t.Yil).ThenByDescending(t => t.Ay).ToList();
                            
                            if (InvokeRequired)
                            {
                                Invoke((MethodInvoker)(() =>
                                {
                                    gridControlOdemeTakip.DataSource = sortedTakipler;
                                    lblToplamOdenen.Text = "Toplam Ödenen: 0,00 TL";
                                }));
                            }
                            else
                            {
                                gridControlOdemeTakip.DataSource = sortedTakipler;
                                lblToplamOdenen.Text = "Toplam Ödenen: 0,00 TL";
                            }
                        }
                        catch
                        {
                            if (InvokeRequired)
                            {
                                Invoke((MethodInvoker)(() =>
                                {
                                    gridControlOdemeTakip.DataSource = new List<BursOdemeTakipDto>();
                                    lblToplamOdenen.Text = "Toplam Ödenen: 0,00 TL";
                                }));
                            }
                            else
                            {
                                gridControlOdemeTakip.DataSource = new List<BursOdemeTakipDto>();
                                lblToplamOdenen.Text = "Toplam Ödenen: 0,00 TL";
                            }
                        }
                    }
                }
                else
                {
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            gridControlOdemeTakip.DataSource = new List<BursOdemeTakipDto>();
                            lblToplamOdenen.Text = "Toplam Ödenen: 0,00 TL";
                        }));
                    }
                    else
                    {
                        gridControlOdemeTakip.DataSource = new List<BursOdemeTakipDto>();
                        lblToplamOdenen.Text = "Toplam Ödenen: 0,00 TL";
                    }
                }
            }
            catch (Exception ex)
            {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        XtraMessageBox.Show($"Ödeme takibi yüklenirken hata: {ex.Message}\n\nDetay: {ex}",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        gridControlOdemeTakip.DataSource = new List<BursOdemeTakipDto>();
                    }));
                }
                else
                {
                    XtraMessageBox.Show($"Ödeme takibi yüklenirken hata: {ex.Message}\n\nDetay: {ex}",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridControlOdemeTakip.DataSource = new List<BursOdemeTakipDto>();
                }
            }
        }

        private async void btnOdemeOnayla_Click(object sender, EventArgs e)
        {
            if (_currentOgrenciBurs == null)
            {
                XtraMessageBox.Show("Öğrenci bilgileri yüklenmedi.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ay = (int)spinAy.Value;
            int yil = (int)spinYil.Value;

            var onay = XtraMessageBox.Show(
                $"{_currentOgrenciBurs.OgrenciAd} {_currentOgrenciBurs.OgrenciSoyad} öğrencisinin {ay}/{yil} ayı için burs ödemesi onaylanacak. Devam etmek istiyor musunuz?",
                "Ödeme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay != DialogResult.Yes)
                return;

            try
            {
                var onayDto = new
                {
                    OgrenciBursId = _currentOgrenciBurs.Id,
                    Ay = ay,
                    Yil = yil
                };

                var response = await _httpClient.PostAsJsonAsync(
                    "http://localhost:5215/api/bursodemetakip/onayla", onayDto).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    XtraMessageBox.Show("Burs ödemesi başarıyla onaylandı.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Verileri yeniden yükle
                    await OdemeTakipleriniYukleAsync(_currentOgrenciBurs.Id);
                }
                else
                {
                    var hataMesaji = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            XtraMessageBox.Show($"Ödeme onaylama hatası: {hataMesaji}", "Hata",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                    else
                    {
                        XtraMessageBox.Show($"Ödeme onaylama hatası: {hataMesaji}", "Hata",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        XtraMessageBox.Show($"Ödeme onaylama hatası: {ex.Message}", "Hata",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                else
                {
                    XtraMessageBox.Show($"Ödeme onaylama hatası: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnYenile_Click(object sender, EventArgs e)
        {
            await OgrenciBilgileriniYukleAsync();
        }

        private async void btnBursProgramindanCikar_Click(object sender, EventArgs e)
        {
            if (_currentOgrenciBurs == null)
            {
                XtraMessageBox.Show("Öğrenci bilgileri yüklenmedi.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var onay = XtraMessageBox.Show(
                $"{_currentOgrenciBurs.OgrenciAd} {_currentOgrenciBurs.OgrenciSoyad} öğrencisini {_currentOgrenciBurs.BursAdi} burs programından çıkarmak istediğinize emin misiniz?\n\nÖğrenciye mail gönderilecektir.",
                "Burs Programından Çıkarma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay != DialogResult.Yes)
                return;

            try
            {
                // DELETE işlemini yap
                var deleteResponse = await _httpClient.DeleteAsync($"http://localhost:5215/api/ogrenciburslar/{_currentOgrenciBurs.Id}").ConfigureAwait(false);
                
                if (deleteResponse.IsSuccessStatusCode || deleteResponse.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    XtraMessageBox.Show("Öğrenci burs programından çıkarıldı. Öğrenciye mail gönderildi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Formu kapat
                    Close();
                }
                else
                {
                    var hataMesaji = await deleteResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            XtraMessageBox.Show($"Burs programından çıkarma hatası: {hataMesaji}", "Hata",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                    else
                    {
                        XtraMessageBox.Show($"Burs programından çıkarma hatası: {hataMesaji}", "Hata",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        XtraMessageBox.Show($"Burs programından çıkarma hatası: {ex.Message}", "Hata",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                else
                {
                    XtraMessageBox.Show($"Burs programından çıkarma hatası: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    /// <summary>
    /// Öğrenci-Burs eşleştirme DTO (Desktop için).
    /// </summary>
    public class OgrenciBursDto
    {
        public int Id { get; set; }
        public int OgrenciId { get; set; }
        public string OgrenciAd { get; set; } = string.Empty;
        public string OgrenciSoyad { get; set; } = string.Empty;
        public string OgrenciTcKimlikNo { get; set; } = string.Empty;
        public int BursId { get; set; }
        public string BursAdi { get; set; } = string.Empty;
        public decimal AylikTutar { get; set; }
        public bool Onaylandi { get; set; }
    }

    /// <summary>
    /// Burs ödeme takip DTO.
    /// </summary>
    public class BursOdemeTakipDto
    {
        public int Id { get; set; }
        public int OgrenciBursId { get; set; }
        public int Ay { get; set; }
        public int Yil { get; set; }
        public bool OdendiMi { get; set; }
        public DateTime? OdemeTarihi { get; set; }
        
        public string AyAdi
        {
            get
            {
                try
                {
                    // Ay ve Yil değerlerini kontrol et
                    if (Ay < 1 || Ay > 12 || Yil < 1900 || Yil > 2100)
                        return $"{Ay:D2}/{Yil}"; // Geçersiz değerler için basit format
                    
                    return new DateTime(Yil, Ay, 1).ToString("MMMM yyyy", new System.Globalization.CultureInfo("tr-TR"));
                }
                catch
                {
                    return $"{Ay:D2}/{Yil}";
                }
            }
        }
    }
}
