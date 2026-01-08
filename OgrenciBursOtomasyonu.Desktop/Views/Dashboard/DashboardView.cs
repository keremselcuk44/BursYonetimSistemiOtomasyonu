using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.MVVM.UI;
using OgrenciBursOtomasyonu.Desktop.Views.Common;
using OgrenciBursOtomasyonu.Desktop.ViewModels;
using OgrenciBursOtomasyonu.Api.Models;

namespace OgrenciBursOtomasyonu.Desktop.Views.Dashboard {
    [ViewType(OgrenciBursDbViewModel.DashboardViewDocumentType)]
    public partial class DashboardView : XtraUserControl {
        private readonly HttpClient _httpClient;
        
        public DashboardView() {
            InitializeComponent();
            Load += DashboardView_Load;
            
            // HttpClient'ı yapılandır
            _httpClient = new HttpClient();
            // Dashboard ilk açılışta birden fazla endpoint çağırdığı için timeout'u daha toleranslı tutuyoruz.
            _httpClient.Timeout = TimeSpan.FromSeconds(120);
        }

        private class IstatistikDto
        {
            public int toplamOgrenci { get; set; }
            public int bursiyerSayisi { get; set; }
            public int toplamBurs { get; set; }
            public decimal toplamOdeme { get; set; }
            public int bekleyenOdeme { get; set; }
        }

        private class BursDto
        {
            public int Id { get; set; }
            public string BursAdi { get; set; } = string.Empty;
            public int Kontenjan { get; set; }
        }


        private async void DashboardView_Load(object sender, System.EventArgs e)
        {
            // Önce API bağlantısını test et
            if (!await ApiBaglantisiniTestEtAsync())
            {
                return; // API çalışmıyorsa veri yükleme işlemlerini durdur
            }
            
            await IstatistikleriYukleAsync();
            await GrafikleriYukleAsync();
            await SonOgrencileriYukleAsync();
            await PuanDagiliminiYukleAsync();
            await OdemeTrendiniYukleAsync();
        }
        
