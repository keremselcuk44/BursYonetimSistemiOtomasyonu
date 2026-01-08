using System.Collections.Generic;
using System.Linq;
using DevExpress.Mvvm;
using OgrenciBursOtomasyonu.Desktop.Common.ViewModel;
using OgrenciBursOtomasyonu.Desktop.Common.DataModel;

namespace OgrenciBursOtomasyonu.Desktop.ViewModels
{
    partial class OgrenciBursDbViewModel
    {
        public const string DashboardViewDocumentType = "DashboardView";
        public const string OgrenciCollectionViewDocumentType = "OgrenciCollectionView";
        public const string BursCollectionViewDocumentType = "BursCollectionView";
        public const string KullaniciIslemleriViewDocumentType = "KullaniciIslemleriView";

        public override OgrenciBursModuleDescription DefaultModule
        {
            get { return Modules.Where(m => m.DocumentType == DashboardViewDocumentType).First(); }
        }

        public IList<IGrouping<string, OgrenciBursModuleDescription>> ModuleGroups
        {
            get { return Modules.GroupBy(m => m.ModuleGroup).ToList(); }
        }

        protected override void DocumentShown(OgrenciBursModuleDescription module, IDocument document)
        {
            base.DocumentShown(module, document);
            if (module == null)
                return;

            // Notify views that a module/document became active.
            // (Used for refresh-on-show scenarios; not limited to filtered modules.)
            Messenger.Default.Send<DocumentShownMessage>(new DocumentShownMessage(module.DocumentType));

            if (module.FilterViewModel != null)
            {
                module.FilterViewModel.SetViewModel(document.Content);
            }
        }

        public void Info()
        {
            // TODO: Implement info dialog
        }

        public void About()
        {
            DevExpress.Utils.About.AboutHelper.Show(DevExpress.Utils.About.ProductKind.DXperienceWin);
        }

        public void Exit()
        {
            Program.MainForm.Close();
        }
    }
}

