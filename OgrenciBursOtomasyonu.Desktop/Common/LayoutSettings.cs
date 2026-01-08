using System.Configuration;

namespace OgrenciBursOtomasyonu.Desktop.Common
{
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class LayoutSettings : ApplicationSettingsBase
    {
        private static LayoutSettings defaultInstance = ((LayoutSettings)(ApplicationSettingsBase.Synchronized(new LayoutSettings())));

        public static LayoutSettings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [UserScopedSettingAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [DefaultSettingValueAttribute("")]
        public string LogicalLayout
        {
            get
            {
                return ((string)(this["LogicalLayout"]));
            }
            set
            {
                this["LogicalLayout"] = value;
            }
        }

        [UserScopedSettingAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [DefaultSettingValueAttribute("")]
        public string ViewsLayout
        {
            get
            {
                return ((string)(this["ViewsLayout"]));
            }
            set
            {
                this["ViewsLayout"] = value;
            }
        }
    }
}

