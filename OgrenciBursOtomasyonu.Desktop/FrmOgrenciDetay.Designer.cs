using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace OgrenciBursOtomasyonu.Desktop
{
    partial class FrmOgrenciDetay
    {
        private System.ComponentModel.IContainer components = null;
        private LayoutControl layoutControl1;
        private LabelControl labelControlBaslik;
        private GroupControl groupControlOgrenciBilgileri;
        private LabelControl lblTcLabel;
        private LabelControl lblTc;
        private LabelControl lblAdSoyadLabel;
        private LabelControl lblAdSoyad;
        private LabelControl lblYasLabel;
        private LabelControl lblYas;
        private LabelControl lblUniversiteLabel;
        private LabelControl lblUniversite;
        private LabelControl lblBolumLabel;
        private LabelControl lblBolum;
        private LabelControl lblSinifLabel;
        private LabelControl lblSinif;
        private LabelControl lblAgnoLabel;
        private LabelControl lblAgno;
        private LabelControl lblKardesSayisiLabel;
        private LabelControl lblKardesSayisi;
        private LabelControl lblHaneGeliriLabel;
        private LabelControl lblHaneGeliri;
        private LabelControl lblPuanLabel;
        private LabelControl lblPuan;
        private LabelControl lblEmailLabel;
        private LabelControl lblEmail;
        private LabelControl lblTelefonLabel;
        private LabelControl lblTelefon;
        private LabelControl lblIbanLabel;
        private LabelControl lblIban;
        private PictureEdit pictureEditResim;
        private GroupControl groupControlAiRaporu;
        private MemoEdit memoAiRaporu;
        private LayoutControlGroup Root;
        private LayoutControlItem layoutControlItemBaslik;
        private LayoutControlItem layoutControlItemOgrenciBilgileri;
        private LayoutControlItem layoutControlItemAiRaporu;

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
            this.groupControlOgrenciBilgileri = new GroupControl();
            this.pictureEditResim = new PictureEdit();
            this.lblIban = new LabelControl();
            this.lblIbanLabel = new LabelControl();
            this.lblTelefon = new LabelControl();
            this.lblTelefonLabel = new LabelControl();
            this.lblEmail = new LabelControl();
            this.lblEmailLabel = new LabelControl();
            this.lblPuan = new LabelControl();
            this.lblPuanLabel = new LabelControl();
            this.lblHaneGeliri = new LabelControl();
            this.lblHaneGeliriLabel = new LabelControl();
            this.lblKardesSayisi = new LabelControl();
            this.lblKardesSayisiLabel = new LabelControl();
            this.lblAgno = new LabelControl();
            this.lblAgnoLabel = new LabelControl();
            this.lblSinif = new LabelControl();
            this.lblSinifLabel = new LabelControl();
            this.lblBolum = new LabelControl();
            this.lblBolumLabel = new LabelControl();
            this.lblUniversite = new LabelControl();
            this.lblUniversiteLabel = new LabelControl();
            this.lblYas = new LabelControl();
            this.lblYasLabel = new LabelControl();
            this.lblAdSoyad = new LabelControl();
            this.lblAdSoyadLabel = new LabelControl();
            this.lblTc = new LabelControl();
            this.lblTcLabel = new LabelControl();
            this.groupControlAiRaporu = new GroupControl();
            this.memoAiRaporu = new MemoEdit();
            this.Root = new LayoutControlGroup();
            this.layoutControlItemBaslik = new LayoutControlItem();
            this.layoutControlItemOgrenciBilgileri = new LayoutControlItem();
            this.layoutControlItemAiRaporu = new LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOgrenciBilgileri)).BeginInit();
            this.groupControlOgrenciBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditResim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAiRaporu)).BeginInit();
            this.groupControlAiRaporu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoAiRaporu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBaslik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemOgrenciBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemAiRaporu)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.labelControlBaslik);
            this.layoutControl1.Controls.Add(this.groupControlOgrenciBilgileri);
            this.layoutControl1.Controls.Add(this.groupControlAiRaporu);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(874, 0, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1000, 700);
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
            this.labelControlBaslik.Size = new System.Drawing.Size(976, 25);
            this.labelControlBaslik.StyleController = this.layoutControl1;
            this.labelControlBaslik.TabIndex = 4;
            this.labelControlBaslik.Text = "ÖĞRENCİ DETAY VE AI ANALİZ";
            // 
            // groupControlOgrenciBilgileri
            // 
            this.groupControlOgrenciBilgileri.Controls.Add(this.pictureEditResim);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblIban);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblIbanLabel);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblTelefon);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblTelefonLabel);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblEmail);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblEmailLabel);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblPuan);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblPuanLabel);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblHaneGeliri);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblHaneGeliriLabel);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblKardesSayisi);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblKardesSayisiLabel);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblAgno);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblAgnoLabel);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblSinif);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblSinifLabel);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblBolum);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblBolumLabel);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblUniversite);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblUniversiteLabel);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblYas);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblYasLabel);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblAdSoyad);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblAdSoyadLabel);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblTc);
            this.groupControlOgrenciBilgileri.Controls.Add(this.lblTcLabel);
            this.groupControlOgrenciBilgileri.Location = new System.Drawing.Point(12, 41);
            this.groupControlOgrenciBilgileri.Name = "groupControlOgrenciBilgileri";
            this.groupControlOgrenciBilgileri.Size = new System.Drawing.Size(976, 360);
            this.groupControlOgrenciBilgileri.TabIndex = 5;
            this.groupControlOgrenciBilgileri.Text = "Öğrenci Bilgileri";
            // 
            // lblPuan
            // 
            this.lblPuan.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblPuan.Appearance.Options.UseFont = true;
            this.lblPuan.Location = new System.Drawing.Point(120, 240);
            this.lblPuan.Name = "lblPuan";
            this.lblPuan.Size = new System.Drawing.Size(12, 14);
            this.lblPuan.TabIndex = 19;
            this.lblPuan.Text = "-";
            // 
            // lblPuanLabel
            // 
            this.lblPuanLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblPuanLabel.Appearance.Options.UseFont = true;
            this.lblPuanLabel.Location = new System.Drawing.Point(20, 240);
            this.lblPuanLabel.Name = "lblPuanLabel";
            this.lblPuanLabel.Size = new System.Drawing.Size(35, 14);
            this.lblPuanLabel.TabIndex = 18;
            this.lblPuanLabel.Text = "Puan:";
            // 
            // lblHaneGeliri
            // 
            this.lblHaneGeliri.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblHaneGeliri.Appearance.Options.UseFont = true;
            this.lblHaneGeliri.Location = new System.Drawing.Point(120, 220);
            this.lblHaneGeliri.Name = "lblHaneGeliri";
            this.lblHaneGeliri.Size = new System.Drawing.Size(12, 14);
            this.lblHaneGeliri.TabIndex = 17;
            this.lblHaneGeliri.Text = "-";
            // 
            // lblHaneGeliriLabel
            // 
            this.lblHaneGeliriLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblHaneGeliriLabel.Appearance.Options.UseFont = true;
            this.lblHaneGeliriLabel.Location = new System.Drawing.Point(20, 220);
            this.lblHaneGeliriLabel.Name = "lblHaneGeliriLabel";
            this.lblHaneGeliriLabel.Size = new System.Drawing.Size(71, 14);
            this.lblHaneGeliriLabel.TabIndex = 16;
            this.lblHaneGeliriLabel.Text = "Hane Geliri:";
            // 
            // lblKardesSayisi
            // 
            this.lblKardesSayisi.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblKardesSayisi.Appearance.Options.UseFont = true;
            this.lblKardesSayisi.Location = new System.Drawing.Point(120, 200);
            this.lblKardesSayisi.Name = "lblKardesSayisi";
            this.lblKardesSayisi.Size = new System.Drawing.Size(12, 14);
            this.lblKardesSayisi.TabIndex = 15;
            this.lblKardesSayisi.Text = "-";
            // 
            // lblKardesSayisiLabel
            // 
            this.lblKardesSayisiLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblKardesSayisiLabel.Appearance.Options.UseFont = true;
            this.lblKardesSayisiLabel.Location = new System.Drawing.Point(20, 200);
            this.lblKardesSayisiLabel.Name = "lblKardesSayisiLabel";
            this.lblKardesSayisiLabel.Size = new System.Drawing.Size(82, 14);
            this.lblKardesSayisiLabel.TabIndex = 14;
            this.lblKardesSayisiLabel.Text = "Kardeş Sayısı:";
            // 
            // lblAgno
            // 
            this.lblAgno.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblAgno.Appearance.Options.UseFont = true;
            this.lblAgno.Location = new System.Drawing.Point(120, 180);
            this.lblAgno.Name = "lblAgno";
            this.lblAgno.Size = new System.Drawing.Size(12, 14);
            this.lblAgno.TabIndex = 13;
            this.lblAgno.Text = "-";
            // 
            // lblAgnoLabel
            // 
            this.lblAgnoLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblAgnoLabel.Appearance.Options.UseFont = true;
            this.lblAgnoLabel.Location = new System.Drawing.Point(20, 180);
            this.lblAgnoLabel.Name = "lblAgnoLabel";
            this.lblAgnoLabel.Size = new System.Drawing.Size(42, 14);
            this.lblAgnoLabel.TabIndex = 12;
            this.lblAgnoLabel.Text = "AGNO:";
            // 
            // lblSinif
            // 
            this.lblSinif.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSinif.Appearance.Options.UseFont = true;
            this.lblSinif.Location = new System.Drawing.Point(120, 160);
            this.lblSinif.Name = "lblSinif";
            this.lblSinif.Size = new System.Drawing.Size(12, 14);
            this.lblSinif.TabIndex = 11;
            this.lblSinif.Text = "-";
            // 
            // lblSinifLabel
            // 
            this.lblSinifLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblSinifLabel.Appearance.Options.UseFont = true;
            this.lblSinifLabel.Location = new System.Drawing.Point(20, 160);
            this.lblSinifLabel.Name = "lblSinifLabel";
            this.lblSinifLabel.Size = new System.Drawing.Size(33, 14);
            this.lblSinifLabel.TabIndex = 10;
            this.lblSinifLabel.Text = "Sınıf:";
            // 
            // lblBolum
            // 
            this.lblBolum.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblBolum.Appearance.Options.UseFont = true;
            this.lblBolum.Location = new System.Drawing.Point(120, 140);
            this.lblBolum.Name = "lblBolum";
            this.lblBolum.Size = new System.Drawing.Size(12, 14);
            this.lblBolum.TabIndex = 9;
            this.lblBolum.Text = "-";
            // 
            // lblBolumLabel
            // 
            this.lblBolumLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblBolumLabel.Appearance.Options.UseFont = true;
            this.lblBolumLabel.Location = new System.Drawing.Point(20, 140);
            this.lblBolumLabel.Name = "lblBolumLabel";
            this.lblBolumLabel.Size = new System.Drawing.Size(42, 14);
            this.lblBolumLabel.TabIndex = 8;
            this.lblBolumLabel.Text = "Bölüm:";
            // 
            // lblUniversite
            // 
            this.lblUniversite.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblUniversite.Appearance.Options.UseFont = true;
            this.lblUniversite.Location = new System.Drawing.Point(120, 120);
            this.lblUniversite.Name = "lblUniversite";
            this.lblUniversite.Size = new System.Drawing.Size(12, 14);
            this.lblUniversite.TabIndex = 7;
            this.lblUniversite.Text = "-";
            // 
            // lblUniversiteLabel
            // 
            this.lblUniversiteLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblUniversiteLabel.Appearance.Options.UseFont = true;
            this.lblUniversiteLabel.Location = new System.Drawing.Point(20, 120);
            this.lblUniversiteLabel.Name = "lblUniversiteLabel";
            this.lblUniversiteLabel.Size = new System.Drawing.Size(63, 14);
            this.lblUniversiteLabel.TabIndex = 6;
            this.lblUniversiteLabel.Text = "Üniversite:";
            // 
            // lblYas
            // 
            this.lblYas.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblYas.Appearance.Options.UseFont = true;
            this.lblYas.Location = new System.Drawing.Point(120, 100);
            this.lblYas.Name = "lblYas";
            this.lblYas.Size = new System.Drawing.Size(12, 14);
            this.lblYas.TabIndex = 5;
            this.lblYas.Text = "-";
            // 
            // lblYasLabel
            // 
            this.lblYasLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblYasLabel.Appearance.Options.UseFont = true;
            this.lblYasLabel.Location = new System.Drawing.Point(20, 100);
            this.lblYasLabel.Name = "lblYasLabel";
            this.lblYasLabel.Size = new System.Drawing.Size(27, 14);
            this.lblYasLabel.TabIndex = 4;
            this.lblYasLabel.Text = "Yaş:";
            // 
            // lblAdSoyad
            // 
            this.lblAdSoyad.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblAdSoyad.Appearance.Options.UseFont = true;
            this.lblAdSoyad.Location = new System.Drawing.Point(120, 60);
            this.lblAdSoyad.Name = "lblAdSoyad";
            this.lblAdSoyad.Size = new System.Drawing.Size(12, 16);
            this.lblAdSoyad.TabIndex = 3;
            this.lblAdSoyad.Text = "-";
            // 
            // lblAdSoyadLabel
            // 
            this.lblAdSoyadLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblAdSoyadLabel.Appearance.Options.UseFont = true;
            this.lblAdSoyadLabel.Location = new System.Drawing.Point(20, 60);
            this.lblAdSoyadLabel.Name = "lblAdSoyadLabel";
            this.lblAdSoyadLabel.Size = new System.Drawing.Size(62, 14);
            this.lblAdSoyadLabel.TabIndex = 2;
            this.lblAdSoyadLabel.Text = "Ad Soyad:";
            // 
            // lblTc
            // 
            this.lblTc.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTc.Appearance.Options.UseFont = true;
            this.lblTc.Location = new System.Drawing.Point(120, 40);
            this.lblTc.Name = "lblTc";
            this.lblTc.Size = new System.Drawing.Size(12, 14);
            this.lblTc.TabIndex = 1;
            this.lblTc.Text = "-";
            // 
            // lblTcLabel
            // 
            this.lblTcLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTcLabel.Appearance.Options.UseFont = true;
            this.lblTcLabel.Location = new System.Drawing.Point(20, 40);
            this.lblTcLabel.Name = "lblTcLabel";
            this.lblTcLabel.Size = new System.Drawing.Size(62, 14);
            this.lblTcLabel.TabIndex = 0;
            this.lblTcLabel.Text = "TC Kimlik:";
            // 
            // pictureEditResim
            // 
            this.pictureEditResim.Location = new System.Drawing.Point(650, 40);
            this.pictureEditResim.Name = "pictureEditResim";
            this.pictureEditResim.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEditResim.Properties.ShowMenu = false;
            this.pictureEditResim.Size = new System.Drawing.Size(300, 150);
            this.pictureEditResim.TabIndex = 6;
            // 
            // lblIban
            // 
            this.lblIban.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblIban.Appearance.Options.UseFont = true;
            this.lblIban.Location = new System.Drawing.Point(120, 280);
            this.lblIban.Name = "lblIban";
            this.lblIban.Size = new System.Drawing.Size(12, 14);
            this.lblIban.TabIndex = 5;
            this.lblIban.Text = "-";
            // 
            // lblIbanLabel
            // 
            this.lblIbanLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblIbanLabel.Appearance.Options.UseFont = true;
            this.lblIbanLabel.Location = new System.Drawing.Point(20, 280);
            this.lblIbanLabel.Name = "lblIbanLabel";
            this.lblIbanLabel.Size = new System.Drawing.Size(36, 14);
            this.lblIbanLabel.TabIndex = 4;
            this.lblIbanLabel.Text = "IBAN:";
            // 
            // lblTelefon
            // 
            this.lblTelefon.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTelefon.Appearance.Options.UseFont = true;
            this.lblTelefon.Location = new System.Drawing.Point(120, 260);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(12, 14);
            this.lblTelefon.TabIndex = 3;
            this.lblTelefon.Text = "-";
            // 
            // lblTelefonLabel
            // 
            this.lblTelefonLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTelefonLabel.Appearance.Options.UseFont = true;
            this.lblTelefonLabel.Location = new System.Drawing.Point(20, 260);
            this.lblTelefonLabel.Name = "lblTelefonLabel";
            this.lblTelefonLabel.Size = new System.Drawing.Size(51, 14);
            this.lblTelefonLabel.TabIndex = 2;
            this.lblTelefonLabel.Text = "Telefon:";
            // 
            // lblEmail
            // 
            this.lblEmail.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblEmail.Appearance.Options.UseFont = true;
            this.lblEmail.Location = new System.Drawing.Point(120, 240);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(12, 14);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "-";
            // 
            // lblEmailLabel
            // 
            this.lblEmailLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmailLabel.Appearance.Options.UseFont = true;
            this.lblEmailLabel.Location = new System.Drawing.Point(20, 240);
            this.lblEmailLabel.Name = "lblEmailLabel";
            this.lblEmailLabel.Size = new System.Drawing.Size(52, 14);
            this.lblEmailLabel.TabIndex = 0;
            this.lblEmailLabel.Text = "E-posta:";
            // 
            // groupControlAiRaporu
            // 
            this.groupControlAiRaporu.Controls.Add(this.memoAiRaporu);
            this.groupControlAiRaporu.Location = new System.Drawing.Point(12, 405);
            this.groupControlAiRaporu.Name = "groupControlAiRaporu";
            this.groupControlAiRaporu.Size = new System.Drawing.Size(976, 283);
            this.groupControlAiRaporu.TabIndex = 7;
            this.groupControlAiRaporu.Text = "AI Analiz Raporu";
            // 
            // memoAiRaporu
            // 
            this.memoAiRaporu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoAiRaporu.Location = new System.Drawing.Point(2, 23);
            this.memoAiRaporu.Name = "memoAiRaporu";
            this.memoAiRaporu.Properties.ReadOnly = true;
            this.memoAiRaporu.Size = new System.Drawing.Size(972, 258);
            this.memoAiRaporu.TabIndex = 0;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemBaslik,
            this.layoutControlItemOgrenciBilgileri,
            this.layoutControlItemAiRaporu});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(12, 12, 12, 12);
            this.Root.Size = new System.Drawing.Size(1000, 700);
            this.Root.TextVisible = false;
            // 
            // layoutControlItemBaslik
            // 
            this.layoutControlItemBaslik.Control = this.labelControlBaslik;
            this.layoutControlItemBaslik.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemBaslik.Name = "layoutControlItemBaslik";
            this.layoutControlItemBaslik.Size = new System.Drawing.Size(980, 29);
            this.layoutControlItemBaslik.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBaslik.TextVisible = false;
            // 
            // layoutControlItemOgrenciBilgileri
            // 
            this.layoutControlItemOgrenciBilgileri.Control = this.groupControlOgrenciBilgileri;
            this.layoutControlItemOgrenciBilgileri.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItemOgrenciBilgileri.Name = "layoutControlItemOgrenciBilgileri";
            this.layoutControlItemOgrenciBilgileri.Size = new System.Drawing.Size(980, 364);
            this.layoutControlItemOgrenciBilgileri.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemOgrenciBilgileri.TextVisible = false;
            // 
            // layoutControlItemAiRaporu
            // 
            this.layoutControlItemAiRaporu.Control = this.groupControlAiRaporu;
            this.layoutControlItemAiRaporu.Location = new System.Drawing.Point(0, 393);
            this.layoutControlItemAiRaporu.Name = "layoutControlItemAiRaporu";
            this.layoutControlItemAiRaporu.Size = new System.Drawing.Size(980, 287);
            this.layoutControlItemAiRaporu.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemAiRaporu.TextVisible = false;
            // 
            // FrmOgrenciDetay
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmOgrenciDetay";
            this.Text = "Öğrenci Detay ve AI Analiz";
            this.Load += new System.EventHandler(this.FrmOgrenciDetay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOgrenciBilgileri)).EndInit();
            this.groupControlOgrenciBilgileri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditResim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAiRaporu)).EndInit();
            this.groupControlAiRaporu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoAiRaporu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBaslik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemOgrenciBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemAiRaporu)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
