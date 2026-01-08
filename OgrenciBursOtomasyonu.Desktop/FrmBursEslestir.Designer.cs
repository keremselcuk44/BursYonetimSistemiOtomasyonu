using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using OgrenciBursOtomasyonu.Desktop.Views.Common;

namespace OgrenciBursOtomasyonu.Desktop
{
    partial class FrmBursEslestir
    {
        private System.ComponentModel.IContainer components = null;
        private LayoutControl layoutControl1;
        private LabelControl labelControlBaslik;
        private GroupControl groupControlOgrenciler;
        private GridControl gridControlOgrenciler;
        private GridView gridViewOgrenciler;
        private GroupControl groupControlBurslar;
        private GridControl gridControlBurslar;
        private GridView gridViewBurslar;
        private SimpleButton btnEslestir;
        private SimpleButton btnYenile;
        private LayoutControlGroup Root;
        private LayoutControlItem layoutControlItemBaslik;
        private LayoutControlItem layoutControlItemOgrenciGroup;
        private LayoutControlItem layoutControlItemBursGroup;
        private LayoutControlItem layoutControlItemButtons;
        private LayoutControlItem layoutControlItemEslestir;

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
            this.groupControlOgrenciler = new GroupControl();
            this.gridControlOgrenciler = new GridControl();
            this.gridViewOgrenciler = new GridView();
            this.groupControlBurslar = new GroupControl();
            this.gridControlBurslar = new GridControl();
            this.gridViewBurslar = new GridView();
            this.btnEslestir = new SimpleButton();
            this.btnYenile = new SimpleButton();
            this.Root = new LayoutControlGroup();
            this.layoutControlItemBaslik = new LayoutControlItem();
            this.layoutControlItemOgrenciGroup = new LayoutControlItem();
            this.layoutControlItemBursGroup = new LayoutControlItem();
            this.layoutControlItemButtons = new LayoutControlItem();
            this.layoutControlItemEslestir = new LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOgrenciler)).BeginInit();
            this.groupControlOgrenciler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOgrenciler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOgrenciler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBurslar)).BeginInit();
            this.groupControlBurslar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBurslar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBurslar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBaslik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemOgrenciGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBursGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemEslestir)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.labelControlBaslik);
            this.layoutControl1.Controls.Add(this.groupControlOgrenciler);
            this.layoutControl1.Controls.Add(this.groupControlBurslar);
            this.layoutControl1.Controls.Add(this.btnYenile);
            this.layoutControl1.Controls.Add(this.btnEslestir);
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
            this.labelControlBaslik.TabIndex = 7;
            this.labelControlBaslik.Text = "BURS EŞLEŞTİRME";
            // 
            // groupControlOgrenciler
            // 
            this.groupControlOgrenciler.Controls.Add(this.gridControlOgrenciler);
            this.groupControlOgrenciler.Location = new System.Drawing.Point(12, 41);
            this.groupControlOgrenciler.Name = "groupControlOgrenciler";
            this.groupControlOgrenciler.Size = new System.Drawing.Size(676, 590);
            this.groupControlOgrenciler.TabIndex = 8;
            this.groupControlOgrenciler.Text = "Burs Almayan Öğrenciler";
            // 
            // gridControlOgrenciler
            // 
            this.gridControlOgrenciler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlOgrenciler.Location = new System.Drawing.Point(2, 23);
            this.gridControlOgrenciler.MainView = this.gridViewOgrenciler;
            this.gridControlOgrenciler.Name = "gridControlOgrenciler";
            this.gridControlOgrenciler.Size = new System.Drawing.Size(672, 565);
            this.gridControlOgrenciler.TabIndex = 0;
            this.gridControlOgrenciler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOgrenciler});
            // 
            // gridViewOgrenciler
            // 
            this.gridViewOgrenciler.GridControl = this.gridControlOgrenciler;
            this.gridViewOgrenciler.Name = "gridViewOgrenciler";
            this.gridViewOgrenciler.OptionsBehavior.Editable = false;
            this.gridViewOgrenciler.OptionsSelection.MultiSelect = false;
            this.gridViewOgrenciler.OptionsView.ShowGroupPanel = false;
            this.gridViewOgrenciler.OptionsView.ShowIndicator = false;
            // 
            // groupControlBurslar
            // 
            this.groupControlBurslar.Controls.Add(this.gridControlBurslar);
            this.groupControlBurslar.Location = new System.Drawing.Point(692, 41);
            this.groupControlBurslar.Name = "groupControlBurslar";
            this.groupControlBurslar.Size = new System.Drawing.Size(672, 590);
            this.groupControlBurslar.TabIndex = 9;
            this.groupControlBurslar.Text = "Mevcut Burslar";
            // 
            // gridControlBurslar
            // 
            this.gridControlBurslar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlBurslar.Location = new System.Drawing.Point(2, 23);
            this.gridControlBurslar.MainView = this.gridViewBurslar;
            this.gridControlBurslar.Name = "gridControlBurslar";
            this.gridControlBurslar.Size = new System.Drawing.Size(668, 565);
            this.gridControlBurslar.TabIndex = 0;
            this.gridControlBurslar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewBurslar});
            // 
            // gridViewBurslar
            // 
            this.gridViewBurslar.GridControl = this.gridControlBurslar;
            this.gridViewBurslar.Name = "gridViewBurslar";
            this.gridViewBurslar.OptionsBehavior.Editable = false;
            this.gridViewBurslar.OptionsSelection.MultiSelect = false;
            this.gridViewBurslar.OptionsView.ShowGroupPanel = false;
            this.gridViewBurslar.OptionsView.ShowIndicator = false;
            // 
            // btnEslestir
            // 
            this.btnEslestir.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEslestir.Appearance.Options.UseFont = true;
            this.btnEslestir.ImageOptions.ImageUri = ToolbarExtension.GetImageUri("Task");
            this.btnEslestir.Location = new System.Drawing.Point(1188, 635);
            this.btnEslestir.Name = "btnEslestir";
            this.btnEslestir.Size = new System.Drawing.Size(176, 41);
            this.btnEslestir.StyleController = this.layoutControl1;
            this.btnEslestir.TabIndex = 5;
            this.btnEslestir.Text = "Eşleştir";
            this.btnEslestir.Click += new System.EventHandler(this.btnEslestir_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnYenile.Appearance.Options.UseFont = true;
            this.btnYenile.ImageOptions.ImageUri = ToolbarExtension.GetImageUri("Settings");
            this.btnYenile.Location = new System.Drawing.Point(12, 635);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(120, 41);
            this.btnYenile.StyleController = this.layoutControl1;
            this.btnYenile.TabIndex = 6;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemBaslik,
            this.layoutControlItemOgrenciGroup,
            this.layoutControlItemBursGroup,
            this.layoutControlItemButtons,
            this.layoutControlItemEslestir});
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
            // layoutControlItemOgrenciGroup
            // 
            this.layoutControlItemOgrenciGroup.Control = this.groupControlOgrenciler;
            this.layoutControlItemOgrenciGroup.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItemOgrenciGroup.Name = "layoutControlItemOgrenciGroup";
            this.layoutControlItemOgrenciGroup.Size = new System.Drawing.Size(680, 594);
            this.layoutControlItemOgrenciGroup.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemOgrenciGroup.TextVisible = false;
            // 
            // layoutControlItemBursGroup
            // 
            this.layoutControlItemBursGroup.Control = this.groupControlBurslar;
            this.layoutControlItemBursGroup.Location = new System.Drawing.Point(680, 29);
            this.layoutControlItemBursGroup.Name = "layoutControlItemBursGroup";
            this.layoutControlItemBursGroup.Size = new System.Drawing.Size(676, 594);
            this.layoutControlItemBursGroup.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBursGroup.TextVisible = false;
            // 
            // layoutControlItemButtons
            // 
            this.layoutControlItemButtons.Control = this.btnYenile;
            this.layoutControlItemButtons.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItemButtons.Location = new System.Drawing.Point(0, 623);
            this.layoutControlItemButtons.MinSize = new System.Drawing.Size(120, 41);
            this.layoutControlItemButtons.Name = "layoutControlItemButtons";
            this.layoutControlItemButtons.Size = new System.Drawing.Size(1176, 45);
            this.layoutControlItemButtons.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemButtons.TextVisible = false;
            // 
            // layoutControlItemEslestir
            // 
            this.layoutControlItemEslestir.Control = this.btnEslestir;
            this.layoutControlItemEslestir.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItemEslestir.Location = new System.Drawing.Point(1176, 623);
            this.layoutControlItemEslestir.MinSize = new System.Drawing.Size(176, 41);
            this.layoutControlItemEslestir.Name = "layoutControlItemEslestir";
            this.layoutControlItemEslestir.Size = new System.Drawing.Size(180, 45);
            this.layoutControlItemEslestir.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemEslestir.TextVisible = false;
            // 
            // FrmBursEslestir
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1376, 700);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmBursEslestir";
            this.Text = "Burs Eşleştir";
            this.Load += new System.EventHandler(this.FrmBursEslestir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOgrenciler)).EndInit();
            this.groupControlOgrenciler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOgrenciler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOgrenciler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBurslar)).EndInit();
            this.groupControlBurslar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBurslar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBurslar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBaslik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemOgrenciGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBursGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemEslestir)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
