using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Columns;

namespace OgrenciBursOtomasyonu.Desktop.Views.Burs
{
    partial class BursCollectionView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions3 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement5 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement6 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement7 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement8 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement9 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.colPhoto = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colFullNameBindable = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colHomePhone = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bursBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tileView = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.colId = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colOgrenciBursId = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.bursFilterView = new OgrenciBursOtomasyonu.Desktop.Views.Burs.BursFilterView();
            this.searchControl = new DevExpress.XtraEditors.SearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.windowsUIButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bursBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).BeginInit();
            this.SuspendLayout();
            
            
            
            this.splitContainerControl.Panel1.Controls.Add(this.bursFilterView);
            this.splitContainerControl.Panel2.Controls.Add(this.gridControl);
            this.splitContainerControl.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 40, 0);
            this.splitContainerControl.Size = new System.Drawing.Size(1139, 696);
            
            
            
            this.mvvmContext.ViewModelType = null; // TODO: typeof(OgrenciBursOtomasyonu.Desktop.ViewModels.BursCollectionViewModel);
            
            
            
            this.labelControl.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.labelControl.Appearance.Options.UseFont = true;
            this.labelControl.Appearance.Options.UseForeColor = true;
            this.labelControl.Appearance.Options.UseTextOptions = true;
            this.labelControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl.Size = new System.Drawing.Size(1139, 49);
            this.labelControl.Text = "BURS  <color=47, 81, 165>Categories</color>";
            
            
            
            this.windowsUIButtonPanel.AppearanceButton.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.windowsUIButtonPanel.AppearanceButton.Hovered.FontSizeDelta = -1;
            this.windowsUIButtonPanel.AppearanceButton.Hovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.windowsUIButtonPanel.AppearanceButton.Hovered.Options.UseBackColor = true;
            this.windowsUIButtonPanel.AppearanceButton.Hovered.Options.UseFont = true;
            this.windowsUIButtonPanel.AppearanceButton.Hovered.Options.UseForeColor = true;
            this.windowsUIButtonPanel.AppearanceButton.Normal.FontSizeDelta = -1;
            this.windowsUIButtonPanel.AppearanceButton.Normal.Options.UseFont = true;
            this.windowsUIButtonPanel.AppearanceButton.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.windowsUIButtonPanel.AppearanceButton.Pressed.FontSizeDelta = -1;
            this.windowsUIButtonPanel.AppearanceButton.Pressed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.windowsUIButtonPanel.AppearanceButton.Pressed.Options.UseBackColor = true;
            this.windowsUIButtonPanel.AppearanceButton.Pressed.Options.UseFont = true;
            this.windowsUIButtonPanel.AppearanceButton.Pressed.Options.UseForeColor = true;
            // Buton ikonları
            windowsUIButtonImageOptions1.ImageUri.Uri = OgrenciBursOtomasyonu.Desktop.Views.Common.CommonExtension.GetImageUri("Toolbar", "New").Uri;
            windowsUIButtonImageOptions2.ImageUri.Uri = OgrenciBursOtomasyonu.Desktop.Views.Common.CommonExtension.GetImageUri("Toolbar", "Edit").Uri;
            windowsUIButtonImageOptions3.ImageUri.Uri = OgrenciBursOtomasyonu.Desktop.Views.Common.CommonExtension.GetImageUri("Toolbar", "Task").Uri;
            this.windowsUIButtonPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Ekle", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Düzenle", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Burs Eşleştir", true, windowsUIButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.windowsUIButtonPanel.Controls.Add(this.searchControl);
            this.windowsUIButtonPanel.Location = new System.Drawing.Point(0, 745);
            this.windowsUIButtonPanel.PeekFormOptions.Size = new System.Drawing.Size(120, 135);
            this.windowsUIButtonPanel.Size = new System.Drawing.Size(1139, 89);
            
            
            
            this.colPhoto.FieldName = "Photo";
            this.colPhoto.Name = "colPhoto";
            this.colPhoto.Visible = true;
            this.colPhoto.VisibleIndex = 0;
            
            
            
            this.colFullNameBindable.FieldName = "FullNameBindable";
            this.colFullNameBindable.Name = "colFullNameBindable";
            this.colFullNameBindable.Visible = true;
            this.colFullNameBindable.VisibleIndex = 1;
            
            
            
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 2;
            
            
            
            this.colHomePhone.FieldName = "HomePhone";
            this.colHomePhone.Name = "colHomePhone";
            this.colHomePhone.Visible = true;
            this.colHomePhone.VisibleIndex = 3;
            
            
            
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 4;
            
            
            
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 5;
            
            
            
            this.gridControl.DataSource = this.bursBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.tileView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(739, 692);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileView});
            
            
            
            this.bursBindingSource.DataSource = typeof(OgrenciBursOtomasyonu.Desktop.Views.Burs.BursOgrenciDto);
            
            
            
            this.tileView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPhoto,
            this.colFullNameBindable,
            this.colAddress,
            this.colHomePhone,
            this.colEmail,
            this.colFullName,
            this.colId,
            this.colOgrenciBursId});
            this.tileView.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(168)))), ((int)(((byte)(210)))));
            this.tileView.GridControl = this.gridControl;
            this.tileView.Name = "tileView";
            this.tileView.OptionsBehavior.AllowSmoothScrolling = true;
            this.tileView.OptionsBehavior.KeepFocusedRowOnUpdate = false;
            this.tileView.OptionsTiles.AllowPressAnimation = false;
            this.tileView.OptionsTiles.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tileView.OptionsTiles.IndentBetweenItems = 20;
            this.tileView.OptionsTiles.ItemPadding = new System.Windows.Forms.Padding(12, 0, 12, 10);
            this.tileView.OptionsTiles.ItemSize = new System.Drawing.Size(335, 210);
            this.tileView.OptionsTiles.Padding = new System.Windows.Forms.Padding(4);
            this.tileView.OptionsTiles.RowCount = 8;
            this.tileView.OptionsTiles.ShowGroupText = false;
            this.tileView.OptionsTiles.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Top;
            tileViewItemElement1.Appearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            tileViewItemElement1.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement1.Height = 31;
            tileViewItemElement1.StretchHorizontal = true;
            tileViewItemElement1.Text = "";
            tileViewItemElement2.Column = this.colPhoto;
            tileViewItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;
            tileViewItemElement2.ImageOptions.ImageBorder = DevExpress.XtraEditors.TileItemElementImageBorderMode.SingleBorder;
            tileViewItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomOutside;
            tileViewItemElement2.ImageOptions.ImageSize = new System.Drawing.Size(122, 153);
            tileViewItemElement2.Text = "colPhoto";
            tileViewItemElement3.Column = this.colFullNameBindable;
            tileViewItemElement3.Text = "colFullNameBindable";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileViewItemElement3.TextLocation = new System.Drawing.Point(0, 5);
            tileViewItemElement4.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right;
            tileViewItemElement4.AnchorElementIndex = 1;
            tileViewItemElement4.AnchorIndent = 10;
            tileViewItemElement4.Appearance.Normal.ForeColor = System.Drawing.Color.Gray;
            tileViewItemElement4.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement4.Text = "ADDRESS";
            tileViewItemElement5.AnchorElementIndex = 3;
            tileViewItemElement5.AnchorIndent = 0;
            tileViewItemElement5.Column = this.colAddress;
            tileViewItemElement5.Height = 40;
            tileViewItemElement5.MaxWidth = 160;
            tileViewItemElement5.Text = "colAddress";
            tileViewItemElement6.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Bottom;
            tileViewItemElement6.AnchorElementIndex = 4;
            tileViewItemElement6.AnchorIndent = 10;
            tileViewItemElement6.Appearance.Normal.ForeColor = System.Drawing.Color.Gray;
            tileViewItemElement6.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement6.Text = "PHONE";
            tileViewItemElement7.AnchorElementIndex = 5;
            tileViewItemElement7.AnchorIndent = 0;
            tileViewItemElement7.Column = this.colHomePhone;
            tileViewItemElement7.Text = "colHomePhone";
            tileViewItemElement8.AnchorElementIndex = 6;
            tileViewItemElement8.Appearance.Normal.ForeColor = System.Drawing.Color.Gray;
            tileViewItemElement8.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement8.Text = "EMAIL";
            tileViewItemElement9.AnchorElementIndex = 7;
            tileViewItemElement9.AnchorIndent = 0;
            tileViewItemElement9.Column = this.colEmail;
            tileViewItemElement9.Text = "colEmail";
            this.tileView.TileTemplate.Add(tileViewItemElement1);
            this.tileView.TileTemplate.Add(tileViewItemElement2);
            this.tileView.TileTemplate.Add(tileViewItemElement3);
            this.tileView.TileTemplate.Add(tileViewItemElement4);
            this.tileView.TileTemplate.Add(tileViewItemElement5);
            this.tileView.TileTemplate.Add(tileViewItemElement6);
            this.tileView.TileTemplate.Add(tileViewItemElement7);
            this.tileView.TileTemplate.Add(tileViewItemElement8);
            this.tileView.TileTemplate.Add(tileViewItemElement9);
            
            
            
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            this.colId.VisibleIndex = -1;
            
            
            
            this.colOgrenciBursId.FieldName = "OgrenciBursId";
            this.colOgrenciBursId.Name = "colOgrenciBursId";
            this.colOgrenciBursId.Visible = false;
            this.colOgrenciBursId.VisibleIndex = -1;
            
            
            
            this.bursFilterView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bursFilterView.Location = new System.Drawing.Point(53, 3);
            this.bursFilterView.Margin = new System.Windows.Forms.Padding(4);
            this.bursFilterView.Name = "bursFilterView";
            this.bursFilterView.Size = new System.Drawing.Size(275, 690);
            this.bursFilterView.TabIndex = 0;
            
            
            
            this.searchControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchControl.Client = this.gridControl;
            this.searchControl.Location = new System.Drawing.Point(865, 20);
            this.searchControl.Name = "searchControl";
            this.searchControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl.Properties.Client = this.gridControl;
            this.searchControl.Size = new System.Drawing.Size(260, 42);
            this.searchControl.TabIndex = 0;
            
            
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "BursCollectionView";
            this.Size = new System.Drawing.Size(1139, 834);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.windowsUIButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bursBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private System.Windows.Forms.BindingSource bursBindingSource;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView;
        private DevExpress.XtraGrid.Columns.TileViewColumn colPhoto;
        private DevExpress.XtraGrid.Columns.TileViewColumn colFullNameBindable;
        private DevExpress.XtraGrid.Columns.TileViewColumn colAddress;
        private DevExpress.XtraGrid.Columns.TileViewColumn colHomePhone;
        private DevExpress.XtraGrid.Columns.TileViewColumn colEmail;
        private DevExpress.XtraGrid.Columns.TileViewColumn colFullName;
        private DevExpress.XtraGrid.Columns.TileViewColumn colId;
        private DevExpress.XtraGrid.Columns.TileViewColumn colOgrenciBursId;
        private BursFilterView bursFilterView;
        private DevExpress.XtraEditors.SearchControl searchControl;
    }
}
