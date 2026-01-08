using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;

namespace OgrenciBursOtomasyonu.Desktop
{
    partial class FrmBursAlanOgrenciler
    {
        private System.ComponentModel.IContainer components = null;
        private LayoutControl layoutControl1;
        private LabelControl labelControlBaslik;
        private GroupControl groupControlOgrenciBilgi;
        private PictureEdit pictureEditOgrenciResim;
        private LabelControl lblOgrenciAdSoyad;
        private LabelControl lblOgrenciTc;
        private LabelControl lblOgrenciEmail;
        private LabelControl lblOgrenciTelefon;
        private LabelControl lblOgrenciUniversite;
        private LabelControl lblAylikTutar;
        private LabelControl lblToplamOdenen;
        private GroupControl groupControlOdemeTakip;
        private LabelControl lblAy;
        private LabelControl lblYil;
        private SpinEdit spinAy;
        private SpinEdit spinYil;
        private SimpleButton btnOdemeOnayla;
        private GridControl gridControlOdemeTakip;
        private GridView gridViewOdemeTakip;
        private SimpleButton btnYenile;
        private SimpleButton btnBursProgramindanCikar;
        private LayoutControlGroup Root;
        private LayoutControlItem layoutControlItemBaslik;
        private LayoutControlItem layoutControlItemOgrenciBilgi;
        private LayoutControlItem layoutControlItemOdemeTakip;
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
            this.btnBursProgramindanCikar = new SimpleButton();
            this.btnYenile = new SimpleButton();
            this.groupControlOdemeTakip = new GroupControl();
            this.gridControlOdemeTakip = new GridControl();
            this.gridViewOdemeTakip = new GridView();
            this.btnOdemeOnayla = new SimpleButton();
            this.lblYil = new LabelControl();
            this.spinYil = new SpinEdit();
            this.lblAy = new LabelControl();
            this.spinAy = new SpinEdit();
            this.groupControlOgrenciBilgi = new GroupControl();
            this.lblOgrenciUniversite = new LabelControl();
            this.lblOgrenciTelefon = new LabelControl();
            this.lblOgrenciEmail = new LabelControl();
            this.lblOgrenciTc = new LabelControl();
            this.lblOgrenciAdSoyad = new LabelControl();
            this.pictureEditOgrenciResim = new PictureEdit();
            this.lblToplamOdenen = new LabelControl();
            this.lblAylikTutar = new LabelControl();
            this.Root = new LayoutControlGroup();
            this.layoutControlItemBaslik = new LayoutControlItem();
            this.layoutControlItemOgrenciBilgi = new LayoutControlItem();
            this.layoutControlItemOdemeTakip = new LayoutControlItem();
            this.layoutControlItemButtons = new LayoutControlItem();
            this.layoutControlItemYenile = new LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOdemeTakip)).BeginInit();
            this.groupControlOdemeTakip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOdemeTakip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOdemeTakip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinYil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinAy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOgrenciBilgi)).BeginInit();
            this.groupControlOgrenciBilgi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditOgrenciResim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBaslik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemOgrenciBilgi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemOdemeTakip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemYenile)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.labelControlBaslik);
            this.layoutControl1.Controls.Add(this.btnBursProgramindanCikar);
            this.layoutControl1.Controls.Add(this.btnYenile);
            this.layoutControl1.Controls.Add(this.groupControlOdemeTakip);
            this.layoutControl1.Controls.Add(this.groupControlOgrenciBilgi);
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
            this.labelControlBaslik.Text = "BURS TAKİP";
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
            // groupControlOdemeTakip
            // 
            this.groupControlOdemeTakip.Controls.Add(this.gridControlOdemeTakip);
            this.groupControlOdemeTakip.Controls.Add(this.btnOdemeOnayla);
            this.groupControlOdemeTakip.Controls.Add(this.lblYil);
            this.groupControlOdemeTakip.Controls.Add(this.spinYil);
            this.groupControlOdemeTakip.Controls.Add(this.lblAy);
            this.groupControlOdemeTakip.Controls.Add(this.spinAy);
            this.groupControlOdemeTakip.Location = new System.Drawing.Point(12, 291);
            this.groupControlOdemeTakip.Name = "groupControlOdemeTakip";
            this.groupControlOdemeTakip.Size = new System.Drawing.Size(1352, 349);
            this.groupControlOdemeTakip.TabIndex = 5;
            this.groupControlOdemeTakip.Text = "Ödeme Takibi";
            // 
            // gridControlOdemeTakip
            // 
            this.gridControlOdemeTakip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlOdemeTakip.Location = new System.Drawing.Point(5, 80);
            this.gridControlOdemeTakip.MainView = this.gridViewOdemeTakip;
            this.gridControlOdemeTakip.Name = "gridControlOdemeTakip";
            this.gridControlOdemeTakip.Size = new System.Drawing.Size(1342, 264);
            this.gridControlOdemeTakip.TabIndex = 5;
            this.gridControlOdemeTakip.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOdemeTakip});
            // 
            // gridViewOdemeTakip
            // 
            this.gridViewOdemeTakip.GridControl = this.gridControlOdemeTakip;
            this.gridViewOdemeTakip.Name = "gridViewOdemeTakip";
            this.gridViewOdemeTakip.OptionsView.ShowGroupPanel = false;
            // 
            // btnOdemeOnayla
            // 
            this.btnOdemeOnayla.Location = new System.Drawing.Point(200, 47);
            this.btnOdemeOnayla.Name = "btnOdemeOnayla";
            this.btnOdemeOnayla.Size = new System.Drawing.Size(120, 26);
            this.btnOdemeOnayla.TabIndex = 4;
            this.btnOdemeOnayla.Text = "Ödeme Onayla";
            this.btnOdemeOnayla.Click += new System.EventHandler(this.btnOdemeOnayla_Click);
            // 
            // lblYil
            // 
            this.lblYil.Location = new System.Drawing.Point(120, 52);
            this.lblYil.Name = "lblYil";
            this.lblYil.Size = new System.Drawing.Size(23, 13);
            this.lblYil.TabIndex = 3;
            this.lblYil.Text = "Yıl:";
            // 
            // spinYil
            // 
            this.spinYil.EditValue = new decimal(new int[] {
            2024,
            0,
            0,
            0});
            this.spinYil.Location = new System.Drawing.Point(145, 49);
            this.spinYil.Name = "spinYil";
            this.spinYil.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinYil.Properties.IsFloatValue = false;
            this.spinYil.Properties.MaxValue = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.spinYil.Properties.MinValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.spinYil.Size = new System.Drawing.Size(50, 22);
            this.spinYil.TabIndex = 2;
            // 
            // lblAy
            // 
            this.lblAy.Location = new System.Drawing.Point(20, 52);
            this.lblAy.Name = "lblAy";
            this.lblAy.Size = new System.Drawing.Size(22, 13);
            this.lblAy.TabIndex = 1;
            this.lblAy.Text = "Ay:";
            // 
            // spinAy
            // 
            this.spinAy.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinAy.Location = new System.Drawing.Point(45, 49);
            this.spinAy.Name = "spinAy";
            this.spinAy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinAy.Properties.IsFloatValue = false;
            this.spinAy.Properties.MaxValue = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.spinAy.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinAy.Size = new System.Drawing.Size(70, 22);
            this.spinAy.TabIndex = 0;
            // 
            // groupControlOgrenciBilgi
            // 
            this.groupControlOgrenciBilgi.Controls.Add(this.lblOgrenciUniversite);
            this.groupControlOgrenciBilgi.Controls.Add(this.lblOgrenciTelefon);
            this.groupControlOgrenciBilgi.Controls.Add(this.lblOgrenciEmail);
            this.groupControlOgrenciBilgi.Controls.Add(this.lblOgrenciTc);
            this.groupControlOgrenciBilgi.Controls.Add(this.lblOgrenciAdSoyad);
            this.groupControlOgrenciBilgi.Controls.Add(this.pictureEditOgrenciResim);
            this.groupControlOgrenciBilgi.Controls.Add(this.lblToplamOdenen);
            this.groupControlOgrenciBilgi.Controls.Add(this.lblAylikTutar);
            this.groupControlOgrenciBilgi.Location = new System.Drawing.Point(12, 41);
            this.groupControlOgrenciBilgi.Name = "groupControlOgrenciBilgi";
            this.groupControlOgrenciBilgi.Size = new System.Drawing.Size(1352, 246);
            this.groupControlOgrenciBilgi.TabIndex = 3;
            this.groupControlOgrenciBilgi.Text = "Öğrenci Bilgileri";
            // 
            // lblOgrenciUniversite
            // 
            this.lblOgrenciUniversite.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblOgrenciUniversite.Appearance.Options.UseFont = true;
            this.lblOgrenciUniversite.Location = new System.Drawing.Point(200, 120);
            this.lblOgrenciUniversite.Name = "lblOgrenciUniversite";
            this.lblOgrenciUniversite.Size = new System.Drawing.Size(12, 14);
            this.lblOgrenciUniversite.TabIndex = 7;
            this.lblOgrenciUniversite.Text = "-";
            // 
            // lblOgrenciTelefon
            // 
            this.lblOgrenciTelefon.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblOgrenciTelefon.Appearance.Options.UseFont = true;
            this.lblOgrenciTelefon.Location = new System.Drawing.Point(200, 100);
            this.lblOgrenciTelefon.Name = "lblOgrenciTelefon";
            this.lblOgrenciTelefon.Size = new System.Drawing.Size(12, 14);
            this.lblOgrenciTelefon.TabIndex = 6;
            this.lblOgrenciTelefon.Text = "-";
            // 
            // lblOgrenciEmail
            // 
            this.lblOgrenciEmail.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblOgrenciEmail.Appearance.Options.UseFont = true;
            this.lblOgrenciEmail.Location = new System.Drawing.Point(200, 80);
            this.lblOgrenciEmail.Name = "lblOgrenciEmail";
            this.lblOgrenciEmail.Size = new System.Drawing.Size(12, 14);
            this.lblOgrenciEmail.TabIndex = 5;
            this.lblOgrenciEmail.Text = "-";
            // 
            // lblOgrenciTc
            // 
            this.lblOgrenciTc.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblOgrenciTc.Appearance.Options.UseFont = true;
            this.lblOgrenciTc.Location = new System.Drawing.Point(200, 60);
            this.lblOgrenciTc.Name = "lblOgrenciTc";
            this.lblOgrenciTc.Size = new System.Drawing.Size(12, 14);
            this.lblOgrenciTc.TabIndex = 4;
            this.lblOgrenciTc.Text = "-";
            // 
            // lblOgrenciAdSoyad
            // 
            this.lblOgrenciAdSoyad.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblOgrenciAdSoyad.Appearance.Options.UseFont = true;
            this.lblOgrenciAdSoyad.Location = new System.Drawing.Point(200, 30);
            this.lblOgrenciAdSoyad.Name = "lblOgrenciAdSoyad";
            this.lblOgrenciAdSoyad.Size = new System.Drawing.Size(104, 16);
            this.lblOgrenciAdSoyad.TabIndex = 3;
            this.lblOgrenciAdSoyad.Text = "Öğrenci Seçin";
            // 
            // pictureEditOgrenciResim
            // 
            this.pictureEditOgrenciResim.Location = new System.Drawing.Point(20, 30);
            this.pictureEditOgrenciResim.Name = "pictureEditOgrenciResim";
            this.pictureEditOgrenciResim.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEditOgrenciResim.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEditOgrenciResim.Size = new System.Drawing.Size(150, 180);
            this.pictureEditOgrenciResim.TabIndex = 2;
            // 
            // lblToplamOdenen
            // 
            this.lblToplamOdenen.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblToplamOdenen.Appearance.Options.UseFont = true;
            this.lblToplamOdenen.Location = new System.Drawing.Point(200, 180);
            this.lblToplamOdenen.Name = "lblToplamOdenen";
            this.lblToplamOdenen.Size = new System.Drawing.Size(120, 14);
            this.lblToplamOdenen.TabIndex = 1;
            this.lblToplamOdenen.Text = "Toplam Ödenen: 0,00 TL";
            // 
            // lblAylikTutar
            // 
            this.lblAylikTutar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblAylikTutar.Appearance.Options.UseFont = true;
            this.lblAylikTutar.Location = new System.Drawing.Point(200, 160);
            this.lblAylikTutar.Name = "lblAylikTutar";
            this.lblAylikTutar.Size = new System.Drawing.Size(100, 14);
            this.lblAylikTutar.TabIndex = 0;
            this.lblAylikTutar.Text = "Aylık Tutar: 0,00 TL";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemBaslik,
            this.layoutControlItemOgrenciBilgi,
            this.layoutControlItemOdemeTakip,
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
            // layoutControlItemOgrenciBilgi
            // 
            this.layoutControlItemOgrenciBilgi.Control = this.groupControlOgrenciBilgi;
            this.layoutControlItemOgrenciBilgi.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItemOgrenciBilgi.Name = "layoutControlItemOgrenciBilgi";
            this.layoutControlItemOgrenciBilgi.Size = new System.Drawing.Size(1356, 250);
            this.layoutControlItemOgrenciBilgi.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemOgrenciBilgi.TextVisible = false;
            // 
            // layoutControlItemOdemeTakip
            // 
            this.layoutControlItemOdemeTakip.Control = this.groupControlOdemeTakip;
            this.layoutControlItemOdemeTakip.Location = new System.Drawing.Point(0, 279);
            this.layoutControlItemOdemeTakip.Name = "layoutControlItemOdemeTakip";
            this.layoutControlItemOdemeTakip.Size = new System.Drawing.Size(1356, 353);
            this.layoutControlItemOdemeTakip.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemOdemeTakip.TextVisible = false;
            // 
            // layoutControlItemButtons
            // 
            this.layoutControlItemButtons.Control = this.btnBursProgramindanCikar;
            this.layoutControlItemButtons.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItemButtons.Location = new System.Drawing.Point(1136, 632);
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
            this.layoutControlItemYenile.Location = new System.Drawing.Point(1244, 632);
            this.layoutControlItemYenile.MinSize = new System.Drawing.Size(104, 32);
            this.layoutControlItemYenile.Name = "layoutControlItemYenile";
            this.layoutControlItemYenile.Size = new System.Drawing.Size(108, 36);
            this.layoutControlItemYenile.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemYenile.TextVisible = false;
            // 
            // FrmBursAlanOgrenciler
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1376, 700);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmBursAlanOgrenciler";
            this.Text = "Burs Takip";
            this.Load += new System.EventHandler(this.FrmBursAlanOgrenciler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOdemeTakip)).EndInit();
            this.groupControlOdemeTakip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOdemeTakip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOdemeTakip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinYil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinAy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOgrenciBilgi)).EndInit();
            this.groupControlOgrenciBilgi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditOgrenciResim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBaslik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemOgrenciBilgi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemOdemeTakip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemYenile)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
