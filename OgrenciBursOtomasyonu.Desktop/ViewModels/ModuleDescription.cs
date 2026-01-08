using System;
using OgrenciBursOtomasyonu.Desktop.ViewModels;

namespace OgrenciBursOtomasyonu.Desktop.ViewModels
{
    /// <summary>
    /// Module description class (demo-style structure).
    /// Represents a navigation module in the application.
    /// </summary>
    public class ModuleDescription
    {
        public string ModuleTitle { get; set; }
        public string DocumentType { get; set; }
        public string ModuleGroup { get; set; }
        public FilterViewModelBase FilterViewModel { get; set; }
        public object Tag { get; set; } // For storing additional data (like TileBarItem)

        public ModuleDescription(string title, string documentType, string group, FilterViewModelBase filterViewModel = null)
        {
            ModuleTitle = title;
            DocumentType = documentType;
            ModuleGroup = group;
            FilterViewModel = filterViewModel;
        }
    }
}

