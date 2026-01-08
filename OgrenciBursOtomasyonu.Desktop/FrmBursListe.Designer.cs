using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;

namespace OgrenciBursOtomasyonu.Desktop
{
    partial class FrmBursListe
    {
        private System.ComponentModel.IContainer components = null;
        private LayoutControl layoutControl1;
        private LabelControl labelControlBaslik;
        private GridControl gridControlBurslar;
        private GridView gridViewBurslar;
        private GroupControl groupControlBursDetay;
        private LabelControl lblBursAdi;
        private LabelControl lblMinimumPuan;
        private LabelControl lblKontenjan;
        private LabelControl lblAylikTutar;
        private SimpleButton btnBursDuzenle;
        private GroupControl groupControlOgrenciler;
        private GridControl gridControlOgrenciler;
        private GridView gridViewOgrenciler;
        private LabelControl lblOgrenciSayisi;
        private SimpleButton btnYenile;
        private SimpleButton btnBursProgramindanCikar;
        private LayoutControlGroup Root;
        private LayoutControlItem layoutControlItemBaslik;
        private LayoutControlItem layoutControlItemBursGrid;
        private LayoutControlItem layoutControlItemBursDetay;
        private LayoutControlItem layoutControlItemBursDuzenle;
        private LayoutControlItem layoutControlItemOgrenciler;
        private LayoutControlItem layoutControlItemButtons;
        private LayoutControlItem layoutControlItemYenile;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.layoutControl1 = new LayoutControl();
            this.labelControlBaslik = new LabelControl();
            this.btnYenile = new SimpleButton();
            this.btnBursProgramindanCikar = new SimpleButton();
            this.groupControlOgrenciler = new GroupControl();
            this.lblOgrenciSayisi = new LabelControl();
            this.gridControlOgrenciler = new GridControl();
            this.gridViewOgrenciler = new GridView();
            this.btnBursDuzenle = new SimpleButton();
            this.groupControlBursDetay = new GroupControl();
            this.lblAylikTutar = new LabelControl();
            this.lblKontenjan = new LabelControl();
            this.lblMinimumPuan = new LabelControl();
            this.lblBursAdi = new LabelControl();
            this.gridControlBurslar = new GridControl();
            this.gridViewBurslar = new GridView();
            this.Root = new LayoutControlGroup();
            this.layoutControlItemBaslik = new LayoutControlItem();
            this.layoutControlItemBursGrid = new LayoutControlItem();
            this.layoutControlItemBursDetay = new LayoutControlItem();
            this.layoutControlItemBursDuzenle = new LayoutControlItem();
            this.layoutControlItemOgrenciler = new LayoutControlItem();
            this.layoutControlItemButtons = new LayoutControlItem();
            this.layoutControlItemYenile = new LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOgrenciler)).BeginInit();
            this.groupControlOgrenciler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOgrenciler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOgrenciler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBursDetay)).BeginInit();
            this.groupControlBursDetay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBurslar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBurslar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBaslik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBursGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBursDetay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBursDuzenle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemOgrenciler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemYenile)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.labelControlBaslik);
            this.layoutControl1.Controls.Add(this.btnYenile);
            this.layoutControl1.Controls.Add(this.btnBursProgramindanCikar);
            this.layoutControl1.Controls.Add(this.groupControlOgrenciler);
            this.layoutControl1.Controls.Add(this.btnBursDuzenle);
            this.layoutControl1.Controls.Add(this.groupControlBursDetay);
            this.layoutControl1.Controls.Add(this.gridControlBurslar);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(874, 0, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1376, 700);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // labelControlBaslik
            // 
            this.labelControlBaslik.AllowHtmlString = true;
            this.labelControlBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControlBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.labelControlBaslik.Appearance.Options.UseFont = true;
            this.labelControlBaslik.Appearance.Options.UseForeColor = true;
            this.labelControlBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControlBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControlBaslik.Location = new System.Drawing.Point(12, 12);
            this.labelControlBaslik.Name = "labelControlBaslik";
            this.labelControlBaslik.Size = new System.Drawing.Size(1352, 25);
            this.labelControlBaslik.StyleController = this.layoutControl1;
            this.labelControlBaslik.TabIndex = 4;
            this.labelControlBaslik.Text = "BURSLAR";
            // 
            // btnYenile
            // 
            this.btnYenile.Location = new System.Drawing.Point(1260, 644);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(104, 32);
            this.btnYenile.StyleController = this.layoutControl1;
            this.btnYenile.TabIndex = 6;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnBursProgramindanCikar
            // 
            this.btnBursProgramindanCikar.Location = new System.Drawing.Point(1148, 644);
            this.btnBursProgramindanCikar.Name = "btnBursProgramindanCikar";
            this.btnBursProgramindanCikar.Size = new System.Drawing.Size(108, 32);
            this.btnBursProgramindanCikar.StyleController = this.layoutControl1;
            this.btnBursProgramindanCikar.TabIndex = 7;
            this.btnBursProgramindanCikar.Text = "Burs Programından Çıkar";
            this.btnBursProgramindanCikar.Click += new System.EventHandler(this.btnBursProgramindanCikar_Click);
            // 
            // groupControlOgrenciler
            // 
            this.groupControlOgrenciler.Controls.Add(this.lblOgrenciSayisi);
            this.groupControlOgrenciler.Controls.Add(this.gridControlOgrenciler);
            this.groupControlOgrenciler.Location = new System.Drawing.Point(12, 317);
            this.groupControlOgrenciler.Name = "groupControlOgrenciler";
            this.groupControlOgrenciler.Size = new System.Drawing.Size(1352, 323);
            this.groupControlOgrenciler.TabIndex = 5;
            this.groupControlOgrenciler.Text = "Bu Bursu Alan Öğrenciler";
            // 
            // lblOgrenciSayisi
            // 
            this.lblOgrenciSayisi.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblOgrenciSayisi.Appearance.Options.UseFont = true;
            this.lblOgrenciSayisi.Location = new System.Drawing.Point(20, 25);
            this.lblOgrenciSayisi.Name = "lblOgrenciSayisi";
            this.lblOgrenciSayisi.Size = new System.Drawing.Size(200, 14);
            this.lblOgrenciSayisi.TabIndex = 1;
            this.lblOgrenciSayisi.Text = "Bu Bursu Alan Öğrenci Sayısı: 0";
            // 
            // gridControlOgrenciler
            // 
            this.gridControlOgrenciler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlOgrenciler.Location = new System.Drawing.Point(5, 45);
            this.gridControlOgrenciler.MainView = this.gridViewOgrenciler;
            this.gridControlOgrenciler.Name = "gridControlOgrenciler";
            this.gridControlOgrenciler.Size = new System.Drawing.Size(1342, 273);
            this.gridControlOgrenciler.TabIndex = 0;
            this.gridControlOgrenciler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOgrenciler});
            // 
            // gridViewOgrenciler
            // 
            this.gridViewOgrenciler.GridControl = this.gridControlOgrenciler;
            this.gridViewOgrenciler.Name = "gridViewOgrenciler";
            this.gridViewOgrenciler.OptionsView.ShowGroupPanel = false;
            // 
            // btnBursDuzenle
            // 
            this.btnBursDuzenle.Location = new System.Drawing.Point(548, 287);
            this.btnBursDuzenle.Name = "btnBursDuzenle";
            this.btnBursDuzenle.Size = new System.Drawing.Size(120, 26);
            this.btnBursDuzenle.StyleController = this.layoutControl1;
            this.btnBursDuzenle.TabIndex = 8;
            this.btnBursDuzenle.Text = "Burs Düzenle";
            this.btnBursDuzenle.Click += new System.EventHandler(this.btnBursDuzenle_Click);
            // 
            // groupControlBursDetay
            // 
            this.groupControlBursDetay.Controls.Add(this.lblAylikTutar);
            this.groupControlBursDetay.Controls.Add(this.lblKontenjan);
            this.groupControlBursDetay.Controls.Add(this.lblMinimumPuan);
            this.groupControlBursDetay.Controls.Add(this.lblBursAdi);
            this.groupControlBursDetay.Location = new System.Drawing.Point(548, 41);
            this.groupControlBursDetay.Name = "groupControlBursDetay";
            this.groupControlBursDetay.Size = new System.Drawing.Size(816, 242);
            this.groupControlBursDetay.TabIndex = 3;
            this.groupControlBursDetay.Text = "Burs Detayları";
            // 
            // lblAylikTutar
            // 
            this.lblAylikTutar.Location = new System.Drawing.Point(20, 120);
            this.lblAylikTutar.Name = "lblAylikTutar";
            this.lblAylikTutar.Size = new System.Drawing.Size(70, 13);
            this.lblAylikTutar.TabIndex = 3;
            this.lblAylikTutar.Text = "Aylık Tutar:";
            // 
            // lblKontenjan
            // 
            this.lblKontenjan.Location = new System.Drawing.Point(20, 90);
            this.lblKontenjan.Name = "lblKontenjan";
            this.lblKontenjan.Size = new System.Drawing.Size(53, 13);
            this.lblKontenjan.TabIndex = 2;
            this.lblKontenjan.Text = "Kontenjan:";
            // 
            // lblMinimumPuan
            // 
            this.lblMinimumPuan.Location = new System.Drawing.Point(20, 60);
            this.lblMinimumPuan.Name = "lblMinimumPuan";
            this.lblMinimumPuan.Size = new System.Drawing.Size(74, 13);
            this.lblMinimumPuan.TabIndex = 1;
            this.lblMinimumPuan.Text = "Minimum Puan:";
            // 
            // lblBursAdi
            // 
            this.lblBursAdi.Location = new System.Drawing.Point(20, 30);
            this.lblBursAdi.Name = "lblBursAdi";
            this.lblBursAdi.Size = new System.Drawing.Size(60, 13);
            this.lblBursAdi.TabIndex = 0;
            this.lblBursAdi.Text = "Burs Adı:";
            // 
            // gridControlBurslar
            // 
            this.gridControlBurslar.Location = new System.Drawing.Point(12, 41);
            this.gridControlBurslar.MainView = this.gridViewBurslar;
            this.gridControlBurslar.Name = "gridControlBurslar";
            this.gridControlBurslar.Size = new System.Drawing.Size(532, 242);
            this.gridControlBurslar.TabIndex = 4;
            this.gridControlBurslar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewBurslar});
            // 
            // gridViewBurslar
            // 
            this.gridViewBurslar.GridControl = this.gridControlBurslar;
            this.gridViewBurslar.Name = "gridViewBurslar";
            this.gridViewBurslar.OptionsSelection.MultiSelect = false;
            this.gridViewBurslar.OptionsView.ShowGroupPanel = false;
            this.gridViewBurslar.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewBurslar_FocusedRowChanged);
            this.gridViewBurslar.DoubleClick += new System.EventHandler(this.gridViewBurslar_DoubleClick);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemBaslik,
            this.layoutControlItemBursGrid,
            this.layoutControlItemBursDetay,
            this.layoutControlItemBursDuzenle,
            this.layoutControlItemOgrenciler,
            this.layoutControlItemButtons,
            this.layoutControlItemYenile});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(12, 12, 12, 12);
            this.Root.Size = new System.Drawing.Size(1376, 700);
            this.Root.TextVisible = false;
            // 
            // layoutControlItemBaslik
            // 
            this.layoutControlItemBaslik.Control = this.labelControlBaslik;
            this.layoutControlItemBaslik.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemBaslik.Name = "layoutControlItemBaslik";
            this.layoutControlItemBaslik.Size = new System.Drawing.Size(1356, 29);
            this.layoutControlItemBaslik.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBaslik.TextVisible = false;
            // 
            // layoutControlItemBursGrid
            // 
            this.layoutControlItemBursGrid.Control = this.gridControlBurslar;
            this.layoutControlItemBursGrid.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItemBursGrid.Name = "layoutControlItemBursGrid";
            this.layoutControlItemBursGrid.Size = new System.Drawing.Size(536, 246);
            this.layoutControlItemBursGrid.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBursGrid.TextVisible = false;
            // 
            // layoutControlItemBursDetay
            // 
            this.layoutControlItemBursDetay.Control = this.groupControlBursDetay;
            this.layoutControlItemBursDetay.Location = new System.Drawing.Point(536, 29);
            this.layoutControlItemBursDetay.Name = "layoutControlItemBursDetay";
            this.layoutControlItemBursDetay.Size = new System.Drawing.Size(820, 246);
            this.layoutControlItemBursDetay.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBursDetay.TextVisible = false;
            // 
            // layoutControlItemBursDuzenle
            // 
            this.layoutControlItemBursDuzenle.Control = this.btnBursDuzenle;
            this.layoutControlItemBursDuzenle.Location = new System.Drawing.Point(536, 275);
            this.layoutControlItemBursDuzenle.Name = "layoutControlItemBursDuzenle";
            this.layoutControlItemBursDuzenle.Size = new System.Drawing.Size(124, 30);
            this.layoutControlItemBursDuzenle.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBursDuzenle.TextVisible = false;
            // 
            // layoutControlItemOgrenciler
            // 
            this.layoutControlItemOgrenciler.Control = this.groupControlOgrenciler;
            this.layoutControlItemOgrenciler.Location = new System.Drawing.Point(0, 305);
            this.layoutControlItemOgrenciler.Name = "layoutControlItemOgrenciler";
            this.layoutControlItemOgrenciler.Size = new System.Drawing.Size(1356, 297);
            this.layoutControlItemOgrenciler.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemOgrenciler.TextVisible = false;
            // 
            // layoutControlItemButtons
            // 
            this.layoutControlItemButtons.Control = this.btnBursProgramindanCikar;
            this.layoutControlItemButtons.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItemButtons.Location = new System.Drawing.Point(1020, 602);
            this.layoutControlItemButtons.MinSize = new System.Drawing.Size(108, 32);
            this.layoutControlItemButtons.Name = "layoutControlItemButtons";
            this.layoutControlItemButtons.Size = new System.Drawing.Size(108, 36);
            this.layoutControlItemButtons.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemButtons.TextVisible = false;
            // 
            // layoutControlItemYenile
            // 
            this.layoutControlItemYenile.Control = this.btnYenile;
            this.layoutControlItemYenile.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItemYenile.Location = new System.Drawing.Point(1128, 602);
            this.layoutControlItemYenile.MinSize = new System.Drawing.Size(104, 32);
            this.layoutControlItemYenile.Name = "layoutControlItemYenile";
            this.layoutControlItemYenile.Size = new System.Drawing.Size(108, 36);
            this.layoutControlItemYenile.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemYenile.TextVisible = false;
            // 
            // FrmBursListe
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1376, 700);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmBursListe";
            this.Text = "Burslar";
            this.Load += new System.EventHandler(this.FrmBursListe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOgrenciler)).EndInit();
            this.groupControlOgrenciler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOgrenciler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOgrenciler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBursDetay)).EndInit();
            this.groupControlBursDetay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBurslar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBurslar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBaslik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBursGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBursDetay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBursDuzenle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemOgrenciler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemYenile)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
