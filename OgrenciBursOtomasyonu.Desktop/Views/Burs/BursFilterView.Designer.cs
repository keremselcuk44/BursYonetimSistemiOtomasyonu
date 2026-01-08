using DevExpress.XtraEditors;
using DevExpress.Utils;

namespace OgrenciBursOtomasyonu.Desktop.Views.Burs
{
    partial class BursFilterView
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
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            
            
            
            this.mvvmContext.ViewModelType = null; // TODO: typeof(OgrenciBursOtomasyonu.Desktop.ViewModels.BursFilterViewModel);
            
            
            
            this.filterTileControl.AppearanceItem.Normal.BackColor = System.Drawing.Color.White;
            this.filterTileControl.AppearanceItem.Normal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.filterTileControl.AppearanceItem.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.filterTileControl.AppearanceItem.Normal.Options.UseBackColor = true;
            this.filterTileControl.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.filterTileControl.AppearanceItem.Normal.Options.UseFont = true;
            this.filterTileControl.AppearanceItem.Normal.Options.UseForeColor = true;
            this.filterTileControl.AppearanceItem.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(38)))), ((int)(((byte)(115)))));
            this.filterTileControl.AppearanceItem.Pressed.ForeColor = System.Drawing.Color.Gainsboro;
            this.filterTileControl.AppearanceItem.Pressed.Options.UseBackColor = true;
            this.filterTileControl.AppearanceItem.Pressed.Options.UseFont = true;
            this.filterTileControl.AppearanceItem.Pressed.Options.UseForeColor = true;
            this.filterTileControl.AppearanceItem.Selected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(81)))), ((int)(((byte)(165)))));
            this.filterTileControl.AppearanceItem.Selected.BorderColor = System.Drawing.Color.Transparent;
            this.filterTileControl.AppearanceItem.Selected.ForeColor = System.Drawing.Color.White;
            this.filterTileControl.AppearanceItem.Selected.Options.UseBackColor = true;
            this.filterTileControl.AppearanceItem.Selected.Options.UseBorderColor = true;
            this.filterTileControl.AppearanceItem.Selected.Options.UseFont = true;
            this.filterTileControl.AppearanceItem.Selected.Options.UseForeColor = true;
            
            
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "BursFilterView";
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}

