using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using OgrenciBursOtomasyonu.Desktop.Views.Common;
using DevExpress.Utils.MVVM.Services;
using DevExpress.Utils.MVVM.UI;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using OgrenciBursOtomasyonu.Desktop.Common.ViewModel;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Tile;
using BursModel = OgrenciBursOtomasyonu.Api.Models.Burs;
using OgrenciModel = OgrenciBursOtomasyonu.Api.Models.Ogrenci;
using OgrenciBursOtomasyonu.Desktop.ViewModels;

namespace OgrenciBursOtomasyonu.Desktop.Views.Burs {
    /// <summary>
    /// Burs alan öğrenci DTO (TileView için uygun hale getirildi).
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
        public string Telefon { get; set; } = string.Empty;
        public string ResimYolu { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        
        // TileView için gerekli alanlar
        public string FullName => $"{Ad} {Soyad}";
        public string FullNameBindable => FullName;
        public string Address => !string.IsNullOrEmpty(Universite) && !string.IsNullOrEmpty(Bolum) 
            ? $"{Universite} - {Bolum}" 
            : (!string.IsNullOrEmpty(Universite) ? Universite : (!string.IsNullOrEmpty(Bolum) ? Bolum : ""));
        public string HomePhone => Telefon;
        
        private System.Drawing.Image _photoImage;
        public System.Drawing.Image Photo 
        { 
            get
            {
                if (_photoImage != null)
                    return _photoImage;
                
                if (string.IsNullOrWhiteSpace(ResimYolu))
                    return null;
                
                try
                {
                    // Base64 string'den image oluştur
                    string base64Data = ResimYolu;
                    
                    if (ResimYolu.StartsWith("data:image"))
                    {
                        // data:image/png;base64,xxxxx formatından base64 kısmını al
                        base64Data = ResimYolu.Split(',')[1];
                    }
                    
                    var imageBytes = Convert.FromBase64String(base64Data);
                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        _photoImage = System.Drawing.Image.FromStream(ms);
                    }
                    return _photoImage;
                }
                catch
                {
                    // Base64 decode edilemezse null döndür
                    return null;
                }
            }
        }
    }
    [ViewType(OgrenciBursDbViewModel.BursCollectionViewDocumentType)]
    public partial class BursCollectionView : FilterCollectionViewBase {
        private readonly HttpClient _httpClient = new();
        private BursModel _selectedBurs = null;

        public BursCollectionView() {
            InitializeComponent();
            gridControl.Visible = false;
            searchControl.SetupSearchControl(windowsUIButtonPanel);
            
            // TileView event handler'ları
            tileView.ItemClick += TileView_ItemClick;
            
            // BursFilterView event handler'ı
            bursFilterView.BursChanged += BursFilterView_BursChanged;
            
            // WindowsUIButtonPanel butonlarına event bağla
            if (windowsUIButtonPanel.Buttons.Count > 0)
            {
                // "Ekle" butonu - Yeni burs ekle
                if (windowsUIButtonPanel.Buttons[0] is WindowsUIButton ekleBtn)
                {
                    ekleBtn.Click += BtnYeniBurs_Click;
                }
                // "Düzenle" butonu - Burs düzenle
                if (windowsUIButtonPanel.Buttons.Count > 1 && windowsUIButtonPanel.Buttons[1] is WindowsUIButton duzenleBtn)
                {
                    duzenleBtn.Click += BtnBursDuzenle_Click;
                }
                // "Burs Eşleştir" butonu - Burs eşleştirme (FrmBursEslestir)
                if (windowsUIButtonPanel.Buttons.Count > 2 && windowsUIButtonPanel.Buttons[2] is WindowsUIButton eslestirBtn)
                {
                    eslestirBtn.Click += BtnBursEslestir_Click;
                }
            }
            
            // Verileri yükle
            Load += BursCollectionView_Load;
        }

        private async void BursCollectionView_Load(object sender, EventArgs e)
        {
            await BurslariYukleAsync();
        }

        private async Task BurslariYukleAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://localhost:5215/api/burslar").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var burslar = await response.Content.ReadFromJsonAsync<List<BursModel>>().ConfigureAwait(false)
                        ?? new List<BursModel>();
                    
                    // UI thread'de güncelle
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            bursFilterView.LoadBurslar(burslar);
                            if (burslar.Count > 0)
                            {
                                BursFilterView_BursChanged(this, burslar[0]);
                            }
                        }));
                    }
                    else
                    {
                        bursFilterView.LoadBurslar(burslar);
                        if (burslar.Count > 0)
                        {
                            BursFilterView_BursChanged(this, burslar[0]);
                        }
                    }
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
                        XtraMessageBox.Show($"Bağlantı hatası: {ex.Message}",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                else
                {
                    XtraMessageBox.Show($"Bağlantı hatası: {ex.Message}",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private async void BursFilterView_BursChanged(object sender, BursModel burs)
        {
            _selectedBurs = burs;
            
            // Üstte burs bilgilerini göster
            UpdateBursDetails(burs);
            
            // Altta o bursu alan öğrencileri yükle
            await OgrencileriYukleAsync(burs.Id);
        }
        
        private void UpdateBursDetails(BursModel burs)
        {
            if (burs != null)
            {
                labelControl.Text = $"BURS  <color=47, 81, 165>{burs.BursAdi}</color> | " +
                    $"Minimum Puan: {burs.MinimumPuan} | " +
                    $"Kontenjan: {burs.Kontenjan} | " +
                    $"Aylık Tutar: {burs.AylikTutar:N2} TL";
            }
            else
            {
                labelControl.Text = "BURS  <color=47, 81, 165>Categories</color>";
            }
        }
        
        private async Task OgrencileriYukleAsync(int bursId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://localhost:5215/api/ogrenciburslar/burs/{bursId}").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var ogrenciler = await response.Content.ReadFromJsonAsync<List<BursOgrenciDto>>().ConfigureAwait(false)
                        ?? new List<BursOgrenciDto>();
                    
                    // Önce temel verileri yükle (hızlı)
                    var ogrenciTileList = ogrenciler.ToList();
                    
                    // UI thread'de güncelle
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            UpdateOgrenciGrid(ogrenciTileList);
                        }));
                    }
                    else
                    {
                        UpdateOgrenciGrid(ogrenciTileList);
                    }
                    
                    // Arka planda detay bilgilerini yükle (fotoğraf, telefon, email vb.)
                    _ = Task.Run(async () =>
                    {
                        try
                        {
                            var detayTasks = ogrenciler.Select(async ogrenci =>
                            {
                                try
                                {
                                    var detayResponse = await _httpClient.GetAsync($"http://localhost:5215/api/ogrenciler/{ogrenci.Id}").ConfigureAwait(false);
                                    if (detayResponse.IsSuccessStatusCode)
                                    {
                                        var ogrenciDetay = await detayResponse.Content.ReadFromJsonAsync<OgrenciModel>().ConfigureAwait(false);
                                        if (ogrenciDetay != null)
                                        {
                                            // UI thread'de güncelle
                                            if (InvokeRequired)
                                            {
                                                Invoke((MethodInvoker)(() =>
                                                {
                                                    var existingItem = ogrenciTileList.FirstOrDefault(x => x.Id == ogrenci.Id);
                                                    if (existingItem != null)
                                                    {
                                                        existingItem.Telefon = ogrenciDetay.Telefon ?? "";
                                                        existingItem.ResimYolu = ogrenciDetay.ResimYolu ?? "";
                                                        existingItem.Email = ogrenciDetay.Email ?? "";
                                                        
                                                        // Grid'i yenile
                                                        bursBindingSource.ResetBindings(false);
                                                    }
                                                }));
                                            }
                                            else
                                            {
                                                var existingItem = ogrenciTileList.FirstOrDefault(x => x.Id == ogrenci.Id);
                                                if (existingItem != null)
                                                {
                                                    existingItem.Telefon = ogrenciDetay.Telefon ?? "";
                                                    existingItem.ResimYolu = ogrenciDetay.ResimYolu ?? "";
                                                    existingItem.Email = ogrenciDetay.Email ?? "";
                                                    
                                                    // Grid'i yenile
                                                    bursBindingSource.ResetBindings(false);
                                                }
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                    // Detay alınamazsa devam et
                                }
                            });
                            
                            await Task.WhenAll(detayTasks);
                        }
                        catch
                        {
                            // Hata durumunda sessizce devam et
                        }
                    });
                }
                else
                {
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)(() => bursBindingSource.DataSource = new List<BursOgrenciDto>()));
                    }
                    else
                    {
                        bursBindingSource.DataSource = new List<BursOgrenciDto>();
                    }
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
                        bursBindingSource.DataSource = new List<BursOgrenciDto>();
                    }));
                }
                else
                {
                    XtraMessageBox.Show($"Öğrenci bilgileri yüklenirken hata: {ex.Message}",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bursBindingSource.DataSource = new List<BursOgrenciDto>();
                }
            }
        }
        
        private void UpdateOgrenciGrid(List<BursOgrenciDto> ogrenciTileList)
        {
            bursBindingSource.DataSource = ogrenciTileList;
            gridControl.Visible = true;
        }

        // TileView ItemClick event'i - Öğrenciye tıklandığında ödeme formunu aç
        private async void TileView_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            var ogrenci = tileView.GetRow(e.Item.RowHandle) as BursOgrenciDto;
            if (ogrenci == null || ogrenci.OgrenciBursId <= 0)
            {
                return;
            }
            
            // FrmBursAlanOgrenciler'ı aç (öğrenci bilgileri ve ödeme takibi için)
            using (var frm = new FrmBursAlanOgrenciler(ogrenci.OgrenciBursId))
            {
                frm.ShowDialog();
            }
            
            // Form kapatıldıktan sonra verileri yenile
            if (_selectedBurs != null)
            {
                await OgrencileriYukleAsync(_selectedBurs.Id);
            }
        }

        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Artık kullanılmıyor
        }

        // FrmBursListe'deki mantık: Yeni burs ekle butonu
        private async void BtnYeniBurs_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new FrmBursTanimla(0))
                {
                    frm.ShowDialog();
                }
                // Form kapatıldıktan sonra verileri yenile
                await BurslariYukleAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // FrmBursListe'deki mantık: Burs düzenle butonu
        private async void BtnBursDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedBurs == null)
                {
                    XtraMessageBox.Show("Lütfen düzenlemek istediğiniz bir burs seçin.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var frm = new FrmBursTanimla(_selectedBurs.Id))
                {
                    frm.ShowDialog();
                }
                // Form kapatıldıktan sonra verileri yenile
                await BurslariYukleAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // FrmBursEslestir'deki mantık: Burs eşleştirme butonu
        private async void BtnBursEslestir_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new FrmBursEslestir())
                {
                    frm.ShowDialog();
                }
                // Form kapatıldıktan sonra verileri yenile
                await BurslariYukleAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void DocumentShownMessageReceived(DocumentShownMessage msg) {
            if(msg.DocumentType != OgrenciBursOtomasyonu.Desktop.ViewModels.OgrenciBursDbViewModel.BursCollectionViewDocumentType) {
                return;
            }
            // View gösterildiğinde bursları yükle (exception handling ile)
            _ = Task.Run(async () =>
            {
                try
                {
                    await BurslariYukleAsync();
                }
                catch (Exception ex)
                {
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            XtraMessageBox.Show($"Veri yüklenirken hata: {ex.Message}",
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                }
            });
        }
    }
}


