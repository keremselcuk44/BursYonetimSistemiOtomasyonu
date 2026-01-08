using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OgrenciBursOtomasyonu.Desktop.ViewModels;
using DevExpress.XtraEditors;
using OgrenciBursOtomasyonu.Desktop.Views.Common;
using BursModel = OgrenciBursOtomasyonu.Api.Models.Burs;

namespace OgrenciBursOtomasyonu.Desktop.Views.Burs {
    public partial class BursFilterView : BaseFilterView {
        public event EventHandler<BursModel> BursChanged;
        
        public BursFilterView() {
            InitializeComponent();
            Load += BursFilterView_Load;
        }
        
        private void BursFilterView_Load(object sender, EventArgs e) {
            // Burslar yüklendikten sonra butonlar oluşturulacak
        }
        
        public void LoadBurslar(List<BursModel> burslar) {
            CreateBursButtons(burslar);
        }
        
        private void CreateBursButtons(List<BursModel> burslar) {
            // Mevcut butonları temizle
            tileGroup2.Items.Clear();
            
            // Event handler'ı bir kez ekle (eğer eklenmemişse)
            filterTileControl.ItemClick -= FilterTileControl_ItemClick;
            filterTileControl.ItemClick += FilterTileControl_ItemClick;
            
            foreach (var burs in burslar) {
                var tile = CreateBursTile(burs);
                tileGroup2.Items.Add(tile);
            }
            
            // İlk burs seçili olsun (varsa)
            if (tileGroup2.Items.Count > 0) {
                filterTileControl.SelectedItem = tileGroup2.Items[0];
            }
        }
        
        private TileItem CreateBursTile(BursModel burs) {
            TileItem tile = new TileItem();
            tile.ItemSize = TileItemSize.Wide;
            tile.Tag = burs;
            
            // Burs adı gösterimi
            TileItemElement element = new TileItemElement();
            element.Text = burs.BursAdi;
            element.TextAlignment = TileItemContentAlignment.MiddleCenter;
            tile.Elements.Add(element);
            
            return tile;
        }
        
        private void FilterTileControl_ItemClick(object sender, TileItemEventArgs e) {
            if (e.Item?.Tag is BursModel burs) {
                // Tıklanan bursu seçili yap
                filterTileControl.SelectedItem = e.Item;
                
                // Event'i fire et
                BursChanged?.Invoke(this, burs);
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

