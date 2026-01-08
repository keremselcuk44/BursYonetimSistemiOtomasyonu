using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using OgrenciBursOtomasyonu.Desktop.Views.Common;

namespace OgrenciBursOtomasyonu.Desktop
{
    partial class FrmBursTanimla
    {
        private System.ComponentModel.IContainer components = null;
        private LayoutControl layoutControl1;
        private LabelControl labelControlBaslik;
        private GroupControl groupControlTemelBilgiler;
        private TextEdit txtBursAdi;
        private LabelControl lblBursAdi;
        private ComboBoxEdit cmbBursTipi;
        private LabelControl lblBursTipi;
        private MemoEdit memoAciklama;
        private LabelControl lblAciklama;
        private GroupControl groupControlFinansal;
        private SpinEdit spinMinimumPuan;
        private LabelControl lblMinimumPuan;
        private SpinEdit spinKontenjan;
        private LabelControl lblKontenjan;
        private SpinEdit spinAylikTutar;
        private LabelControl lblAylikTutar;
        private ComboBoxEdit cmbOdemePeriyodu;
        private LabelControl lblOdemePeriyodu;
        private GroupControl groupControlTarihDurum;
        private DateEdit dateBaslangicTarihi;
        private LabelControl lblBaslangicTarihi;
        private DateEdit dateBitisTarihi;
        private LabelControl lblBitisTarihi;
        private CheckEdit chkAktifMi;
        private LabelControl lblAktifMi;
        private GroupControl groupControlKosullar;
        private MemoEdit memoKosullar;
        private LabelControl lblKosullar;
        private SimpleButton btnKaydet;
        private SimpleButton btnIptal;
        private LayoutControlGroup Root;
        private LayoutControlItem layoutControlItemBaslik;
        private LayoutControlItem layoutControlItemTemelBilgiler;
        private LayoutControlItem layoutControlItemFinansal;
        private LayoutControlItem layoutControlItemTarihDurum;
        private LayoutControlItem layoutControlItemKosullar;
        private LayoutControlItem layoutControlItemButtons;
        private LayoutControlItem layoutControlItemIptal;

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
            this.groupControlTemelBilgiler = new GroupControl();
            this.txtBursAdi = new TextEdit();
            this.lblBursAdi = new LabelControl();
            this.cmbBursTipi = new ComboBoxEdit();
            this.lblBursTipi = new LabelControl();
            this.memoAciklama = new MemoEdit();
            this.lblAciklama = new LabelControl();
            this.groupControlFinansal = new GroupControl();
            this.spinMinimumPuan = new SpinEdit();
            this.lblMinimumPuan = new LabelControl();
            this.spinKontenjan = new SpinEdit();
            this.lblKontenjan = new LabelControl();
            this.spinAylikTutar = new SpinEdit();
            this.lblAylikTutar = new LabelControl();
            this.cmbOdemePeriyodu = new ComboBoxEdit();
            this.lblOdemePeriyodu = new LabelControl();
            this.groupControlTarihDurum = new GroupControl();
            this.dateBaslangicTarihi = new DateEdit();
            this.lblBaslangicTarihi = new LabelControl();
            this.dateBitisTarihi = new DateEdit();
            this.lblBitisTarihi = new LabelControl();
            this.chkAktifMi = new CheckEdit();
            this.lblAktifMi = new LabelControl();
            this.groupControlKosullar = new GroupControl();
            this.memoKosullar = new MemoEdit();
            this.lblKosullar = new LabelControl();
            this.btnKaydet = new SimpleButton();
            this.btnIptal = new SimpleButton();
            this.Root = new LayoutControlGroup();
            this.layoutControlItemBaslik = new LayoutControlItem();
            this.layoutControlItemTemelBilgiler = new LayoutControlItem();
            this.layoutControlItemFinansal = new LayoutControlItem();
            this.layoutControlItemTarihDurum = new LayoutControlItem();
            this.layoutControlItemKosullar = new LayoutControlItem();
            this.layoutControlItemButtons = new LayoutControlItem();
            this.layoutControlItemIptal = new LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTemelBilgiler)).BeginInit();
            this.groupControlTemelBilgiler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBursAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBursTipi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlFinansal)).BeginInit();
            this.groupControlFinansal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinMinimumPuan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinKontenjan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinAylikTutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOdemePeriyodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTarihDurum)).BeginInit();
            this.groupControlTarihDurum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateBaslangicTarihi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBaslangicTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBitisTarihi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBitisTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktifMi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlKosullar)).BeginInit();
            this.groupControlKosullar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoKosullar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBaslik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemTemelBilgiler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemFinansal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemTarihDurum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemKosullar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemIptal)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.labelControlBaslik);
            this.layoutControl1.Controls.Add(this.groupControlTemelBilgiler);
            this.layoutControl1.Controls.Add(this.groupControlFinansal);
            this.layoutControl1.Controls.Add(this.groupControlTarihDurum);
            this.layoutControl1.Controls.Add(this.groupControlKosullar);
            this.layoutControl1.Controls.Add(this.btnKaydet);
            this.layoutControl1.Controls.Add(this.btnIptal);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(874, 0, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(800, 650);
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
            this.labelControlBaslik.Size = new System.Drawing.Size(776, 25);
            this.labelControlBaslik.StyleController = this.layoutControl1;
            this.labelControlBaslik.TabIndex = 0;
            this.labelControlBaslik.Text = "BURS TANIMLA";
            // 
            // groupControlTemelBilgiler
            // 
            this.groupControlTemelBilgiler.Controls.Add(this.memoAciklama);
            this.groupControlTemelBilgiler.Controls.Add(this.lblAciklama);
            this.groupControlTemelBilgiler.Controls.Add(this.cmbBursTipi);
            this.groupControlTemelBilgiler.Controls.Add(this.lblBursTipi);
            this.groupControlTemelBilgiler.Controls.Add(this.txtBursAdi);
            this.groupControlTemelBilgiler.Controls.Add(this.lblBursAdi);
            this.groupControlTemelBilgiler.Location = new System.Drawing.Point(12, 41);
            this.groupControlTemelBilgiler.Name = "groupControlTemelBilgiler";
            this.groupControlTemelBilgiler.Size = new System.Drawing.Size(776, 150);
            this.groupControlTemelBilgiler.TabIndex = 1;
            this.groupControlTemelBilgiler.Text = "Temel Bilgiler";
            // 
            // txtBursAdi
            // 
            this.txtBursAdi.Location = new System.Drawing.Point(120, 30);
            this.txtBursAdi.Name = "txtBursAdi";
            this.txtBursAdi.Size = new System.Drawing.Size(640, 22);
            this.txtBursAdi.TabIndex = 1;
            // 
            // lblBursAdi
            // 
            this.lblBursAdi.Location = new System.Drawing.Point(5, 33);
            this.lblBursAdi.Name = "lblBursAdi";
            this.lblBursAdi.Size = new System.Drawing.Size(64, 16);
            this.lblBursAdi.TabIndex = 0;
            this.lblBursAdi.Text = "Burs Adı: *";
            // 
            // cmbBursTipi
            // 
            this.cmbBursTipi.Location = new System.Drawing.Point(120, 60);
            this.cmbBursTipi.Name = "cmbBursTipi";
            this.cmbBursTipi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBursTipi.Properties.Items.AddRange(new object[] {
            "Temel",
            "Yüksek Lisans",
            "Doktora",
            "Özel",
            "Spor",
            "Sanat",
            "Başarı",
            "İhtiyaç",
            "Diğer"});
            this.cmbBursTipi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbBursTipi.Size = new System.Drawing.Size(300, 22);
            this.cmbBursTipi.TabIndex = 3;
            // 
            // lblBursTipi
            // 
            this.lblBursTipi.Location = new System.Drawing.Point(5, 63);
            this.lblBursTipi.Name = "lblBursTipi";
            this.lblBursTipi.Size = new System.Drawing.Size(55, 16);
            this.lblBursTipi.TabIndex = 2;
            this.lblBursTipi.Text = "Burs Tipi:";
            // 
            // memoAciklama
            // 
            this.memoAciklama.Location = new System.Drawing.Point(120, 90);
            this.memoAciklama.Name = "memoAciklama";
            this.memoAciklama.Properties.MaxLength = 2000;
            this.memoAciklama.Size = new System.Drawing.Size(640, 50);
            this.memoAciklama.TabIndex = 5;
            // 
            // lblAciklama
            // 
            this.lblAciklama.Location = new System.Drawing.Point(5, 93);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(56, 16);
            this.lblAciklama.TabIndex = 4;
            this.lblAciklama.Text = "Açıklama:";
            // 
            // groupControlFinansal
            // 
            this.groupControlFinansal.Controls.Add(this.cmbOdemePeriyodu);
            this.groupControlFinansal.Controls.Add(this.lblOdemePeriyodu);
            this.groupControlFinansal.Controls.Add(this.spinAylikTutar);
            this.groupControlFinansal.Controls.Add(this.lblAylikTutar);
            this.groupControlFinansal.Controls.Add(this.spinKontenjan);
            this.groupControlFinansal.Controls.Add(this.lblKontenjan);
            this.groupControlFinansal.Controls.Add(this.spinMinimumPuan);
            this.groupControlFinansal.Controls.Add(this.lblMinimumPuan);
            this.groupControlFinansal.Location = new System.Drawing.Point(12, 195);
            this.groupControlFinansal.Name = "groupControlFinansal";
            this.groupControlFinansal.Size = new System.Drawing.Size(776, 120);
            this.groupControlFinansal.TabIndex = 2;
            this.groupControlFinansal.Text = "Finansal Bilgiler";
            // 
            // spinMinimumPuan
            // 
            this.spinMinimumPuan.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinMinimumPuan.Location = new System.Drawing.Point(120, 30);
            this.spinMinimumPuan.Name = "spinMinimumPuan";
            this.spinMinimumPuan.Properties.IsFloatValue = false;
            this.spinMinimumPuan.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinMinimumPuan.Size = new System.Drawing.Size(150, 22);
            this.spinMinimumPuan.TabIndex = 7;
            // 
            // lblMinimumPuan
            // 
            this.lblMinimumPuan.Location = new System.Drawing.Point(5, 33);
            this.lblMinimumPuan.Name = "lblMinimumPuan";
            this.lblMinimumPuan.Size = new System.Drawing.Size(101, 16);
            this.lblMinimumPuan.TabIndex = 6;
            this.lblMinimumPuan.Text = "Minimum Puan: *";
            // 
            // spinKontenjan
            // 
            this.spinKontenjan.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinKontenjan.Location = new System.Drawing.Point(350, 30);
            this.spinKontenjan.Name = "spinKontenjan";
            this.spinKontenjan.Properties.IsFloatValue = false;
            this.spinKontenjan.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.spinKontenjan.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinKontenjan.Size = new System.Drawing.Size(150, 22);
            this.spinKontenjan.TabIndex = 9;
            // 
            // lblKontenjan
            // 
            this.lblKontenjan.Location = new System.Drawing.Point(280, 33);
            this.lblKontenjan.Name = "lblKontenjan";
            this.lblKontenjan.Size = new System.Drawing.Size(74, 16);
            this.lblKontenjan.TabIndex = 8;
            this.lblKontenjan.Text = "Kontenjan: *";
            // 
            // spinAylikTutar
            // 
            this.spinAylikTutar.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinAylikTutar.Location = new System.Drawing.Point(120, 60);
            this.spinAylikTutar.Name = "spinAylikTutar";
            this.spinAylikTutar.Properties.DisplayFormat.FormatString = "N2";
            this.spinAylikTutar.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinAylikTutar.Properties.MaxValue = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.spinAylikTutar.Size = new System.Drawing.Size(200, 22);
            this.spinAylikTutar.TabIndex = 11;
            // 
            // lblAylikTutar
            // 
            this.lblAylikTutar.Location = new System.Drawing.Point(5, 63);
            this.lblAylikTutar.Name = "lblAylikTutar";
            this.lblAylikTutar.Size = new System.Drawing.Size(78, 16);
            this.lblAylikTutar.TabIndex = 10;
            this.lblAylikTutar.Text = "Aylık Tutar: *";
            // 
            // cmbOdemePeriyodu
            // 
            this.cmbOdemePeriyodu.EditValue = "Aylık";
            this.cmbOdemePeriyodu.Location = new System.Drawing.Point(400, 60);
            this.cmbOdemePeriyodu.Name = "cmbOdemePeriyodu";
            this.cmbOdemePeriyodu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbOdemePeriyodu.Properties.Items.AddRange(new object[] {
            "Aylık",
            "Dönemlik",
            "Yıllık"});
            this.cmbOdemePeriyodu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbOdemePeriyodu.Size = new System.Drawing.Size(200, 22);
            this.cmbOdemePeriyodu.TabIndex = 13;
            // 
            // lblOdemePeriyodu
            // 
            this.lblOdemePeriyodu.Location = new System.Drawing.Point(330, 63);
            this.lblOdemePeriyodu.Name = "lblOdemePeriyodu";
            this.lblOdemePeriyodu.Size = new System.Drawing.Size(99, 16);
            this.lblOdemePeriyodu.TabIndex = 12;
            this.lblOdemePeriyodu.Text = "Ödeme Periyodu:";
            // 
            // groupControlTarihDurum
            // 
            this.groupControlTarihDurum.Controls.Add(this.chkAktifMi);
            this.groupControlTarihDurum.Controls.Add(this.lblAktifMi);
            this.groupControlTarihDurum.Controls.Add(this.dateBitisTarihi);
            this.groupControlTarihDurum.Controls.Add(this.lblBitisTarihi);
            this.groupControlTarihDurum.Controls.Add(this.dateBaslangicTarihi);
            this.groupControlTarihDurum.Controls.Add(this.lblBaslangicTarihi);
            this.groupControlTarihDurum.Location = new System.Drawing.Point(12, 319);
            this.groupControlTarihDurum.Name = "groupControlTarihDurum";
            this.groupControlTarihDurum.Size = new System.Drawing.Size(776, 100);
            this.groupControlTarihDurum.TabIndex = 3;
            this.groupControlTarihDurum.Text = "Tarih ve Durum";
            // 
            // dateBaslangicTarihi
            // 
            this.dateBaslangicTarihi.EditValue = null;
            this.dateBaslangicTarihi.Location = new System.Drawing.Point(120, 30);
            this.dateBaslangicTarihi.Name = "dateBaslangicTarihi";
            this.dateBaslangicTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBaslangicTarihi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBaslangicTarihi.Size = new System.Drawing.Size(200, 22);
            this.dateBaslangicTarihi.TabIndex = 15;
            // 
            // lblBaslangicTarihi
            // 
            this.lblBaslangicTarihi.Location = new System.Drawing.Point(5, 33);
            this.lblBaslangicTarihi.Name = "lblBaslangicTarihi";
            this.lblBaslangicTarihi.Size = new System.Drawing.Size(95, 16);
            this.lblBaslangicTarihi.TabIndex = 14;
            this.lblBaslangicTarihi.Text = "Başlangıç Tarihi:";
            // 
            // dateBitisTarihi
            // 
            this.dateBitisTarihi.EditValue = null;
            this.dateBitisTarihi.Location = new System.Drawing.Point(400, 30);
            this.dateBitisTarihi.Name = "dateBitisTarihi";
            this.dateBitisTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBitisTarihi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBitisTarihi.Size = new System.Drawing.Size(200, 22);
            this.dateBitisTarihi.TabIndex = 17;
            // 
            // lblBitisTarihi
            // 
            this.lblBitisTarihi.Location = new System.Drawing.Point(330, 33);
            this.lblBitisTarihi.Name = "lblBitisTarihi";
            this.lblBitisTarihi.Size = new System.Drawing.Size(65, 16);
            this.lblBitisTarihi.TabIndex = 16;
            this.lblBitisTarihi.Text = "Bitiş Tarihi:";
            // 
            // chkAktifMi
            // 
            this.chkAktifMi.EditValue = true;
            this.chkAktifMi.Location = new System.Drawing.Point(120, 60);
            this.chkAktifMi.Name = "chkAktifMi";
            this.chkAktifMi.Properties.Caption = "Burs aktif";
            this.chkAktifMi.Size = new System.Drawing.Size(100, 24);
            this.chkAktifMi.TabIndex = 19;
            // 
            // lblAktifMi
            // 
            this.lblAktifMi.Location = new System.Drawing.Point(5, 63);
            this.lblAktifMi.Name = "lblAktifMi";
            this.lblAktifMi.Size = new System.Drawing.Size(47, 16);
            this.lblAktifMi.TabIndex = 18;
            this.lblAktifMi.Text = "Aktif Mi:";
            // 
            // groupControlKosullar
            // 
            this.groupControlKosullar.Controls.Add(this.memoKosullar);
            this.groupControlKosullar.Controls.Add(this.lblKosullar);
            this.groupControlKosullar.Location = new System.Drawing.Point(12, 423);
            this.groupControlKosullar.Name = "groupControlKosullar";
            this.groupControlKosullar.Size = new System.Drawing.Size(776, 120);
            this.groupControlKosullar.TabIndex = 4;
            this.groupControlKosullar.Text = "Burs Koşulları";
            // 
            // memoKosullar
            // 
            this.memoKosullar.Location = new System.Drawing.Point(120, 30);
            this.memoKosullar.Name = "memoKosullar";
            this.memoKosullar.Properties.MaxLength = 2000;
            this.memoKosullar.Size = new System.Drawing.Size(640, 80);
            this.memoKosullar.TabIndex = 21;
            // 
            // lblKosullar
            // 
            this.lblKosullar.Location = new System.Drawing.Point(5, 33);
            this.lblKosullar.Name = "lblKosullar";
            this.lblKosullar.Size = new System.Drawing.Size(82, 16);
            this.lblKosullar.TabIndex = 20;
            this.lblKosullar.Text = "Burs Koşulları:";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.ImageOptions.ImageUri = ToolbarExtension.GetImageUri("SaveAndClose");
            this.btnKaydet.Location = new System.Drawing.Point(588, 547);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(100, 41);
            this.btnKaydet.StyleController = this.layoutControl1;
            this.btnKaydet.TabIndex = 5;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnIptal.Appearance.Options.UseFont = true;
            this.btnIptal.ImageOptions.ImageUri = ToolbarExtension.GetImageUri("Cancel");
            this.btnIptal.Location = new System.Drawing.Point(692, 547);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(96, 41);
            this.btnIptal.StyleController = this.layoutControl1;
            this.btnIptal.TabIndex = 6;
            this.btnIptal.Text = "İptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemBaslik,
            this.layoutControlItemTemelBilgiler,
            this.layoutControlItemFinansal,
            this.layoutControlItemTarihDurum,
            this.layoutControlItemKosullar,
            this.layoutControlItemButtons,
            this.layoutControlItemIptal});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(12, 12, 12, 12);
            this.Root.Size = new System.Drawing.Size(800, 650);
            this.Root.TextVisible = false;
            // 
            // layoutControlItemBaslik
            // 
            this.layoutControlItemBaslik.Control = this.labelControlBaslik;
            this.layoutControlItemBaslik.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemBaslik.Name = "layoutControlItemBaslik";
            this.layoutControlItemBaslik.Size = new System.Drawing.Size(780, 29);
            this.layoutControlItemBaslik.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBaslik.TextVisible = false;
            // 
            // layoutControlItemTemelBilgiler
            // 
            this.layoutControlItemTemelBilgiler.Control = this.groupControlTemelBilgiler;
            this.layoutControlItemTemelBilgiler.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItemTemelBilgiler.Name = "layoutControlItemTemelBilgiler";
            this.layoutControlItemTemelBilgiler.Size = new System.Drawing.Size(780, 154);
            this.layoutControlItemTemelBilgiler.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemTemelBilgiler.TextVisible = false;
            // 
            // layoutControlItemFinansal
            // 
            this.layoutControlItemFinansal.Control = this.groupControlFinansal;
            this.layoutControlItemFinansal.Location = new System.Drawing.Point(0, 183);
            this.layoutControlItemFinansal.Name = "layoutControlItemFinansal";
            this.layoutControlItemFinansal.Size = new System.Drawing.Size(780, 124);
            this.layoutControlItemFinansal.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemFinansal.TextVisible = false;
            // 
            // layoutControlItemTarihDurum
            // 
            this.layoutControlItemTarihDurum.Control = this.groupControlTarihDurum;
            this.layoutControlItemTarihDurum.Location = new System.Drawing.Point(0, 307);
            this.layoutControlItemTarihDurum.Name = "layoutControlItemTarihDurum";
            this.layoutControlItemTarihDurum.Size = new System.Drawing.Size(780, 104);
            this.layoutControlItemTarihDurum.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemTarihDurum.TextVisible = false;
            // 
            // layoutControlItemKosullar
            // 
            this.layoutControlItemKosullar.Control = this.groupControlKosullar;
            this.layoutControlItemKosullar.Location = new System.Drawing.Point(0, 411);
            this.layoutControlItemKosullar.Name = "layoutControlItemKosullar";
            this.layoutControlItemKosullar.Size = new System.Drawing.Size(780, 124);
            this.layoutControlItemKosullar.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemKosullar.TextVisible = false;
            // 
            // layoutControlItemButtons
            // 
            this.layoutControlItemButtons.Control = this.btnKaydet;
            this.layoutControlItemButtons.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItemButtons.Location = new System.Drawing.Point(576, 535);
            this.layoutControlItemButtons.MinSize = new System.Drawing.Size(100, 41);
            this.layoutControlItemButtons.Name = "layoutControlItemButtons";
            this.layoutControlItemButtons.Size = new System.Drawing.Size(104, 45);
            this.layoutControlItemButtons.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemButtons.TextVisible = false;
            // 
            // layoutControlItemIptal
            // 
            this.layoutControlItemIptal.Control = this.btnIptal;
            this.layoutControlItemIptal.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItemIptal.Location = new System.Drawing.Point(680, 535);
            this.layoutControlItemIptal.MinSize = new System.Drawing.Size(96, 41);
            this.layoutControlItemIptal.Name = "layoutControlItemIptal";
            this.layoutControlItemIptal.Size = new System.Drawing.Size(100, 45);
            this.layoutControlItemIptal.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemIptal.TextVisible = false;
            // 
            // FrmBursTanimla
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 650);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmBursTanimla";
            this.Text = "Burs Tanımla";
            this.Load += new System.EventHandler(this.FrmBursTanimla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTemelBilgiler)).EndInit();
            this.groupControlTemelBilgiler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtBursAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBursTipi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlFinansal)).EndInit();
            this.groupControlFinansal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinMinimumPuan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinKontenjan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinAylikTutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOdemePeriyodu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTarihDurum)).EndInit();
            this.groupControlTarihDurum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateBaslangicTarihi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBaslangicTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBitisTarihi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBitisTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktifMi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlKosullar)).EndInit();
            this.groupControlKosullar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoKosullar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBaslik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemTemelBilgiler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemFinansal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemTarihDurum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemKosullar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemIptal)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