        /// <summary>
        /// API bağlantısını test eder.
        /// </summary>
        private async Task<bool> ApiBaglantisiniTestEtAsync()
        {
            try
            {
                var testUrl = "http://localhost:5215/api/ogrenciler/istatistikler";
                var response = await _httpClient.GetAsync(testUrl).ConfigureAwait(false);
                
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    if (InvokeRequired)
                    {
                        Invoke((System.Windows.Forms.MethodInvoker)(() =>
                        {
                            XtraMessageBox.Show(
                                $"API'ye bağlanılamadı.\n\n" +
                                $"Durum Kodu: {response.StatusCode}\n" +
                                $"URL: {testUrl}\n\n" +
                                $"Lütfen API'nin çalıştığından emin olun.\n" +
                                $"API'yi başlatmak için: cd OgrenciBursOtomasyonu.Api && dotnet run",
                                "API Bağlantı Hatası", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                        }));
                    }
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                if (InvokeRequired)
                {
                    Invoke((System.Windows.Forms.MethodInvoker)(() =>
                    {
                        XtraMessageBox.Show(
                            $"API'ye bağlanılamadı.\n\n" +
                            $"Hata: {ex.Message}\n\n" +
                            $"Lütfen şunları kontrol edin:\n" +
                            $"1. API çalışıyor mu? (http://localhost:5215)\n" +
                            $"2. Firewall API'yi engelliyor mu?\n" +
                            $"3. API'yi başlatmak için: cd OgrenciBursOtomasyonu.Api && dotnet run",
                            "API Bağlantı Hatası", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                    }));
                }
                return false;
            }
            catch (TaskCanceledException ex)
            {
                if (InvokeRequired)
                {
                    Invoke((System.Windows.Forms.MethodInvoker)(() =>
                    {
                        XtraMessageBox.Show(
                            $"API yanıt vermiyor (Timeout).\n\n" +
                            $"Hata: {ex.Message}\n\n" +
                            $"API çalışıyor olabilir ama yanıt vermiyor.\n" +
                            $"Lütfen API loglarını kontrol edin.",
                            "API Timeout", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
                    }));
                }
                return false;
            }
            catch (Exception ex)
            {
                if (InvokeRequired)
                {
                    Invoke((System.Windows.Forms.MethodInvoker)(() =>
                    {
                        XtraMessageBox.Show(
                            $"Beklenmeyen hata: {ex.Message}\n\n" +
                            $"Detay: {ex.GetType().Name}",
                            "Hata", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                    }));
                }
                return false;
            }
        }

        /// <summary>
        /// API'den genel istatistikleri çekip dashboard üzerindeki özet alanlara yazar.
        /// </summary>
        private async Task IstatistikleriYukleAsync()
        {
            try
            {
                var url = "http://localhost:5215/api/ogrenciler/istatistikler";
                var response = await _httpClient.GetAsync(url).ConfigureAwait(false);
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    System.Diagnostics.Debug.WriteLine($"API Hatası (İstatistikler): {response.StatusCode} - {errorContent}");
                    
                    if (InvokeRequired)
                    {
                        Invoke((System.Windows.Forms.MethodInvoker)(() =>
                        {
                            XtraMessageBox.Show($"İstatistikler yüklenemedi.\nDurum: {response.StatusCode}\n{errorContent}", 
                                "API Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }));
                    }
                    return;
                }
                
                var istatistik = await response.Content.ReadFromJsonAsync<IstatistikDto>().ConfigureAwait(false);
                if (istatistik == null)
                {
                    System.Diagnostics.Debug.WriteLine("İstatistikler null döndü");
                    return;
                }

                // UI thread'e dön
                if (InvokeRequired)
                {
                    Invoke((System.Windows.Forms.MethodInvoker)(() => IstatistikleriGuncelle(istatistik)));
                }
                else
                {
                    IstatistikleriGuncelle(istatistik);
                }
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine($"Bağlantı hatası (İstatistikler): {ex.Message}");
                if (InvokeRequired)
                {
                    Invoke((System.Windows.Forms.MethodInvoker)(() =>
                    {
                        XtraMessageBox.Show($"API'ye bağlanılamadı.\nLütfen API'nin çalıştığından emin olun.\n\nHata: {ex.Message}", 
                            "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Beklenmeyen hata (İstatistikler): {ex.Message}");
                if (InvokeRequired)
                {
                    Invoke((System.Windows.Forms.MethodInvoker)(() =>
                    {
                        XtraMessageBox.Show($"İstatistikler yüklenirken hata oluştu: {ex.Message}", 
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
            }
        }

        private void IstatistikleriGuncelle(IstatistikDto ist)
        {
            lblToplamOgrenci.Text = ist.toplamOgrenci.ToString("N0");
            lblBursiyerSayisi.Text = ist.bursiyerSayisi.ToString("N0");
            lblToplamBurs.Text = ist.toplamBurs.ToString("N0");
            lblToplamOdeme.Text = ist.toplamOdeme.ToString("C2");
            lblBekleyenOdeme.Text = ist.bekleyenOdeme.ToString("N0");
            
            // Yüzde hesapla
            if (ist.toplamOgrenci > 0)
            {
                var bursiyerYuzde = (ist.bursiyerSayisi * 100.0) / ist.toplamOgrenci;
                lblBursiyerYuzde.Text = $"%{bursiyerYuzde:F1}";
            }
            else
            {
                lblBursiyerYuzde.Text = "%0";
            }
        }

        /// <summary>
        /// Burs dağılımı grafiğini yükler.
        /// </summary>
        private async Task GrafikleriYukleAsync()
        {
            try
            {
                // Bursları yükle
                var bursResponse = await _httpClient.GetAsync("http://localhost:5215/api/burslar").ConfigureAwait(false);
                if (bursResponse.IsSuccessStatusCode)
                {
                    var burslar = await bursResponse.Content.ReadFromJsonAsync<List<BursDto>>().ConfigureAwait(false)
                        ?? new List<BursDto>();

                    // Öğrenci-burs eşleştirmelerini yükle
                    var eslestirmeResponse = await _httpClient.GetAsync("http://localhost:5215/api/ogrenciburslar").ConfigureAwait(false);
                    if (eslestirmeResponse.IsSuccessStatusCode)
                    {
                        var eslestirmeler = await eslestirmeResponse.Content.ReadFromJsonAsync<List<dynamic>>().ConfigureAwait(false)
                            ?? new List<dynamic>();

                        // Burs başına öğrenci sayısını hesapla
                        var bursOgrenciSayilari = burslar.Select(burs =>
                        {
                            var ogrenciSayisi = eslestirmeler.Count(e => 
                                ((dynamic)e).BursId == burs.Id && 
                                ((dynamic)e).Onaylandi == true);
                            return new { BursAdi = burs.BursAdi, OgrenciSayisi = ogrenciSayisi };
                        }).Where(x => x.OgrenciSayisi > 0).ToList();

                        if (InvokeRequired)
                        {
                            Invoke((System.Windows.Forms.MethodInvoker)(() => BursDagilimGrafiginiGuncelle(bursOgrenciSayilari)));
                        }
                        else
                        {
                            BursDagilimGrafiginiGuncelle(bursOgrenciSayilari);
                        }
                    }
                }
            }
            catch
            {
                // Hata durumunda sessiz kal
            }
        }

        private void BursDagilimGrafiginiGuncelle<T>(List<T> bursOgrenciSayilari) where T : class
        {
            try
            {
                bursDagilimChartControl.Series.Clear();
                
                if (bursOgrenciSayilari == null || bursOgrenciSayilari.Count == 0)
                    return;

                var series = new Series("Burs Dağılımı", ViewType.Doughnut);
                series.DataSource = bursOgrenciSayilari;
                series.ArgumentDataMember = "BursAdi";
                series.ValueDataMembers.AddRange("OgrenciSayisi");
                
                bursDagilimChartControl.Series.Add(series);
            }
            catch
            {
                // Grafik güncelleme hatası
            }
        }

        /// <summary>
        /// Son eklenen öğrencileri yükler.
        /// </summary>
        private async Task SonOgrencileriYukleAsync()
        {
            try
            {
                var url = "http://localhost:5215/api/ogrenciler/son-eklenen?adet=10";
                var response = await _httpClient.GetAsync(url).ConfigureAwait(false);
                
                if (!response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine($"API Hatası (Son Öğrenciler): {response.StatusCode}");
                    return;
                }
                
                var ogrenciler = await response.Content.ReadFromJsonAsync<List<OgrenciListeDto>>().ConfigureAwait(false);
                if (ogrenciler == null)
                {
                    System.Diagnostics.Debug.WriteLine("Son öğrenciler null döndü");
                    return;
                }

                if (InvokeRequired)
                {
                    Invoke((System.Windows.Forms.MethodInvoker)(() => SonOgrencileriGuncelle(ogrenciler)));
                }
                else
                {
                    SonOgrencileriGuncelle(ogrenciler);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Hata (Son Öğrenciler): {ex.Message}");
            }
        }

        private void SonOgrencileriGuncelle(List<OgrenciListeDto> ogrenciler)
        {
            try
            {
                gridControlSonOgrenciler.DataSource = ogrenciler;
                
                // GridView kolonlarını yapılandır
                gridViewSonOgrenciler.Columns.Clear();
                
                var colAd = gridViewSonOgrenciler.Columns.AddVisible("Ad", "Ad");
                colAd.VisibleIndex = 0;
                colAd.Width = 100;
                
                var colSoyad = gridViewSonOgrenciler.Columns.AddVisible("Soyad", "Soyad");
                colSoyad.VisibleIndex = 1;
                colSoyad.Width = 100;
                
                var colPuan = gridViewSonOgrenciler.Columns.AddVisible("Puan", "Puan");
                colPuan.VisibleIndex = 2;
                colPuan.Width = 80;
                colPuan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                colPuan.DisplayFormat.FormatString = "N0";
                
                var colBursDurumu = gridViewSonOgrenciler.Columns.AddVisible("BursDurumu", "Burs Durumu");
                colBursDurumu.VisibleIndex = 3;
                colBursDurumu.Width = 120;
                
                var colBursAdi = gridViewSonOgrenciler.Columns.AddVisible("BursAdi", "Burs Adı");
                colBursAdi.VisibleIndex = 4;
                colBursAdi.Width = 150;
                
                gridViewSonOgrenciler.BestFitColumns();
            }
            catch
            {
                // Grid güncelleme hatası
            }
        }

        /// <summary>
        /// Puan dağılımı grafiğini yükler.
        /// </summary>
        private async Task PuanDagiliminiYukleAsync()
        {
            try
            {
                var url = "http://localhost:5215/api/ogrenciler/puan-dagilimi";
                var response = await _httpClient.GetAsync(url).ConfigureAwait(false);
                
                if (!response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine($"API Hatası (Puan Dağılımı): {response.StatusCode}");
                    return;
                }
                
                var dagilim = await response.Content.ReadFromJsonAsync<List<dynamic>>().ConfigureAwait(false);
                if (dagilim == null || dagilim.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine("Puan dağılımı boş veya null");
                    return;
                }

                if (InvokeRequired)
                {
                    Invoke((System.Windows.Forms.MethodInvoker)(() => PuanDagilimGrafiginiGuncelle(dagilim)));
                }
                else
                {
                    PuanDagilimGrafiginiGuncelle(dagilim);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Hata (Puan Dağılımı): {ex.Message}");
            }
        }

        private void PuanDagilimGrafiginiGuncelle<T>(List<T> dagilim) where T : class
        {
            try
            {
                puanDagilimChartControl.Series.Clear();
                
                if (dagilim == null || dagilim.Count == 0)
                    return;

                var series = new Series("Puan Dağılımı", ViewType.Bar);
                series.DataSource = dagilim;
                series.ArgumentDataMember = "Aralik";
                series.ValueDataMembers.AddRange("Sayi");
                
                puanDagilimChartControl.Series.Add(series);
            }
            catch
            {
                // Grafik güncelleme hatası
            }
        }

        /// <summary>
        /// Aylık ödeme trendi grafiğini yükler.
        /// </summary>
        private async Task OdemeTrendiniYukleAsync()
        {
            try
            {
                var url = "http://localhost:5215/api/ogrenciler/aylik-odeme-trendi?aySayisi=6";
                var response = await _httpClient.GetAsync(url).ConfigureAwait(false);
                
                if (!response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine($"API Hatası (Ödeme Trendi): {response.StatusCode}");
                    return;
                }
                
                var trend = await response.Content.ReadFromJsonAsync<List<dynamic>>().ConfigureAwait(false);
                if (trend == null || trend.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine("Ödeme trendi boş veya null");
                    return;
                }

                if (InvokeRequired)
                {
                    Invoke((System.Windows.Forms.MethodInvoker)(() => OdemeTrendiGrafiginiGuncelle(trend)));
                }
                else
                {
                    OdemeTrendiGrafiginiGuncelle(trend);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Hata (Ödeme Trendi): {ex.Message}");
            }
        }

        private void OdemeTrendiGrafiginiGuncelle<T>(List<T> trend) where T : class
        {
            try
            {
                odemeTrendiChartControl.Series.Clear();
                
                if (trend == null || trend.Count == 0)
                    return;

                var series = new Series("Aylık Ödeme Trendi", ViewType.Line);
                series.DataSource = trend;
                series.ArgumentDataMember = "Ay";
                series.ValueDataMembers.AddRange("ToplamTutar");
                
                odemeTrendiChartControl.Series.Add(series);
            }
            catch
            {
                // Grafik güncelleme hatası
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            _ = IstatistikleriYukleAsync();
            _ = GrafikleriYukleAsync();
            _ = SonOgrencileriYukleAsync();
            _ = PuanDagiliminiYukleAsync();
            _ = OdemeTrendiniYukleAsync();
        }
    }
}
