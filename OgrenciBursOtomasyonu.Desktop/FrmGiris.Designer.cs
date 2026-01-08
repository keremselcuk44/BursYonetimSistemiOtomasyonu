namespace OgrenciBursOtomasyonu.Desktop
{
    partial class FrmGiris
    {
        /// <summary>
        /// Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Temizleme işlemleri.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGiris));
            panelMain = new DevExpress.XtraEditors.PanelControl();
            panelRight = new DevExpress.XtraEditors.PanelControl();
            layoutControlLogin = new DevExpress.XtraLayout.LayoutControl();
            btnIptal = new DevExpress.XtraEditors.SimpleButton();
            btnGiris = new DevExpress.XtraEditors.SimpleButton();
            groupControlLogin = new DevExpress.XtraEditors.GroupControl();
            layoutControlFields = new DevExpress.XtraLayout.LayoutControl();
            txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            txtSifre = new DevExpress.XtraEditors.TextEdit();
            chkSifreGoster = new DevExpress.XtraEditors.CheckEdit();
            layoutControlGroupFields = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItemKullaniciAdi = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemSifre = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemSifreGoster = new DevExpress.XtraLayout.LayoutControlItem();
            lblLoginTitle = new DevExpress.XtraEditors.LabelControl();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItemLoginTitle = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemLoginGroup = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemButtons = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemIptal = new DevExpress.XtraLayout.LayoutControlItem();
            panelLeft = new DevExpress.XtraEditors.PanelControl();
            lblDescription = new DevExpress.XtraEditors.LabelControl();
            lblWelcome = new DevExpress.XtraEditors.LabelControl();
            lblSystemTitle = new DevExpress.XtraEditors.LabelControl();
            pictureEditLogo = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)panelMain).BeginInit();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelRight).BeginInit();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControlLogin).BeginInit();
            layoutControlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControlLogin).BeginInit();
            groupControlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControlFields).BeginInit();
            layoutControlFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtKullaniciAdi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSifre.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkSifreGoster.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupFields).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemKullaniciAdi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemSifre).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemSifreGoster).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemLoginTitle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemLoginGroup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemButtons).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemIptal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelLeft).BeginInit();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureEditLogo.Properties).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Appearance.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            panelMain.Appearance.Options.UseBackColor = true;
            panelMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelMain.Controls.Add(panelRight);
            panelMain.Controls.Add(panelLeft);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new System.Drawing.Size(900, 550);
            panelMain.TabIndex = 0;
            // 
            // panelRight
            // 
            panelRight.Appearance.BackColor = System.Drawing.Color.White;
            panelRight.Appearance.Options.UseBackColor = true;
            panelRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelRight.Controls.Add(layoutControlLogin);
            panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            panelRight.Location = new System.Drawing.Point(400, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(500, 550);
            panelRight.TabIndex = 1;
            // 
            // layoutControlLogin
            // 
            layoutControlLogin.Controls.Add(btnIptal);
            layoutControlLogin.Controls.Add(btnGiris);
            layoutControlLogin.Controls.Add(groupControlLogin);
            layoutControlLogin.Controls.Add(lblLoginTitle);
            layoutControlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlLogin.Location = new System.Drawing.Point(0, 0);
            layoutControlLogin.Name = "layoutControlLogin";
            layoutControlLogin.Root = Root;
            layoutControlLogin.Size = new System.Drawing.Size(500, 550);
            layoutControlLogin.TabIndex = 0;
            layoutControlLogin.Text = "layoutControlLogin";
            // 
            // btnIptal
            // 
            btnIptal.Appearance.BackColor = System.Drawing.Color.Transparent;
            btnIptal.Appearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            btnIptal.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            btnIptal.Appearance.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnIptal.Appearance.Options.UseBackColor = true;
            btnIptal.Appearance.Options.UseBorderColor = true;
            btnIptal.Appearance.Options.UseFont = true;
            btnIptal.Appearance.Options.UseForeColor = true;
            btnIptal.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            btnIptal.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            btnIptal.AppearanceHovered.Options.UseBackColor = true;
            btnIptal.AppearanceHovered.Options.UseBorderColor = true;
            btnIptal.Location = new System.Drawing.Point(204, 425);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new System.Drawing.Size(244, 73);
            btnIptal.StyleController = layoutControlLogin;
            btnIptal.TabIndex = 7;
            btnIptal.Text = "İptal";
            btnIptal.Click += btnIptal_Click;
            // 
            // btnGiris
            // 
            btnGiris.Appearance.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            btnGiris.Appearance.BorderColor = System.Drawing.Color.FromArgb(59, 130, 246);
            btnGiris.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            btnGiris.Appearance.ForeColor = System.Drawing.Color.White;
            btnGiris.Appearance.Options.UseBackColor = true;
            btnGiris.Appearance.Options.UseBorderColor = true;
            btnGiris.Appearance.Options.UseFont = true;
            btnGiris.Appearance.Options.UseForeColor = true;
            btnGiris.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            btnGiris.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(37, 99, 235);
            btnGiris.AppearanceHovered.Options.UseBackColor = true;
            btnGiris.AppearanceHovered.Options.UseBorderColor = true;
            btnGiris.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(29, 78, 216);
            btnGiris.AppearancePressed.BorderColor = System.Drawing.Color.FromArgb(29, 78, 216);
            btnGiris.AppearancePressed.Options.UseBackColor = true;
            btnGiris.AppearancePressed.Options.UseBorderColor = true;
            btnGiris.Location = new System.Drawing.Point(52, 425);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new System.Drawing.Size(148, 73);
            btnGiris.StyleController = layoutControlLogin;
            btnGiris.TabIndex = 6;
            btnGiris.Text = "Giriş Yap";
            btnGiris.Click += btnGiris_Click;
            // 
            // groupControlLogin
            // 
            groupControlLogin.Controls.Add(layoutControlFields);
            groupControlLogin.Location = new System.Drawing.Point(52, 110);
            groupControlLogin.Name = "groupControlLogin";
            groupControlLogin.Size = new System.Drawing.Size(396, 311);
            groupControlLogin.TabIndex = 5;
            groupControlLogin.Text = "Giriş Bilgileri";
            // 
            // layoutControlFields
            // 
            layoutControlFields.Controls.Add(txtKullaniciAdi);
            layoutControlFields.Controls.Add(txtSifre);
            layoutControlFields.Controls.Add(chkSifreGoster);
            layoutControlFields.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlFields.Location = new System.Drawing.Point(2, 28);
            layoutControlFields.Name = "layoutControlFields";
            layoutControlFields.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(874, 0, 650, 400);
            layoutControlFields.Root = layoutControlGroupFields;
            layoutControlFields.Size = new System.Drawing.Size(392, 281);
            layoutControlFields.TabIndex = 0;
            layoutControlFields.Text = "layoutControlFields";
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.EnterMoveNextControl = true;
            txtKullaniciAdi.Location = new System.Drawing.Point(113, 2);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            txtKullaniciAdi.Properties.Appearance.Options.UseFont = true;
            txtKullaniciAdi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtKullaniciAdi.Properties.NullText = "Kullanıcı adınızı girin";
            txtKullaniciAdi.Size = new System.Drawing.Size(284, 30);
            txtKullaniciAdi.StyleController = layoutControlFields;
            txtKullaniciAdi.TabIndex = 4;
            txtKullaniciAdi.KeyDown += txtKullaniciAdi_KeyDown;
            // 
            // txtSifre
            // 
            txtSifre.EnterMoveNextControl = true;
            txtSifre.Location = new System.Drawing.Point(111, 49);
            txtSifre.Name = "txtSifre";
            txtSifre.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            txtSifre.Properties.Appearance.Options.UseFont = true;
            txtSifre.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtSifre.Properties.NullText = "Şifrenizi girin";
            txtSifre.Properties.PasswordChar = '•';
            txtSifre.Size = new System.Drawing.Size(284, 30);
            txtSifre.StyleController = layoutControlFields;
            txtSifre.TabIndex = 5;
            txtSifre.KeyDown += txtSifre_KeyDown;
            // 
            // chkSifreGoster
            // 
            chkSifreGoster.Location = new System.Drawing.Point(12, 84);
            chkSifreGoster.Name = "chkSifreGoster";
            chkSifreGoster.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            chkSifreGoster.Properties.Appearance.Options.UseFont = true;
            chkSifreGoster.Properties.Caption = "Şifreyi göster";
            chkSifreGoster.Size = new System.Drawing.Size(392, 24);
            chkSifreGoster.StyleController = layoutControlFields;
            chkSifreGoster.TabIndex = 6;
            chkSifreGoster.CheckedChanged += chkSifreGoster_CheckedChanged;
            // 
            // layoutControlGroupFields
            // 
            layoutControlGroupFields.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroupFields.GroupBordersVisible = false;
            layoutControlGroupFields.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItemKullaniciAdi, layoutControlItemSifre, layoutControlItemSifreGoster });
            layoutControlGroupFields.Name = "Root";
            layoutControlGroupFields.Padding = new DevExpress.XtraLayout.Utils.Padding(12, 12, 22, 12);
            layoutControlGroupFields.Size = new System.Drawing.Size(416, 175);
            layoutControlGroupFields.TextVisible = false;
            // 
            // layoutControlItemKullaniciAdi
            // 
            layoutControlItemKullaniciAdi.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            layoutControlItemKullaniciAdi.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItemKullaniciAdi.Control = txtKullaniciAdi;
            layoutControlItemKullaniciAdi.Location = new System.Drawing.Point(0, 0);
            layoutControlItemKullaniciAdi.Name = "layoutControlItemKullaniciAdi";
            layoutControlItemKullaniciAdi.Size = new System.Drawing.Size(396, 36);
            layoutControlItemKullaniciAdi.Text = "Kullanıcı Adı:";
            layoutControlItemKullaniciAdi.TextSize = new System.Drawing.Size(97, 23);
            // 
            // layoutControlItemSifre
            // 
            layoutControlItemSifre.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            layoutControlItemSifre.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItemSifre.Control = txtSifre;
            layoutControlItemSifre.Location = new System.Drawing.Point(0, 36);
            layoutControlItemSifre.Name = "layoutControlItemSifre";
            layoutControlItemSifre.Size = new System.Drawing.Size(396, 36);
            layoutControlItemSifre.Text = "Şifre:";
            layoutControlItemSifre.TextSize = new System.Drawing.Size(97, 23);
            // 
            // layoutControlItemSifreGoster
            // 
            layoutControlItemSifreGoster.Control = chkSifreGoster;
            layoutControlItemSifreGoster.Location = new System.Drawing.Point(0, 72);
            layoutControlItemSifreGoster.Name = "layoutControlItemSifreGoster";
            layoutControlItemSifreGoster.Size = new System.Drawing.Size(396, 83);
            layoutControlItemSifreGoster.TextVisible = false;
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            lblLoginTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblLoginTitle.Appearance.Options.UseFont = true;
            lblLoginTitle.Appearance.Options.UseForeColor = true;
            lblLoginTitle.Location = new System.Drawing.Point(52, 52);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.Size = new System.Drawing.Size(159, 54);
            lblLoginTitle.StyleController = layoutControlLogin;
            lblLoginTitle.TabIndex = 4;
            lblLoginTitle.Text = "Giriş Yap";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItemLoginTitle, layoutControlItemLoginGroup, layoutControlItemButtons, layoutControlItemIptal });
            Root.Name = "Root";
            Root.Padding = new DevExpress.XtraLayout.Utils.Padding(50, 50, 50, 50);
            Root.Size = new System.Drawing.Size(500, 550);
            Root.TextVisible = false;
            // 
            // layoutControlItemLoginTitle
            // 
            layoutControlItemLoginTitle.Control = lblLoginTitle;
            layoutControlItemLoginTitle.Location = new System.Drawing.Point(0, 0);
            layoutControlItemLoginTitle.Name = "layoutControlItemLoginTitle";
            layoutControlItemLoginTitle.Size = new System.Drawing.Size(400, 58);
            layoutControlItemLoginTitle.TextVisible = false;
            // 
            // layoutControlItemLoginGroup
            // 
            layoutControlItemLoginGroup.Control = groupControlLogin;
            layoutControlItemLoginGroup.Location = new System.Drawing.Point(0, 58);
            layoutControlItemLoginGroup.Name = "layoutControlItemLoginGroup";
            layoutControlItemLoginGroup.Size = new System.Drawing.Size(400, 315);
            layoutControlItemLoginGroup.TextVisible = false;
            // 
            // layoutControlItemButtons
            // 
            layoutControlItemButtons.Control = btnGiris;
            layoutControlItemButtons.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            layoutControlItemButtons.Location = new System.Drawing.Point(0, 373);
            layoutControlItemButtons.MinSize = new System.Drawing.Size(150, 45);
            layoutControlItemButtons.Name = "layoutControlItemButtons";
            layoutControlItemButtons.Size = new System.Drawing.Size(152, 77);
            layoutControlItemButtons.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItemButtons.TextVisible = false;
            // 
            // layoutControlItemIptal
            // 
            layoutControlItemIptal.Control = btnIptal;
            layoutControlItemIptal.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            layoutControlItemIptal.Location = new System.Drawing.Point(152, 373);
            layoutControlItemIptal.MinSize = new System.Drawing.Size(150, 45);
            layoutControlItemIptal.Name = "layoutControlItemIptal";
            layoutControlItemIptal.Size = new System.Drawing.Size(248, 77);
            layoutControlItemIptal.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItemIptal.TextVisible = false;
            // 
            // panelLeft
            // 
            panelLeft.Appearance.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            panelLeft.Appearance.BackColor2 = System.Drawing.Color.FromArgb(99, 102, 241);
            panelLeft.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            panelLeft.Appearance.Options.UseBackColor = true;
            panelLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelLeft.Controls.Add(lblDescription);
            panelLeft.Controls.Add(lblWelcome);
            panelLeft.Controls.Add(lblSystemTitle);
            panelLeft.Controls.Add(pictureEditLogo);
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new System.Windows.Forms.Padding(50, 60, 50, 60);
            panelLeft.Size = new System.Drawing.Size(400, 550);
            panelLeft.TabIndex = 0;
            // 
            // lblDescription
            // 
            lblDescription.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            lblDescription.Appearance.ForeColor = System.Drawing.Color.FromArgb(220, 220, 255);
            lblDescription.Appearance.Options.UseFont = true;
            lblDescription.Appearance.Options.UseForeColor = true;
            lblDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblDescription.Location = new System.Drawing.Point(50, 320);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new System.Drawing.Size(300, 125);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Öğrenci burs başvurularını yönetmek, burs tanımlamak, öğrenci-burs eşleştirmeleri yapmak ve ödeme takiplerini gerçekleştirmek için kapsamlı bir yönetim platformu.";
            // 
            // lblWelcome
            // 
            lblWelcome.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            lblWelcome.Appearance.ForeColor = System.Drawing.Color.FromArgb(240, 240, 255);
            lblWelcome.Appearance.Options.UseFont = true;
            lblWelcome.Appearance.Options.UseForeColor = true;
            lblWelcome.Location = new System.Drawing.Point(50, 270);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new System.Drawing.Size(150, 37);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Hoş Geldiniz";
            // 
            // lblSystemTitle
            // 
            lblSystemTitle.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            lblSystemTitle.Appearance.ForeColor = System.Drawing.Color.White;
            lblSystemTitle.Appearance.Options.UseFont = true;
            lblSystemTitle.Appearance.Options.UseForeColor = true;
            lblSystemTitle.Location = new System.Drawing.Point(50, 200);
            lblSystemTitle.Name = "lblSystemTitle";
            lblSystemTitle.Size = new System.Drawing.Size(450, 62);
            lblSystemTitle.TabIndex = 1;
            lblSystemTitle.Text = "Burs Yönetim Sistemi";
            // 
            // pictureEditLogo
            // 
            pictureEditLogo.EditValue = resources.GetObject("pictureEditLogo.EditValue");
            pictureEditLogo.Location = new System.Drawing.Point(50, 60);
            pictureEditLogo.Name = "pictureEditLogo";
            pictureEditLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pictureEditLogo.Properties.ShowMenu = false;
            pictureEditLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            pictureEditLogo.Size = new System.Drawing.Size(120, 120);
            pictureEditLogo.TabIndex = 0;
            // 
            // FrmGiris
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(900, 550);
            Controls.Add(panelMain);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmGiris";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Burs Yönetim Sistemi - Giriş";
            ((System.ComponentModel.ISupportInitialize)panelMain).EndInit();
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelRight).EndInit();
            panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControlLogin).EndInit();
            layoutControlLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)groupControlLogin).EndInit();
            groupControlLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControlFields).EndInit();
            layoutControlFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtKullaniciAdi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSifre.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkSifreGoster.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupFields).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemKullaniciAdi).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemSifre).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemSifreGoster).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemLoginTitle).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemLoginGroup).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemButtons).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemIptal).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelLeft).EndInit();
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureEditLogo.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelMain;
        private DevExpress.XtraEditors.PanelControl panelLeft;
        private DevExpress.XtraEditors.PictureEdit pictureEditLogo;
        private DevExpress.XtraEditors.LabelControl lblSystemTitle;
        private DevExpress.XtraEditors.LabelControl lblWelcome;
        private DevExpress.XtraEditors.LabelControl lblDescription;
        private DevExpress.XtraEditors.PanelControl panelRight;
        private DevExpress.XtraLayout.LayoutControl layoutControlLogin;
        private DevExpress.XtraEditors.LabelControl lblLoginTitle;
        private DevExpress.XtraEditors.GroupControl groupControlLogin;
        private DevExpress.XtraLayout.LayoutControl layoutControlFields;
        private DevExpress.XtraEditors.TextEdit txtKullaniciAdi;
        private DevExpress.XtraEditors.TextEdit txtSifre;
        private DevExpress.XtraEditors.CheckEdit chkSifreGoster;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupFields;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemKullaniciAdi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemSifre;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemSifreGoster;
        private DevExpress.XtraEditors.SimpleButton btnGiris;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemLoginTitle;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemLoginGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemButtons;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemIptal;
    }
}
