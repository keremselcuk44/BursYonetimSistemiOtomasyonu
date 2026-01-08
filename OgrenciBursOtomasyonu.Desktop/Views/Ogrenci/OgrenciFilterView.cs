using System;
using System.Linq;
using System.Windows.Forms;
using OgrenciBursOtomasyonu.Desktop.ViewModels;
using DevExpress.XtraEditors;
using OgrenciBursOtomasyonu.Desktop.Views.Common;

namespace OgrenciBursOtomasyonu.Desktop.Views.Ogrenci {
    public partial class OgrenciFilterView : BaseFilterView {
        public event EventHandler<string> FilterChanged;
        
        private const string FilterAll = "Tüm Öğrenciler";
        private const string FilterWithBurs = "Burs Alanlar";
        private const string FilterWithoutBurs = "Burs Almayanlar";
        
        public OgrenciFilterView() {
            InitializeComponent();
            Load += OgrenciFilterView_Load;
        }
        
        private void OgrenciFilterView_Load(object sender, EventArgs e) {
            CreateFilterButtons();
        }
        
        private void CreateFilterButtons() {
            // Mevcut butonları temizle
            tileGroup2.Items.Clear();
            
            // Tüm Öğrenciler
            var tileAll = CreateFilterTile(FilterAll, 0);
            tileGroup2.Items.Add(tileAll);
            
            // Burs Alanlar
            var tileWithBurs = CreateFilterTile(FilterWithBurs, 0);
            tileGroup2.Items.Add(tileWithBurs);
            
            // Burs Almayanlar
            var tileWithoutBurs = CreateFilterTile(FilterWithoutBurs, 0);
            tileGroup2.Items.Add(tileWithoutBurs);
            
            // Varsayılan seçili: Tüm Öğrenciler
            filterTileControl.SelectedItem = tileAll;
            
            // Event handler'ı ekle
            filterTileControl.ItemClick += FilterTileControl_ItemClick;
        }
        
        private TileItem CreateFilterTile(string filterName, int count) {
            TileItem tile = new TileItem();
            tile.ItemSize = TileItemSize.Wide;
            tile.Tag = filterName;
            
            // Sayı gösterimi (şimdilik 0, sonra güncellenecek)
            TileItemElement element1 = new TileItemElement();
            element1.Appearance.Normal.FontSizeDelta = 128;
            element1.Appearance.Normal.ForeColor = System.Drawing.Color.FromArgb(171, 171, 171);
            element1.Appearance.Normal.Options.UseFont = true;
            element1.Appearance.Normal.Options.UseForeColor = true;
            element1.Appearance.Selected.FontSizeDelta = 128;
            element1.Appearance.Selected.ForeColor = System.Drawing.Color.FromArgb(151, 168, 209);
            element1.Appearance.Selected.Options.UseFont = true;
            element1.Appearance.Selected.Options.UseForeColor = true;
            element1.Appearance.Pressed.FontSizeDelta = 128;
            element1.Appearance.Pressed.ForeColor = System.Drawing.Color.FromArgb(151, 168, 209);
            element1.Appearance.Pressed.Options.UseFont = true;
            element1.Appearance.Pressed.Options.UseForeColor = true;
            element1.TextAlignment = TileItemContentAlignment.TopRight;
            element1.TextLocation = new System.Drawing.Point(-2, -12);
            element1.Text = count.ToString();
            tile.Elements.Add(element1);
            
            // İsim gösterimi
            TileItemElement element2 = new TileItemElement();
            element2.Text = filterName;
            element2.TextAlignment = TileItemContentAlignment.BottomLeft;
            tile.Elements.Add(element2);
            
            return tile;
        }
        
        private void FilterTileControl_ItemClick(object sender, TileItemEventArgs e) {
            if (e.Item?.Tag is string filterName) {
                // Tıklanan butonu seçili yap
                filterTileControl.SelectedItem = e.Item;
                
                // Event'i fire et
                FilterChanged?.Invoke(this, filterName);
            }
        }
        
        public void UpdateFilterCounts(int allCount, int withBursCount, int withoutBursCount) {
            foreach (var item in tileGroup2.Items) {
                if (item is TileItem tileItem && tileItem.Tag is string filterName) {
                    int count = filterName switch {
                        FilterAll => allCount,
                        FilterWithBurs => withBursCount,
                        FilterWithoutBurs => withoutBursCount,
                        _ => 0
                    };
                    
                    if (tileItem.Elements.Count > 0) {
                        tileItem.Elements[0].Text = count.ToString();
                    }
                }
            }
        }
        
        void InitBindings() {
            // MVVM binding yerine doğrudan event handler kullanıyoruz
        }
        protected override void Init() {
            InitBindings();
        }
    }
}

