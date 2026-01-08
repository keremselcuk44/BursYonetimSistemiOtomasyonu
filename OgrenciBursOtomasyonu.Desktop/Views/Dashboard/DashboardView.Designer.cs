using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraCharts;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using OgrenciBursOtomasyonu.Desktop.Views.Common;

namespace OgrenciBursOtomasyonu.Desktop.Views.Dashboard {
    partial class DashboardView {
        private System.ComponentModel.IContainer components = null;
        private LayoutControl layoutControl1;
        private LabelControl labelControlBaslik;
        private GroupControl groupControlIstatistikler;
        private LabelControl lblToplamOgrenciBaslik;
        private LabelControl lblToplamOgrenci;
        private LabelControl lblBursiyerSayisiBaslik;
        private LabelControl lblBursiyerSayisi;
        private LabelControl lblBursiyerYuzde;
        private LabelControl lblToplamBursBaslik;
        private LabelControl lblToplamBurs;
        private LabelControl lblToplamOdemeBaslik;
        private LabelControl lblToplamOdeme;
        private LabelControl lblBekleyenOdemeBaslik;
        private LabelControl lblBekleyenOdeme;
        private GroupControl groupControlGrafikler;
        private ChartControl bursDagilimChartControl;
        private GroupControl groupControlSonOgrenciler;
        private GridControl gridControlSonOgrenciler;
        private GridView gridViewSonOgrenciler;
        private GroupControl groupControlPuanDagilimi;
        private ChartControl puanDagilimChartControl;
        private GroupControl groupControlOdemeTrendi;
        private ChartControl odemeTrendiChartControl;
        private SimpleButton btnYenile;
        private LayoutControlGroup Root;
        private LayoutControlItem layoutControlItemBaslik;
        private LayoutControlItem layoutControlItemIstatistikler;
        private LayoutControlGroup layoutControlGroupAlt;
        private LayoutControlItem layoutControlItemSonOgrenciler;
        private LayoutControlItem layoutControlItemGrafikler;
        private LayoutControlItem layoutControlItemPuanDagilimi;
        private LayoutControlItem layoutControlItemOdemeTrendi;
        private LayoutControlItem layoutControlItemYenile;

        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            if (disposing)
            {
                _httpClient?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new LayoutControl();
            this.labelControlBaslik = new LabelControl();
            this.groupControlIstatistikler = new GroupControl();
            this.lblBekleyenOdeme = new LabelControl();
            this.lblBekleyenOdemeBaslik = new LabelControl();
            this.lblToplamOdeme = new LabelControl();
            this.lblToplamOdemeBaslik = new LabelControl();
            this.lblToplamBurs = new LabelControl();
            this.lblToplamBursBaslik = new LabelControl();
            this.lblBursiyerYuzde = new LabelControl();
            this.lblBursiyerSayisi = new LabelControl();
            this.lblBursiyerSayisiBaslik = new LabelControl();
            this.lblToplamOgrenci = new LabelControl();
            this.lblToplamOgrenciBaslik = new LabelControl();
            this.groupControlGrafikler = new GroupControl();
            this.bursDagilimChartControl = new ChartControl();
            this.groupControlSonOgrenciler = new GroupControl();
            this.gridControlSonOgrenciler = new GridControl();
            this.gridViewSonOgrenciler = new GridView();
            this.groupControlPuanDagilimi = new GroupControl();
            this.puanDagilimChartControl = new ChartControl();
            this.groupControlOdemeTrendi = new GroupControl();
            this.odemeTrendiChartControl = new ChartControl();
            this.btnYenile = new SimpleButton();
            this.Root = new LayoutControlGroup();
            this.layoutControlItemBaslik = new LayoutControlItem();
            this.layoutControlItemIstatistikler = new LayoutControlItem();
            this.layoutControlGroupAlt = new LayoutControlGroup();
            this.layoutControlItemSonOgrenciler = new LayoutControlItem();
            this.layoutControlItemGrafikler = new LayoutControlItem();
            this.layoutControlItemPuanDagilimi = new LayoutControlItem();
            this.layoutControlItemOdemeTrendi = new LayoutControlItem();
            this.layoutControlItemYenile = new LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlIstatistikler)).BeginInit();
            this.groupControlIstatistikler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlGrafikler)).BeginInit();
            this.groupControlGrafikler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bursDagilimChartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSonOgrenciler)).BeginInit();
            this.groupControlSonOgrenciler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSonOgrenciler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSonOgrenciler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlPuanDagilimi)).BeginInit();
            this.groupControlPuanDagilimi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.puanDagilimChartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOdemeTrendi)).BeginInit();
            this.groupControlOdemeTrendi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.odemeTrendiChartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBaslik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemIstatistikler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupAlt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSonOgrenciler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGrafikler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPuanDagilimi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemOdemeTrendi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemYenile)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.labelControlBaslik);
            this.layoutControl1.Controls.Add(this.groupControlIstatistikler);
            this.layoutControl1.Controls.Add(this.groupControlSonOgrenciler);
            this.layoutControl1.Controls.Add(this.groupControlGrafikler);
            this.layoutControl1.Controls.Add(this.groupControlPuanDagilimi);
            this.layoutControl1.Controls.Add(this.groupControlOdemeTrendi);
            this.layoutControl1.Controls.Add(this.btnYenile);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(874, 0, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1200, 700);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // labelControlBaslik
            // 
            this.labelControlBaslik.AllowHtmlString = true;
            this.labelControlBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControlBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(81)))), ((int)(((byte)(165)))));
            this.labelControlBaslik.Appearance.Options.UseFont = true;
            this.labelControlBaslik.Appearance.Options.UseForeColor = true;
            this.labelControlBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlBaslik.Location = new System.Drawing.Point(12, 12);
            this.labelControlBaslik.Name = "labelControlBaslik";
            this.labelControlBaslik.Size = new System.Drawing.Size(1176, 40);
            this.labelControlBaslik.StyleController = this.layoutControl1;
            this.labelControlBaslik.TabIndex = 0;
            this.labelControlBaslik.Text = "ANA SAYFA - GENEL DURUM";
            // 
            // groupControlIstatistikler
            // 
            this.groupControlIstatistikler.Controls.Add(this.lblBekleyenOdeme);
            this.groupControlIstatistikler.Controls.Add(this.lblBekleyenOdemeBaslik);
            this.groupControlIstatistikler.Controls.Add(this.lblToplamOdeme);
            this.groupControlIstatistikler.Controls.Add(this.lblToplamOdemeBaslik);
            this.groupControlIstatistikler.Controls.Add(this.lblToplamBurs);
            this.groupControlIstatistikler.Controls.Add(this.lblToplamBursBaslik);
            this.groupControlIstatistikler.Controls.Add(this.lblBursiyerYuzde);
            this.groupControlIstatistikler.Controls.Add(this.lblBursiyerSayisi);
            this.groupControlIstatistikler.Controls.Add(this.lblBursiyerSayisiBaslik);
            this.groupControlIstatistikler.Controls.Add(this.lblToplamOgrenci);
            this.groupControlIstatistikler.Controls.Add(this.lblToplamOgrenciBaslik);
            this.groupControlIstatistikler.Location = new System.Drawing.Point(12, 56);
            this.groupControlIstatistikler.Name = "groupControlIstatistikler";
            this.groupControlIstatistikler.Size = new System.Drawing.Size(1176, 180);
            this.groupControlIstatistikler.TabIndex = 1;
            this.groupControlIstatistikler.Text = "Genel İstatistikler";
            // 
            // lblToplamOgrenciBaslik
            // 
            this.lblToplamOgrenciBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblToplamOgrenciBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblToplamOgrenciBaslik.Appearance.Options.UseFont = true;
            this.lblToplamOgrenciBaslik.Appearance.Options.UseForeColor = true;
            this.lblToplamOgrenciBaslik.Location = new System.Drawing.Point(20, 35);
            this.lblToplamOgrenciBaslik.Name = "lblToplamOgrenciBaslik";
            this.lblToplamOgrenciBaslik.Size = new System.Drawing.Size(200, 18);
            this.lblToplamOgrenciBaslik.TabIndex = 0;
            this.lblToplamOgrenciBaslik.Text = "Toplam Öğrenci";
            // 
            // lblToplamOgrenci
            // 
            this.lblToplamOgrenci.Appearance.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblToplamOgrenci.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(81)))), ((int)(((byte)(165)))));
            this.lblToplamOgrenci.Appearance.Options.UseFont = true;
            this.lblToplamOgrenci.Appearance.Options.UseForeColor = true;
            this.lblToplamOgrenci.Location = new System.Drawing.Point(20, 60);
            this.lblToplamOgrenci.Name = "lblToplamOgrenci";
            this.lblToplamOgrenci.Size = new System.Drawing.Size(200, 50);
            this.lblToplamOgrenci.TabIndex = 1;
            this.lblToplamOgrenci.Text = "0";
            // 
            // lblBursiyerSayisiBaslik
            // 
            this.lblBursiyerSayisiBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBursiyerSayisiBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblBursiyerSayisiBaslik.Appearance.Options.UseFont = true;
            this.lblBursiyerSayisiBaslik.Appearance.Options.UseForeColor = true;
            this.lblBursiyerSayisiBaslik.Location = new System.Drawing.Point(240, 35);
            this.lblBursiyerSayisiBaslik.Name = "lblBursiyerSayisiBaslik";
            this.lblBursiyerSayisiBaslik.Size = new System.Drawing.Size(200, 18);
            this.lblBursiyerSayisiBaslik.TabIndex = 2;
            this.lblBursiyerSayisiBaslik.Text = "Bursiyer Sayısı";
            // 
            // lblBursiyerSayisi
            // 
            this.lblBursiyerSayisi.Appearance.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBursiyerSayisi.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblBursiyerSayisi.Appearance.Options.UseFont = true;
            this.lblBursiyerSayisi.Appearance.Options.UseForeColor = true;
            this.lblBursiyerSayisi.Location = new System.Drawing.Point(240, 60);
            this.lblBursiyerSayisi.Name = "lblBursiyerSayisi";
            this.lblBursiyerSayisi.Size = new System.Drawing.Size(200, 50);
            this.lblBursiyerSayisi.TabIndex = 3;
            this.lblBursiyerSayisi.Text = "0";
            // 
            // lblBursiyerYuzde
            // 
            this.lblBursiyerYuzde.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBursiyerYuzde.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblBursiyerYuzde.Appearance.Options.UseFont = true;
            this.lblBursiyerYuzde.Appearance.Options.UseForeColor = true;
            this.lblBursiyerYuzde.Location = new System.Drawing.Point(240, 120);
            this.lblBursiyerYuzde.Name = "lblBursiyerYuzde";
            this.lblBursiyerYuzde.Size = new System.Drawing.Size(200, 25);
            this.lblBursiyerYuzde.TabIndex = 4;
            this.lblBursiyerYuzde.Text = "%0";
            // 
            // lblToplamBursBaslik
            // 
            this.lblToplamBursBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblToplamBursBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblToplamBursBaslik.Appearance.Options.UseFont = true;
            this.lblToplamBursBaslik.Appearance.Options.UseForeColor = true;
            this.lblToplamBursBaslik.Location = new System.Drawing.Point(460, 35);
            this.lblToplamBursBaslik.Name = "lblToplamBursBaslik";
            this.lblToplamBursBaslik.Size = new System.Drawing.Size(200, 18);
            this.lblToplamBursBaslik.TabIndex = 5;
            this.lblToplamBursBaslik.Text = "Toplam Burs";
            // 
            // lblToplamBurs
            // 
            this.lblToplamBurs.Appearance.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblToplamBurs.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(85)))), ((int)(((byte)(247)))));
            this.lblToplamBurs.Appearance.Options.UseFont = true;
            this.lblToplamBurs.Appearance.Options.UseForeColor = true;
            this.lblToplamBurs.Location = new System.Drawing.Point(460, 60);
            this.lblToplamBurs.Name = "lblToplamBurs";
            this.lblToplamBurs.Size = new System.Drawing.Size(200, 50);
            this.lblToplamBurs.TabIndex = 6;
            this.lblToplamBurs.Text = "0";
            // 
            // lblToplamOdemeBaslik
            // 
            this.lblToplamOdemeBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblToplamOdemeBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblToplamOdemeBaslik.Appearance.Options.UseFont = true;
            this.lblToplamOdemeBaslik.Appearance.Options.UseForeColor = true;
            this.lblToplamOdemeBaslik.Location = new System.Drawing.Point(680, 35);
            this.lblToplamOdemeBaslik.Name = "lblToplamOdemeBaslik";
            this.lblToplamOdemeBaslik.Size = new System.Drawing.Size(200, 18);
            this.lblToplamOdemeBaslik.TabIndex = 7;
            this.lblToplamOdemeBaslik.Text = "Toplam Ödeme";
            // 
            // lblToplamOdeme
            // 
            this.lblToplamOdeme.Appearance.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblToplamOdeme.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblToplamOdeme.Appearance.Options.UseFont = true;
            this.lblToplamOdeme.Appearance.Options.UseForeColor = true;
            this.lblToplamOdeme.Location = new System.Drawing.Point(680, 60);
            this.lblToplamOdeme.Name = "lblToplamOdeme";
            this.lblToplamOdeme.Size = new System.Drawing.Size(200, 43);
            this.lblToplamOdeme.TabIndex = 8;
            this.lblToplamOdeme.Text = "₺0,00";
            // 
            // lblBekleyenOdemeBaslik
            // 
            this.lblBekleyenOdemeBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBekleyenOdemeBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblBekleyenOdemeBaslik.Appearance.Options.UseFont = true;
            this.lblBekleyenOdemeBaslik.Appearance.Options.UseForeColor = true;
            this.lblBekleyenOdemeBaslik.Location = new System.Drawing.Point(900, 35);
            this.lblBekleyenOdemeBaslik.Name = "lblBekleyenOdemeBaslik";
            this.lblBekleyenOdemeBaslik.Size = new System.Drawing.Size(200, 18);
            this.lblBekleyenOdemeBaslik.TabIndex = 9;
            this.lblBekleyenOdemeBaslik.Text = "Bekleyen Ödeme";
            // 
            // lblBekleyenOdeme
            // 
            this.lblBekleyenOdeme.Appearance.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBekleyenOdeme.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblBekleyenOdeme.Appearance.Options.UseFont = true;
            this.lblBekleyenOdeme.Appearance.Options.UseForeColor = true;
            this.lblBekleyenOdeme.Location = new System.Drawing.Point(900, 60);
            this.lblBekleyenOdeme.Name = "lblBekleyenOdeme";
            this.lblBekleyenOdeme.Size = new System.Drawing.Size(200, 50);
            this.lblBekleyenOdeme.TabIndex = 10;
            this.lblBekleyenOdeme.Text = "0";
            // 
            // groupControlSonOgrenciler
            // 
            this.groupControlSonOgrenciler.Controls.Add(this.gridControlSonOgrenciler);
            this.groupControlSonOgrenciler.Location = new System.Drawing.Point(12, 240);
            this.groupControlSonOgrenciler.Name = "groupControlSonOgrenciler";
            this.groupControlSonOgrenciler.Size = new System.Drawing.Size(580, 200);
            this.groupControlSonOgrenciler.TabIndex = 2;
            this.groupControlSonOgrenciler.Text = "Son Eklenen Öğrenciler";
            // 
            // gridControlSonOgrenciler
            // 
            this.gridControlSonOgrenciler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSonOgrenciler.Location = new System.Drawing.Point(2, 23);
            this.gridControlSonOgrenciler.MainView = this.gridViewSonOgrenciler;
            this.gridControlSonOgrenciler.Name = "gridControlSonOgrenciler";
            this.gridControlSonOgrenciler.Size = new System.Drawing.Size(576, 175);
            this.gridControlSonOgrenciler.TabIndex = 0;
            this.gridControlSonOgrenciler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSonOgrenciler});
            // 
            // gridViewSonOgrenciler
            // 
            this.gridViewSonOgrenciler.GridControl = this.gridControlSonOgrenciler;
            this.gridViewSonOgrenciler.Name = "gridViewSonOgrenciler";
            this.gridViewSonOgrenciler.OptionsView.ShowGroupPanel = false;
            this.gridViewSonOgrenciler.OptionsView.ShowIndicator = false;
            // 
            // groupControlGrafikler
            // 
            this.groupControlGrafikler.Controls.Add(this.bursDagilimChartControl);
            this.groupControlGrafikler.Location = new System.Drawing.Point(608, 240);
            this.groupControlGrafikler.Name = "groupControlGrafikler";
            this.groupControlGrafikler.Size = new System.Drawing.Size(580, 200);
            this.groupControlGrafikler.TabIndex = 3;
            this.groupControlGrafikler.Text = "Burs Dağılımı";
            // 
            // bursDagilimChartControl
            // 
            this.bursDagilimChartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bursDagilimChartControl.Location = new System.Drawing.Point(2, 23);
            this.bursDagilimChartControl.Name = "bursDagilimChartControl";
            this.bursDagilimChartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.bursDagilimChartControl.Size = new System.Drawing.Size(576, 175);
            this.bursDagilimChartControl.TabIndex = 0;
            // 
            // groupControlPuanDagilimi
            // 
            this.groupControlPuanDagilimi.Controls.Add(this.puanDagilimChartControl);
            this.groupControlPuanDagilimi.Location = new System.Drawing.Point(12, 444);
            this.groupControlPuanDagilimi.Name = "groupControlPuanDagilimi";
            this.groupControlPuanDagilimi.Size = new System.Drawing.Size(580, 200);
            this.groupControlPuanDagilimi.TabIndex = 4;
            this.groupControlPuanDagilimi.Text = "Puan Dağılımı";
            // 
            // puanDagilimChartControl
            // 
            this.puanDagilimChartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.puanDagilimChartControl.Location = new System.Drawing.Point(2, 23);
            this.puanDagilimChartControl.Name = "puanDagilimChartControl";
            this.puanDagilimChartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.puanDagilimChartControl.Size = new System.Drawing.Size(576, 175);
            this.puanDagilimChartControl.TabIndex = 0;
            // 
            // groupControlOdemeTrendi
            // 
            this.groupControlOdemeTrendi.Controls.Add(this.odemeTrendiChartControl);
            this.groupControlOdemeTrendi.Location = new System.Drawing.Point(608, 444);
            this.groupControlOdemeTrendi.Name = "groupControlOdemeTrendi";
            this.groupControlOdemeTrendi.Size = new System.Drawing.Size(580, 200);
            this.groupControlOdemeTrendi.TabIndex = 5;
            this.groupControlOdemeTrendi.Text = "Aylık Ödeme Trendi";
            // 
            // odemeTrendiChartControl
            // 
            this.odemeTrendiChartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.odemeTrendiChartControl.Location = new System.Drawing.Point(2, 23);
            this.odemeTrendiChartControl.Name = "odemeTrendiChartControl";
            this.odemeTrendiChartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.odemeTrendiChartControl.Size = new System.Drawing.Size(576, 175);
            this.odemeTrendiChartControl.TabIndex = 0;
            // 
            // btnYenile
            // 
            this.btnYenile.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnYenile.Appearance.Options.UseFont = true;
            this.btnYenile.ImageOptions.ImageUri = ToolbarExtension.GetImageUri("Settings");
            this.btnYenile.Location = new System.Drawing.Point(1088, 664);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(100, 32);
            this.btnYenile.StyleController = this.layoutControl1;
            this.btnYenile.TabIndex = 3;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemBaslik,
            this.layoutControlItemIstatistikler,
            this.layoutControlGroupAlt,
            this.layoutControlItemYenile});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(12, 12, 12, 12);
            this.Root.Size = new System.Drawing.Size(1200, 700);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroupAlt
            // 
            this.layoutControlGroupAlt.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemSonOgrenciler,
            this.layoutControlItemGrafikler,
            this.layoutControlItemPuanDagilimi,
            this.layoutControlItemOdemeTrendi});
            this.layoutControlGroupAlt.Location = new System.Drawing.Point(0, 228);
            this.layoutControlGroupAlt.Name = "layoutControlGroupAlt";
            this.layoutControlGroupAlt.OptionsTableLayoutItem.ColumnIndex = 0;
            this.layoutControlGroupAlt.OptionsTableLayoutItem.ColumnSpan = 2;
            this.layoutControlGroupAlt.OptionsTableLayoutItem.RowIndex = 2;
            this.layoutControlGroupAlt.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            new DevExpress.XtraLayout.ColumnDefinition(),
            new DevExpress.XtraLayout.ColumnDefinition()});
            this.layoutControlGroupAlt.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            new DevExpress.XtraLayout.RowDefinition(),
            new DevExpress.XtraLayout.RowDefinition()});
            this.layoutControlGroupAlt.Size = new System.Drawing.Size(1180, 416);
            this.layoutControlGroupAlt.TextVisible = false;
            // 
            // layoutControlItemBaslik
            // 
            this.layoutControlItemBaslik.Control = this.labelControlBaslik;
            this.layoutControlItemBaslik.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemBaslik.Name = "layoutControlItemBaslik";
            this.layoutControlItemBaslik.Size = new System.Drawing.Size(1180, 44);
            this.layoutControlItemBaslik.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBaslik.TextVisible = false;
            // 
            // layoutControlItemIstatistikler
            // 
            this.layoutControlItemIstatistikler.Control = this.groupControlIstatistikler;
            this.layoutControlItemIstatistikler.Location = new System.Drawing.Point(0, 44);
            this.layoutControlItemIstatistikler.Name = "layoutControlItemIstatistikler";
            this.layoutControlItemIstatistikler.Size = new System.Drawing.Size(1180, 184);
            this.layoutControlItemIstatistikler.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemIstatistikler.TextVisible = false;
            // 
            // layoutControlItemSonOgrenciler
            // 
            this.layoutControlItemSonOgrenciler.Control = this.groupControlSonOgrenciler;
            this.layoutControlItemSonOgrenciler.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemSonOgrenciler.Name = "layoutControlItemSonOgrenciler";
            this.layoutControlItemSonOgrenciler.OptionsTableLayoutItem.ColumnIndex = 0;
            this.layoutControlItemSonOgrenciler.OptionsTableLayoutItem.RowIndex = 0;
            this.layoutControlItemSonOgrenciler.Size = new System.Drawing.Size(584, 204);
            this.layoutControlItemSonOgrenciler.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemSonOgrenciler.TextVisible = false;
            // 
            // layoutControlItemGrafikler
            // 
            this.layoutControlItemGrafikler.Control = this.groupControlGrafikler;
            this.layoutControlItemGrafikler.Location = new System.Drawing.Point(584, 0);
            this.layoutControlItemGrafikler.Name = "layoutControlItemGrafikler";
            this.layoutControlItemGrafikler.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItemGrafikler.OptionsTableLayoutItem.RowIndex = 0;
            this.layoutControlItemGrafikler.Size = new System.Drawing.Size(584, 204);
            this.layoutControlItemGrafikler.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemGrafikler.TextVisible = false;
            // 
            // layoutControlItemPuanDagilimi
            // 
            this.layoutControlItemPuanDagilimi.Control = this.groupControlPuanDagilimi;
            this.layoutControlItemPuanDagilimi.Location = new System.Drawing.Point(0, 204);
            this.layoutControlItemPuanDagilimi.Name = "layoutControlItemPuanDagilimi";
            this.layoutControlItemPuanDagilimi.OptionsTableLayoutItem.ColumnIndex = 0;
            this.layoutControlItemPuanDagilimi.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItemPuanDagilimi.Size = new System.Drawing.Size(584, 204);
            this.layoutControlItemPuanDagilimi.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemPuanDagilimi.TextVisible = false;
            // 
            // layoutControlItemOdemeTrendi
            // 
            this.layoutControlItemOdemeTrendi.Control = this.groupControlOdemeTrendi;
            this.layoutControlItemOdemeTrendi.Location = new System.Drawing.Point(584, 204);
            this.layoutControlItemOdemeTrendi.Name = "layoutControlItemOdemeTrendi";
            this.layoutControlItemOdemeTrendi.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItemOdemeTrendi.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItemOdemeTrendi.Size = new System.Drawing.Size(584, 204);
            this.layoutControlItemOdemeTrendi.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemOdemeTrendi.TextVisible = false;
            // 
            // layoutControlItemYenile
            // 
            this.layoutControlItemYenile.Control = this.btnYenile;
            this.layoutControlItemYenile.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItemYenile.Location = new System.Drawing.Point(1076, 652);
            this.layoutControlItemYenile.MinSize = new System.Drawing.Size(100, 32);
            this.layoutControlItemYenile.Name = "layoutControlItemYenile";
            this.layoutControlItemYenile.Size = new System.Drawing.Size(104, 36);
            this.layoutControlItemYenile.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemYenile.TextVisible = false;
            // 
            // DashboardView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "DashboardView";
            this.Size = new System.Drawing.Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlIstatistikler)).EndInit();
            this.groupControlIstatistikler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlGrafikler)).EndInit();
            this.groupControlGrafikler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bursDagilimChartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSonOgrenciler)).EndInit();
            this.groupControlSonOgrenciler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSonOgrenciler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSonOgrenciler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlPuanDagilimi)).EndInit();
            this.groupControlPuanDagilimi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.puanDagilimChartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOdemeTrendi)).EndInit();
            this.groupControlOdemeTrendi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.odemeTrendiChartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBaslik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemIstatistikler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupAlt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSonOgrenciler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGrafikler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPuanDagilimi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemOdemeTrendi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemYenile)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
