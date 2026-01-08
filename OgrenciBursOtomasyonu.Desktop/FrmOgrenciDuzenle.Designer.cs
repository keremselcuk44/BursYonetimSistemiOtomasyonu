using DevExpress.XtraEditors;

namespace OgrenciBursOtomasyonu.Desktop
{
    partial class FrmOgrenciDuzenle
    {
        private System.ComponentModel.IContainer components = null;

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
            lblTcLabel = new LabelControl();
            txtTc = new TextEdit();
            lblAd = new LabelControl();
            txtAd = new TextEdit();
            lblSoyad = new LabelControl();
            txtSoyad = new TextEdit();
            lblYas = new LabelControl();
            txtYas = new TextEdit();
            lblUniversite = new LabelControl();
            txtUniversite = new TextEdit();
            lblBolum = new LabelControl();
            txtBolum = new TextEdit();
            lblSinif = new LabelControl();
            txtSinif = new TextEdit();
            lblEmail = new LabelControl();
            txtEmail = new TextEdit();
            lblTelefon = new LabelControl();
            txtTelefon = new TextEdit();
            lblIban = new LabelControl();
            txtIban = new TextEdit();
            lblFoto = new LabelControl();
            pictureEditResim = new PictureEdit();
            btnFotoYukle = new SimpleButton();
            btnKaydet = new SimpleButton();
            ((System.ComponentModel.ISupportInitialize)txtTc.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAd.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSoyad.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtYas.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUniversite.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBolum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSinif.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTelefon.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtIban.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureEditResim.Properties).BeginInit();
            SuspendLayout();
            // 
            // lblTcLabel
            // 
            lblTcLabel.Location = new System.Drawing.Point(20, 20);
            lblTcLabel.Name = "lblTcLabel";
            lblTcLabel.Size = new System.Drawing.Size(54, 16);
            lblTcLabel.TabIndex = 24;
            lblTcLabel.Text = "TC Kimlik";
            // 
            // txtTc
            // 
            txtTc.Location = new System.Drawing.Point(120, 17);
            txtTc.Name = "txtTc";
            txtTc.Properties.ReadOnly = true;
            txtTc.Size = new System.Drawing.Size(200, 22);
            txtTc.TabIndex = 23;
            // 
            // lblAd
            // 
            lblAd.Location = new System.Drawing.Point(20, 55);
            lblAd.Name = "lblAd";
            lblAd.Size = new System.Drawing.Size(15, 16);
            lblAd.TabIndex = 22;
            lblAd.Text = "Ad";
            // 
            // txtAd
            // 
            txtAd.Location = new System.Drawing.Point(120, 52);
            txtAd.Name = "txtAd";
            txtAd.Size = new System.Drawing.Size(200, 22);
            txtAd.TabIndex = 21;
            // 
            // lblSoyad
            // 
            lblSoyad.Location = new System.Drawing.Point(20, 90);
            lblSoyad.Name = "lblSoyad";
            lblSoyad.Size = new System.Drawing.Size(35, 16);
            lblSoyad.TabIndex = 18;
            lblSoyad.Text = "Soyad";
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new System.Drawing.Point(120, 87);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new System.Drawing.Size(200, 22);
            txtSoyad.TabIndex = 17;
            // 
            // lblYas
            // 
            lblYas.Location = new System.Drawing.Point(20, 125);
            lblYas.Name = "lblYas";
            lblYas.Size = new System.Drawing.Size(20, 16);
            lblYas.TabIndex = 20;
            lblYas.Text = "Yaş";
            // 
            // txtYas
            // 
            txtYas.Location = new System.Drawing.Point(120, 122);
            txtYas.Name = "txtYas";
            txtYas.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            txtYas.Properties.MaskSettings.Set("mask", "d");
            txtYas.Size = new System.Drawing.Size(200, 22);
            txtYas.TabIndex = 19;
            // 
            // lblUniversite
            // 
            lblUniversite.Location = new System.Drawing.Point(20, 160);
            lblUniversite.Name = "lblUniversite";
            lblUniversite.Size = new System.Drawing.Size(56, 16);
            lblUniversite.TabIndex = 16;
            lblUniversite.Text = "Üniversite";
            // 
            // txtUniversite
            // 
            txtUniversite.Location = new System.Drawing.Point(120, 157);
            txtUniversite.Name = "txtUniversite";
            txtUniversite.Size = new System.Drawing.Size(200, 22);
            txtUniversite.TabIndex = 15;
            // 
            // lblBolum
            // 
            lblBolum.Location = new System.Drawing.Point(20, 195);
            lblBolum.Name = "lblBolum";
            lblBolum.Size = new System.Drawing.Size(35, 16);
            lblBolum.TabIndex = 14;
            lblBolum.Text = "Bölüm";
            // 
            // txtBolum
            // 
            txtBolum.Location = new System.Drawing.Point(120, 192);
            txtBolum.Name = "txtBolum";
            txtBolum.Size = new System.Drawing.Size(200, 22);
            txtBolum.TabIndex = 13;
            // 
            // lblSinif
            // 
            lblSinif.Location = new System.Drawing.Point(20, 230);
            lblSinif.Name = "lblSinif";
            lblSinif.Size = new System.Drawing.Size(26, 16);
            lblSinif.TabIndex = 12;
            lblSinif.Text = "Sınıf";
            // 
            // txtSinif
            // 
            txtSinif.Location = new System.Drawing.Point(120, 227);
            txtSinif.Name = "txtSinif";
            txtSinif.Size = new System.Drawing.Size(200, 22);
            txtSinif.TabIndex = 11;
            // 
            // lblEmail
            // 
            lblEmail.Location = new System.Drawing.Point(20, 265);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(43, 16);
            lblEmail.TabIndex = 10;
            lblEmail.Text = "E-posta";
            // 
            // txtEmail
            // 
            txtEmail.Location = new System.Drawing.Point(120, 262);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(200, 22);
            txtEmail.TabIndex = 9;
            // 
            // lblTelefon
            // 
            lblTelefon.Location = new System.Drawing.Point(20, 300);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Size = new System.Drawing.Size(43, 16);
            lblTelefon.TabIndex = 8;
            lblTelefon.Text = "Telefon";
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new System.Drawing.Point(120, 297);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new System.Drawing.Size(200, 22);
            txtTelefon.TabIndex = 7;
            // 
            // lblIban
            // 
            lblIban.Location = new System.Drawing.Point(20, 335);
            lblIban.Name = "lblIban";
            lblIban.Size = new System.Drawing.Size(27, 16);
            lblIban.TabIndex = 6;
            lblIban.Text = "IBAN";
            // 
            // txtIban
            // 
            txtIban.Location = new System.Drawing.Point(120, 332);
            txtIban.Name = "txtIban";
            txtIban.Size = new System.Drawing.Size(200, 22);
            txtIban.TabIndex = 5;
            // 
            // lblFoto
            // 
            lblFoto.Location = new System.Drawing.Point(360, 20);
            lblFoto.Name = "lblFoto";
            lblFoto.Size = new System.Drawing.Size(84, 16);
            lblFoto.TabIndex = 4;
            lblFoto.Text = "Profil Fotoğrafı";
            // 
            // pictureEditResim
            // 
            pictureEditResim.Location = new System.Drawing.Point(360, 42);
            pictureEditResim.Name = "pictureEditResim";
            pictureEditResim.Properties.ShowMenu = false;
            pictureEditResim.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            pictureEditResim.Size = new System.Drawing.Size(260, 220);
            pictureEditResim.TabIndex = 3;
            // 
            // btnFotoYukle
            // 
            btnFotoYukle.Location = new System.Drawing.Point(360, 340);
            btnFotoYukle.Name = "btnFotoYukle";
            btnFotoYukle.Size = new System.Drawing.Size(120, 30);
            btnFotoYukle.TabIndex = 2;
            btnFotoYukle.Text = "Fotoğraf Yükle";
            btnFotoYukle.Click += btnFotoYukle_Click;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new System.Drawing.Point(500, 340);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new System.Drawing.Size(120, 30);
            btnKaydet.TabIndex = 1;
            btnKaydet.Text = "Kaydet";
            btnKaydet.Click += btnKaydet_Click;
            // 
            // FrmOgrenciDuzenle
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(650, 504);
            Controls.Add(btnKaydet);
            Controls.Add(btnFotoYukle);
            Controls.Add(pictureEditResim);
            Controls.Add(lblFoto);
            Controls.Add(txtIban);
            Controls.Add(lblIban);
            Controls.Add(txtTelefon);
            Controls.Add(lblTelefon);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtSinif);
            Controls.Add(lblSinif);
            Controls.Add(txtBolum);
            Controls.Add(lblBolum);
            Controls.Add(txtUniversite);
            Controls.Add(lblUniversite);
            Controls.Add(txtSoyad);
            Controls.Add(lblSoyad);
            Controls.Add(txtYas);
            Controls.Add(lblYas);
            Controls.Add(txtAd);
            Controls.Add(lblAd);
            Controls.Add(txtTc);
            Controls.Add(lblTcLabel);
            Name = "FrmOgrenciDuzenle";
            Text = "Öğrenci Düzenle";
            Load += FrmOgrenciDuzenle_Load;
            ((System.ComponentModel.ISupportInitialize)txtTc.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAd.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSoyad.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtYas.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUniversite.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBolum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSinif.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTelefon.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtIban.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureEditResim.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LabelControl lblTcLabel;
        private TextEdit txtTc;
        private LabelControl lblAd;
        private TextEdit txtAd;
        private LabelControl lblSoyad;
        private TextEdit txtSoyad;
        private LabelControl lblYas;
        private TextEdit txtYas;
        private LabelControl lblUniversite;
        private TextEdit txtUniversite;
        private LabelControl lblBolum;
        private TextEdit txtBolum;
        private LabelControl lblSinif;
        private TextEdit txtSinif;
        private LabelControl lblEmail;
        private TextEdit txtEmail;
        private LabelControl lblTelefon;
        private TextEdit txtTelefon;
        private LabelControl lblIban;
        private TextEdit txtIban;
        private LabelControl lblFoto;
        private PictureEdit pictureEditResim;
        private SimpleButton btnFotoYukle;
        private SimpleButton btnKaydet;
    }
}


