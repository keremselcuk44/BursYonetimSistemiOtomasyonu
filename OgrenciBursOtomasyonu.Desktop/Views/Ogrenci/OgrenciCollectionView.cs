using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using OgrenciBursOtomasyonu.Desktop.Views.Common;
using DevExpress.Utils.MVVM.Services;
using DevExpress.Utils.MVVM.UI;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using OgrenciBursOtomasyonu.Api.Models;
using OgrenciModel = OgrenciBursOtomasyonu.Api.Models.Ogrenci;
using OgrenciBursOtomasyonu.Desktop.Common.ViewModel;
using OgrenciBursOtomasyonu.Desktop.ViewModels;

namespace OgrenciBursOtomasyonu.Desktop.Views.Ogrenci {
    [ViewType(OgrenciBursDbViewModel.OgrenciCollectionViewDocumentType)]
    public partial class OgrenciCollectionView : FilterCollectionViewBase {
        private readonly HttpClient _httpClient = new();
        private List<OgrenciTileDto> _allOgrenciler = new List<OgrenciTileDto>();
        private string _currentFilter = "Tüm Öğrenciler";
        private bool _refreshInProgress;
        private string _lastListSignature = string.Empty;
        private readonly System.Windows.Forms.Timer _autoRefreshTimer;
        private CancellationTokenSource _detailCts;
        private readonly SemaphoreSlim _detailSemaphore = new SemaphoreSlim(4, 4);
        private readonly HashSet<int> _detailsLoaded = new HashSet<int>();

        public OgrenciCollectionView() {
            InitializeComponent();
            gridControl.Visible = false;
            searchControl.SetupSearchControl(windowsUIButtonPanel);
            
            // Filtre event handler'ı ekle
            ogrenciFilterView.FilterChanged += OgrenciFilterView_FilterChanged;
            
            // TileView event handler'ları (çift tıklamada detay aç)
            tileView.ItemDoubleClick += TileView_ItemClick;
            
            // Buton event handler'larını ekle
            SetupButtons();
            
            // Verileri yükle
            Load += OgrenciCollectionView_Load;

            // "Anında gelsin" için: ekrana her dönüldüğünde + görünürken periyodik olarak yenile.
            _autoRefreshTimer = new System.Windows.Forms.Timer { Interval = 5000 };
            _autoRefreshTimer.Tick += async (_, __) => await TryRefreshAsync(force: false);
            VisibleChanged += (_, __) =>
            {
                if (Visible)
                    _autoRefreshTimer.Start();
                else
                    _autoRefreshTimer.Stop();
            };
            Disposed += (_, __) =>
            {
                try
                {
                    _autoRefreshTimer.Stop();
                    _autoRefreshTimer.Dispose();
                }
                catch
                {
                    // ignore
                }
            };
        }
        
        private void SetupButtons() {
            // Düzenle butonunu bul ve event handler ekle (index 0: Düzenle button)
            if (windowsUIButtonPanel.Buttons.Count > 0 && windowsUIButtonPanel.Buttons[0] is WindowsUIButton duzenleButton) {
                duzenleButton.Click += EditButton_Click;
                // İkon ayarla
                duzenleButton.ImageUri = Views.Common.ToolbarExtension.GetImageUri("Edit");
            }
            
            // Sil butonunu bul ve event handler ekle (index 1: Sil button)
            if (windowsUIButtonPanel.Buttons.Count > 1 && windowsUIButtonPanel.Buttons[1] is WindowsUIButton silButton) {
                silButton.Click += SilButton_Click;
                // İkon ayarla
                silButton.ImageUri = Views.Common.ToolbarExtension.GetImageUri("Delete");
            }
        }
        
