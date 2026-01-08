using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;

namespace OgrenciBursOtomasyonu.Desktop
{
    partial class FrmKullaniciIslemleri
    {
        private System.ComponentModel.IContainer components = null;
        private LayoutControl layoutControl1;
        private LabelControl labelControlBaslik;
        private GridControl gridControlKullanicilar;
        private GridView gridViewKullanicilar;
        private GroupControl groupControlKullaniciDetay;
        private LabelControl lblKullaniciAdi;
        private TextEdit txtKullaniciAdi;
        private LabelControl lblYeniSifre;
        private TextEdit txtYeniSifre;
        private CheckEdit chkAktif;
        private LabelControl lblOlusturmaTarihi;
        private TextEdit txtOlusturmaTarihi;
        private SimpleButton btnKaydet;
        private SimpleButton btnYeni;
        private SimpleButton btnSil;
        private SimpleButton btnYenile;
        private LayoutControlGroup Root;
        private LayoutControlItem layoutControlItemBaslik;
        private LayoutControlItem layoutControlItemGrid;
        private LayoutControlItem layoutControlItemGroup;

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
            this.groupControlKullaniciDetay = new GroupControl();
            this.btnSil = new SimpleButton();
            this.btnYeni = new SimpleButton();
            this.btnKaydet = new SimpleButton();
            this.txtOlusturmaTarihi = new TextEdit();
            this.lblOlusturmaTarihi = new LabelControl();
            this.chkAktif = new CheckEdit();
            this.txtYeniSifre = new TextEdit();
            this.lblYeniSifre = new LabelControl();
            this.txtKullaniciAdi = new TextEdit();
            this.lblKullaniciAdi = new LabelControl();
            this.gridControlKullanicilar = new GridControl();
            this.gridViewKullanicilar = new GridView();
            this.Root = new LayoutControlGroup();
            this.layoutControlItemBaslik = new LayoutControlItem();
            this.layoutControlItemGrid = new LayoutControlItem();
            this.layoutControlItemGroup = new LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlKullaniciDetay)).BeginInit();
            this.groupControlKullaniciDetay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOlusturmaTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktif.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlKullanicilar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewKullanicilar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBaslik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.labelControlBaslik);
            this.layoutControl1.Controls.Add(this.btnYenile);
            this.layoutControl1.Controls.Add(this.groupControlKullaniciDetay);
            this.layoutControl1.Controls.Add(this.gridControlKullanicilar);
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
            this.labelControlBaslik.Text = "KULLANICI İŞLEMLERİ";
            // 
            // btnYenile
            // 
            this.btnYenile.Location = new System.Drawing.Point(1260, 644);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(104, 32);
            this.btnYenile.StyleController = this.layoutControl1;
            this.btnYenile.TabIndex = 5;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // groupControlKullaniciDetay
            // 
            this.groupControlKullaniciDetay.Controls.Add(this.btnSil);
            this.groupControlKullaniciDetay.Controls.Add(this.btnYeni);
            this.groupControlKullaniciDetay.Controls.Add(this.btnKaydet);
            this.groupControlKullaniciDetay.Controls.Add(this.txtOlusturmaTarihi);
            this.groupControlKullaniciDetay.Controls.Add(this.lblOlusturmaTarihi);
            this.groupControlKullaniciDetay.Controls.Add(this.chkAktif);
            this.groupControlKullaniciDetay.Controls.Add(this.txtYeniSifre);
            this.groupControlKullaniciDetay.Controls.Add(this.lblYeniSifre);
            this.groupControlKullaniciDetay.Controls.Add(this.txtKullaniciAdi);
            this.groupControlKullaniciDetay.Controls.Add(this.lblKullaniciAdi);
            this.groupControlKullaniciDetay.Location = new System.Drawing.Point(536, 41);
            this.groupControlKullaniciDetay.Name = "groupControlKullaniciDetay";
            this.groupControlKullaniciDetay.Size = new System.Drawing.Size(828, 599);
            this.groupControlKullaniciDetay.TabIndex = 3;
            this.groupControlKullaniciDetay.Text = "Kullanıcı Detayları";
            // 
            // btnSil
            // 
            this.btnSil.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSil.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSil.Appearance.Options.UseBackColor = true;
            this.btnSil.Appearance.Options.UseForeColor = true;
            this.btnSil.Location = new System.Drawing.Point(120, 270);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(120, 35);
            this.btnSil.TabIndex = 7;
            this.btnSil.Text = "Kullanıcı Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnYeni
            // 
            this.btnYeni.Location = new System.Drawing.Point(250, 220);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(120, 35);
            this.btnYeni.TabIndex = 6;
            this.btnYeni.Text = "Yeni Kullanıcı";
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(120, 220);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(120, 35);
            this.btnKaydet.TabIndex = 5;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtOlusturmaTarihi
            // 
            this.txtOlusturmaTarihi.Location = new System.Drawing.Point(120, 157);
            this.txtOlusturmaTarihi.Name = "txtOlusturmaTarihi";
            this.txtOlusturmaTarihi.Properties.ReadOnly = true;
            this.txtOlusturmaTarihi.Size = new System.Drawing.Size(300, 22);
            this.txtOlusturmaTarihi.TabIndex = 4;
            // 
            // lblOlusturmaTarihi
            // 
            this.lblOlusturmaTarihi.Location = new System.Drawing.Point(5, 163);
            this.lblOlusturmaTarihi.Name = "lblOlusturmaTarihi";
            this.lblOlusturmaTarihi.Size = new System.Drawing.Size(111, 16);
            this.lblOlusturmaTarihi.TabIndex = 9;
            this.lblOlusturmaTarihi.Text = "Oluşturulma Tarihi:";
            // 
            // chkAktif
            // 
            this.chkAktif.Location = new System.Drawing.Point(120, 120);
            this.chkAktif.Name = "chkAktif";
            this.chkAktif.Properties.Caption = "Kullanıcı aktif";
            this.chkAktif.Size = new System.Drawing.Size(150, 24);
            this.chkAktif.TabIndex = 3;
            // 
            // txtYeniSifre
            // 
            this.txtYeniSifre.Location = new System.Drawing.Point(120, 77);
            this.txtYeniSifre.Name = "txtYeniSifre";
            this.txtYeniSifre.Properties.PasswordChar = '*';
            this.txtYeniSifre.Size = new System.Drawing.Size(300, 22);
            this.txtYeniSifre.TabIndex = 2;
            // 
            // lblYeniSifre
            // 
            this.lblYeniSifre.Location = new System.Drawing.Point(5, 80);
            this.lblYeniSifre.Name = "lblYeniSifre";
            this.lblYeniSifre.Size = new System.Drawing.Size(60, 16);
            this.lblYeniSifre.TabIndex = 1;
            this.lblYeniSifre.Text = "Yeni Şifre:";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(120, 37);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(300, 22);
            this.txtKullaniciAdi.TabIndex = 1;
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.Location = new System.Drawing.Point(5, 40);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(74, 16);
            this.lblKullaniciAdi.TabIndex = 0;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // gridControlKullanicilar
            // 
            this.gridControlKullanicilar.Location = new System.Drawing.Point(12, 41);
            this.gridControlKullanicilar.MainView = this.gridViewKullanicilar;
            this.gridControlKullanicilar.Name = "gridControlKullanicilar";
            this.gridControlKullanicilar.Size = new System.Drawing.Size(520, 599);
            this.gridControlKullanicilar.TabIndex = 4;
            this.gridControlKullanicilar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewKullanicilar});
            // 
            // gridViewKullanicilar
            // 
            this.gridViewKullanicilar.GridControl = this.gridControlKullanicilar;
            this.gridViewKullanicilar.Name = "gridViewKullanicilar";
            this.gridViewKullanicilar.OptionsBehavior.Editable = false;
            this.gridViewKullanicilar.OptionsView.ShowGroupPanel = false;
            this.gridViewKullanicilar.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewKullanicilar_FocusedRowChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemBaslik,
            this.layoutControlItemGrid,
            this.layoutControlItemGroup});
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
            // layoutControlItemGrid
            // 
            this.layoutControlItemGrid.Control = this.gridControlKullanicilar;
            this.layoutControlItemGrid.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItemGrid.Name = "layoutControlItemGrid";
            this.layoutControlItemGrid.Size = new System.Drawing.Size(524, 603);
            this.layoutControlItemGrid.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemGrid.TextVisible = false;
            // 
            // layoutControlItemGroup
            // 
            this.layoutControlItemGroup.Control = this.groupControlKullaniciDetay;
            this.layoutControlItemGroup.Location = new System.Drawing.Point(524, 29);
            this.layoutControlItemGroup.Name = "layoutControlItemGroup";
            this.layoutControlItemGroup.Size = new System.Drawing.Size(832, 603);
            this.layoutControlItemGroup.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemGroup.TextVisible = false;
            // 
            // FrmKullaniciIslemleri
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1376, 700);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmKullaniciIslemleri";
            this.Text = "Kullanıcı İşlemleri";
            this.Load += new System.EventHandler(this.FrmKullaniciIslemleri_Load);
            this.Activated += new System.EventHandler(this.FrmKullaniciIslemleri_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlKullaniciDetay)).EndInit();
            this.groupControlKullaniciDetay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtOlusturmaTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktif.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlKullanicilar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewKullanicilar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBaslik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGroup)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
