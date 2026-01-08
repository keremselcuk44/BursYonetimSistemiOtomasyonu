using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.UI;
using OgrenciBursOtomasyonu.Desktop.Common.DataModel;
using OgrenciBursOtomasyonu.Desktop.Common.ViewModel;
using OgrenciBursOtomasyonu.Desktop.ViewModels;
using OgrenciBursOtomasyonu.Desktop.Views.Dashboard;
using OgrenciBursOtomasyonu.Desktop.Views.Ogrenci;
using OgrenciBursOtomasyonu.Desktop.Views.Burs;

namespace OgrenciBursOtomasyonu.Desktop.ViewModels
{
    /// <summary>
    /// Represents the root POCO view model for the OgrenciBurs data model.
    /// </summary>
    public partial class OgrenciBursDbViewModel : DocumentsViewModel<OgrenciBursModuleDescription, IUnitOfWork>
    {
        const string MyWorldGroup = "Burs Yönetim Sistemi";
        const string OperationsGroup = "Burs Yönetim Sistemi";

        /// <summary>
        /// Creates a new instance of OgrenciBursDbViewModel as a POCO view model.
        /// </summary>
        public static OgrenciBursDbViewModel Create()
        {
            return ViewModelSource.Create(() => new OgrenciBursDbViewModel());
        }

        /// <summary>
        /// Initializes a new instance of the OgrenciBursDbViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the OgrenciBursDbViewModel type without the POCO proxy factory.
        /// </summary>
        protected OgrenciBursDbViewModel()
            : base(UnitOfWorkSource.GetUnitOfWorkFactory())
        {
        }

        protected override OgrenciBursModuleDescription[] CreateModules()
        {
            OgrenciBursModuleDescription[] modules = new OgrenciBursModuleDescription[] {
                new OgrenciBursModuleDescription("Ana Sayfa", DashboardViewDocumentType, MyWorldGroup, (FilterViewModelBase)null),
                new OgrenciBursModuleDescription("Öğrenciler", OgrenciCollectionViewDocumentType, MyWorldGroup, (FilterViewModelBase)null),
                new OgrenciBursModuleDescription("Burslar", BursCollectionViewDocumentType, OperationsGroup, (FilterViewModelBase)null),
                new OgrenciBursModuleDescription("Kullanıcı İşlemleri", KullaniciIslemleriViewDocumentType, OperationsGroup, (FilterViewModelBase)null),
            };
            foreach (var module in modules)
            {
                if (module.FilterViewModel == null)
                    continue;
                OgrenciBursModuleDescription moduleRef = module;
                module.FilterViewModel.NavigateAction = (() =>
                {
                    if (this.ActiveModule != moduleRef)
                        Show(moduleRef);
                });
            }
            return modules;
        }

        protected override IDocument CreateDocument(OgrenciBursModuleDescription module)
        {
            // Use base implementation which lets DocumentManagerService manage view creation
            // This ensures FindDocumentByIdOrCreate reuses existing views in NavigationFrame
            return base.CreateDocument(module);
        }
    }

    public partial class OgrenciBursModuleDescription : ModuleDescription<OgrenciBursModuleDescription>
    {
        public OgrenciBursModuleDescription(string title, string documentType, string group, Func<OgrenciBursModuleDescription, object> peekCollectionViewModelFactory = null)
            : base(title, documentType, group, peekCollectionViewModelFactory)
        {
        }

        public OgrenciBursModuleDescription(string title, string documentType, string group, FilterViewModelBase filterViewModel)
            : base(title, documentType, group)
        {
            FilterViewModel = filterViewModel;
        }

        public FilterViewModelBase FilterViewModel { get; private set; }
    }
}