        private async void EditButton_Click(object sender, EventArgs e) {
            var selectedOgrenci = tileView.GetFocusedRow() as OgrenciTileDto;
            if (selectedOgrenci == null || selectedOgrenci.Id <= 0) {
                XtraMessageBox.Show("Lütfen düzenlemek istediğiniz bir öğrenci seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                // FrmOgrenciDuzenle'yi aç
                using (var frm = new FrmOgrenciDuzenle(selectedOgrenci.Id)) {
                    frm.ShowDialog();
                }
                
                // Form kapatıldıktan sonra verileri yeniden yükle
                await TryRefreshAsync(force: true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SilButton_Click(object sender, EventArgs e) {
            var selectedOgrenci = tileView.GetFocusedRow() as OgrenciTileDto;
            if (selectedOgrenci == null || selectedOgrenci.Id <= 0) {
                XtraMessageBox.Show("Lütfen silmek istediğiniz bir öğrenci seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = XtraMessageBox.Show(
                $"'{selectedOgrenci.Ad} {selectedOgrenci.Soyad}' adlı öğrenciyi silmek istediğinizden emin misiniz?\n\n" +
                "Bu işlem geri alınamaz ve öğrencinin tüm verileri (burs kayıtları, ödeme takipleri dahil) silinecektir.",
                "Öğrenci Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
                return;

            try
            {
                var url = $"http://localhost:5215/api/ogrenciler/{selectedOgrenci.Id}";
                var response = await _httpClient.DeleteAsync(url);
                
                if (!response.IsSuccessStatusCode)
                {
                    var hata = await response.Content.ReadAsStringAsync();
                    XtraMessageBox.Show($"Öğrenci silinemedi:\n{hata}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                XtraMessageBox.Show("Öğrenci başarıyla silindi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Verileri yeniden yükle
                await TryRefreshAsync(force: true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Silme işlemi sırasında hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void OgrenciFilterView_FilterChanged(object sender, string filterName) {
            _currentFilter = filterName;
            ApplyFilter();
            
            // Filtre sayılarını güncelle
            UpdateFilterCounts();
        }
        
        private void ApplyFilter() {
            List<OgrenciTileDto> filteredList = _currentFilter switch {
                "Burs Alanlar" => _allOgrenciler.Where(o => !string.IsNullOrWhiteSpace(o.BursDurumu) && o.BursDurumu.ToLower() != "burs almıyor").ToList(),
                "Burs Almayanlar" => _allOgrenciler.Where(o => string.IsNullOrWhiteSpace(o.BursDurumu) || o.BursDurumu.ToLower() == "burs almıyor").ToList(),
                _ => _allOgrenciler.ToList() // "Tüm Öğrenciler"
            };
            
            ogrenciBindingSource.DataSource = filteredList;
            ogrenciBindingSource.ResetBindings(false);
        }
        
        private void UpdateFilterCounts() {
            int allCount = _allOgrenciler.Count;
            int withBursCount = _allOgrenciler.Count(o => !string.IsNullOrWhiteSpace(o.BursDurumu) && o.BursDurumu.ToLower() != "burs almıyor");
            int withoutBursCount = _allOgrenciler.Count(o => string.IsNullOrWhiteSpace(o.BursDurumu) || o.BursDurumu.ToLower() == "burs almıyor");
            
            ogrenciFilterView.UpdateFilterCounts(allCount, withBursCount, withoutBursCount);
        }

        private async void OgrenciCollectionView_Load(object sender, EventArgs e)
        {
            await TryRefreshAsync(force: true);
        }

        protected override void DocumentShownMessageReceived(DocumentShownMessage msg)
        {
            if (msg == null || msg.DocumentType != OgrenciBursDbViewModel.OgrenciCollectionViewDocumentType)
                return;

            _ = TryRefreshAsync(force: true);
        }

        private async Task TryRefreshAsync(bool force)
        {
            if (!IsHandleCreated || IsDisposed)
                return;
            if (_refreshInProgress)
                return;

            _refreshInProgress = true;
            try
            {
                await OgrencileriYukleAsync(force);
            }
            finally
            {
                _refreshInProgress = false;
            }
        }

        private async Task OgrencileriYukleAsync(bool force)
        {
            try
            {
                var url = "http://localhost:5215/api/ogrenciler";
                var response = await _httpClient.GetAsync(url).ConfigureAwait(false);
                
                if (response.IsSuccessStatusCode)
                {
                    var ogrenciListeDto = await response.Content.ReadFromJsonAsync<List<OgrenciListeDto>>().ConfigureAwait(false) 
                                         ?? new List<OgrenciListeDto>();

                    // Basit değişiklik algılama: ekleme/silme gibi durumlarda hızlıca yenile.
                    int maxId = ogrenciListeDto.Count == 0 ? 0 : ogrenciListeDto.Max(x => x.Id);
                    string signature = $"{ogrenciListeDto.Count}:{maxId}";
                    if (!force && signature == _lastListSignature)
                        return;
                    _lastListSignature = signature;
                    
                    // Önce temel verileri yükle (hızlı)
                    var ogrenciTileList = ogrenciListeDto.Select(dto => new OgrenciTileDto
                    {
                        Id = dto.Id,
                        TcKimlikNo = dto.TcKimlikNo,
                        Ad = dto.Ad,
                        Soyad = dto.Soyad,
                        Email = dto.Email,
                        Yas = dto.Yas,
                        Puan = dto.Puan,
                        BursDurumu = dto.BursDurumu,
                        BursAdi = dto.BursAdi
                    }).ToList();
                    
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
                    
                    // Arka planda detay bilgilerini yükle (fotoğraf, telefon, üniversite vb.)
                    // Not: Tüm öğrenciler için aynı anda detay çağrısı yapmak API'yi kilitleyip timeout'a sebep olabiliyor.
                    // Bu yüzden iptal edilebilir + throttle edilmiş şekilde çalıştırıyoruz ve sadece eksik detayları yüklüyoruz.
                    StartLoadDetails(ogrenciListeDto, ogrenciTileList, force);
                }
                else
                {
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            XtraMessageBox.Show($"API'den veri alınamadı. Durum: {response.StatusCode}", 
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ogrenciBindingSource.DataSource = new List<OgrenciTileDto>();
                        }));
                    }
                    else
                    {
                        XtraMessageBox.Show($"API'den veri alınamadı. Durum: {response.StatusCode}", 
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ogrenciBindingSource.DataSource = new List<OgrenciTileDto>();
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
                        ogrenciBindingSource.DataSource = new List<OgrenciTileDto>();
                    }));
                }
                else
                {
                    XtraMessageBox.Show($"Bağlantı hatası: {ex.Message}", 
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ogrenciBindingSource.DataSource = new List<OgrenciTileDto>();
                }
            }
        }

        private void StartLoadDetails(List<OgrenciListeDto> ogrenciListeDto, List<OgrenciTileDto> ogrenciTileList, bool force)
        {
            try
            {
                _detailCts?.Cancel();
                _detailCts?.Dispose();
            }
            catch { /* ignore */ }

            _detailCts = new CancellationTokenSource();
            var token = _detailCts.Token;

            // Yeni kayıtlar için detay yükle; çok büyük listelerde API'yi boğmamak için batch'le.
            // İsterseniz artırılabilir.
            var toLoad = ogrenciListeDto
                .Where(dto => force || !_detailsLoaded.Contains(dto.Id))
                .Take(30)
                .ToList();

            if (toLoad.Count == 0)
                return;

            _ = Task.Run(async () =>
            {
                foreach (var dto in toLoad)
                {
                    if (token.IsCancellationRequested)
                        break;

                    await _detailSemaphore.WaitAsync(token).ConfigureAwait(false);
                    _ = LoadSingleDetailAsync(dto.Id, ogrenciTileList, token)
                        .ContinueWith(_ => _detailSemaphore.Release(), TaskScheduler.Default);
                }
            }, token);
        }

        private async Task LoadSingleDetailAsync(int ogrenciId, List<OgrenciTileDto> ogrenciTileList, CancellationToken token)
        {
            try
            {
                var detayResponse = await _httpClient.GetAsync($"http://localhost:5215/api/ogrenciler/{ogrenciId}", token).ConfigureAwait(false);
                if (!detayResponse.IsSuccessStatusCode)
                    return;

                var ogrenci = await detayResponse.Content.ReadFromJsonAsync<OgrenciModel>(cancellationToken: token).ConfigureAwait(false);
                if (ogrenci == null)
                    return;

                void Apply()
                {
                    var existingItem = ogrenciTileList.FirstOrDefault(x => x.Id == ogrenciId);
                    if (existingItem == null)
                        return;

                    existingItem.Telefon = ogrenci.Telefon ?? "";
                    existingItem.ResimYolu = ogrenci.ResimYolu ?? "";
                    existingItem.Universite = ogrenci.Universite ?? "";
                    existingItem.Bolum = ogrenci.Bolum ?? "";

                    _detailsLoaded.Add(ogrenciId);
                    ogrenciBindingSource.ResetBindings(false);
                }

                if (IsDisposed || !IsHandleCreated)
                    return;

                if (InvokeRequired)
                    BeginInvoke((MethodInvoker)Apply);
                else
                    Apply();
            }
            catch (OperationCanceledException)
            {
                // ignore
            }
            catch
            {
                // Detay alınamazsa sessizce devam et
            }
        }
        
        private void UpdateOgrenciGrid(List<OgrenciTileDto> ogrenciTileList)
        {
            // Tüm öğrencileri sakla
            _allOgrenciler = ogrenciTileList;
            
            // Filtre uygula
            ApplyFilter();
            
            // Filtre sayılarını güncelle
            UpdateFilterCounts();
            
            // Grid'i göster
            gridControl.Visible = true;
        }

        // TileView ItemClick event'i - Öğrenciye tıklandığında detay formunu aç
        private async void TileView_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            var ogrenci = tileView.GetRow(e.Item.RowHandle) as OgrenciTileDto;
            if (ogrenci == null || ogrenci.Id <= 0)
            {
                return;
            }
            
            try
            {
                // FrmOgrenciDetay'ı aç (detay ve AI raporu için)
                using (var frmDetay = new FrmOgrenciDetay(ogrenci.Id))
                {
                    frmDetay.ShowDialog();
                }
                
                // Form kapatıldıktan sonra verileri yeniden yükle
                await TryRefreshAsync(force: true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// TileView için kullanılacak DTO - OgrenciListeDto + TileView için gerekli alanlar.
        /// </summary>
        public class OgrenciTileDto
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
            public string Telefon { get; set; } = string.Empty;
            public string ResimYolu { get; set; } = string.Empty;
            public string Universite { get; set; } = string.Empty;
            public string Bolum { get; set; } = string.Empty;
            
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

        // TODO: Implement InitBindings when ViewModels are ready
        /*
        void InitBindings() {
            mvvmContext.RegisterService("FlyoutDocumentManagerService", WindowedDocumentManagerService.CreateFlyoutFormService(this));
            mvvmContext.BindTileGrid<OgrenciCollectionViewModel, Ogrenci>(tileView, ogrenciBindingSource);
            
            var fluentAPI = mvvmContext.OfType<OgrenciCollectionViewModel>();
            ((WindowsUIButton)windowsUIButtonPanel.Buttons[0]).ImageUri = ToolbarExtension.GetImageUri("SortAZ");
            ((WindowsUIButton)windowsUIButtonPanel.Buttons[0]).Click += (s, e) => SortOgrenciler(true);
            ((WindowsUIButton)windowsUIButtonPanel.Buttons[1]).ImageUri = ToolbarExtension.GetImageUri("SortZA");
            ((WindowsUIButton)windowsUIButtonPanel.Buttons[1]).Click += (s, e) => SortOgrenciler(false);
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[3], x => x.New());
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[4], (x, e) => x.Edit(e), x => x.SelectedEntity);
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[8], (x, e) => x.ShowMailMerge(e), x => x.SelectedEntity, "MailMerge");
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[9], (x, e) => x.ShowTask(e), x => x.SelectedEntity, "Task");
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[10], (x, e) => x.ShowNote(e), x => x.SelectedEntity, "Note");
            ((WindowsUIButton)windowsUIButtonPanel.Buttons[6]).Tag = ToolbarExtension.CreateReportsGallery<OgrenciCollectionViewModel>(fluentAPI, (x, type) => x.ShowReportForSelectedEntity(type));
            ((WindowsUIButton)windowsUIButtonPanel.Buttons[6]).ImageUri = ToolbarExtension.GetImageUri("Print");
        }
        void SortOgrenciler(bool ascending) {
            var lastName = tileView.Columns["FullName"];
            if(lastName == null)
                return;
            tileView.SortInfo.Clear();
            tileView.SortInfo.Add(new XtraGrid.Columns.GridColumnSortInfo(lastName, ascending ? Data.ColumnSortOrder.Ascending : Data.ColumnSortOrder.Descending));
        }
        protected override void DocumentShownMessageReceived(DocumentShownMessage msg) {
            if(msg.DocumentType != OgrenciBursDbViewModel.OgrenciCollectionViewDocumentType)
                return;
            var fluentAPI = mvvmContext.OfType<OgrenciCollectionViewModel>();
            ogrenciFilterView.SetViewModel(fluentAPI.ViewModel.FilterViewModel);
            BeginInvoke(new System.Action(() => gridControl.Visible = true));
        }
        */
    }
}

