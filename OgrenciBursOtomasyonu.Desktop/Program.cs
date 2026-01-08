using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Internal;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using OgrenciBursOtomasyonu.Desktop.Common.Utils;

namespace OgrenciBursOtomasyonu.Desktop {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            // CRITICAL: These must be called BEFORE any form is created
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.AssemblyResolve += OnCurrentDomainAssemblyResolve;
            
            // DevExpress settings - must be before any form creation
            if(!SystemInformation.TerminalServerSession && Screen.AllScreens.Length > 1)
                DevExpress.XtraEditors.WindowsFormsSettings.SetPerMonitorDpiAware();
            else
                DevExpress.XtraEditors.WindowsFormsSettings.SetDPIAware();
            DevExpress.XtraEditors.WindowsFormsSettings.UseUIAutomation = DevExpress.Utils.DefaultBoolean.True;
            DevExpress.XtraEditors.WindowsFormsSettings.EnableFormSkins();
            DevExpress.XtraEditors.WindowsFormsSettings.ForceDirectXPaint();
            DevExpress.XtraEditors.WindowsFormsSettings.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            DevExpress.XtraEditors.WindowsFormsSettings.ScrollUIMode = DevExpress.XtraEditors.ScrollUIMode.Touch;
            
            float fontSize = 11f;
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Segoe UI", fontSize);
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultMenuFont = new Font("Segoe UI", fontSize);
            
            Application.CurrentCulture = CultureInfo.GetCultureInfo("tr-TR"); // Turkish culture preserved
            
            // Preserve login flow - show login form first
            using (var girisFormu = new FrmGiris()) {
            var sonuc = girisFormu.ShowDialog();
                if (sonuc != DialogResult.OK || !UserSession.GirisYapildi) {
                    return; // Exit if login failed
                }
            }
            
            MainForm = new MainForm() { Icon = AppIcon };
            if(Program.IsTablet)
                    SetupAsTablet();
                Application.Run(MainForm);
            }
        static Assembly OnCurrentDomainAssemblyResolve(object sender, ResolveEventArgs args) {
            string partialName = DevExpress.Utils.AssemblyHelper.GetPartialName(args.Name).ToLower();
            if(partialName == "entityframework" || partialName == "system.data.sqlite" || partialName == "system.data.sqlite.ef6") {
                string path = Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), "..\\..\\bin", partialName + ".dll");
                return DevExpress.Data.Internal.SafeTypeResolver.GetOrLoadAssemblyFrom(path);
            }
            return null;
        }
        
        static bool? isTablet = null;
        public static bool IsTablet {
            get {
                if(isTablet == null) {
                    isTablet = DeviceDetector.IsTablet;
                }
                return isTablet.Value;
            }
        }
        public static Icon AppIcon {
            get { 
                // Try to load from Resources, fallback to null
                try {
                    return DevExpress.Utils.ResourceImageHelper.CreateIconFromResourcesEx("OgrenciBursOtomasyonu.Desktop.Resources.AppIcon.ico", typeof(MainForm).Assembly);
                } catch {
                    return null;
                }
            }
        }
        public static MainForm MainForm {
            get;
            private set;
        }
        public static void SetupAsTablet() {
                MainForm.ShowTileNavPane();
                MainForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                MainForm.WindowState = FormWindowState.Maximized;
            DevExpress.XtraEditors.WindowsFormsSettings.PopupMenuStyle = DevExpress.XtraEditors.Controls.PopupMenuStyle.RadialMenu;
            DevExpress.Utils.TouchHelpers.TouchKeyboardSupport.EnableTouchKeyboard = true;
        }
    }
}
