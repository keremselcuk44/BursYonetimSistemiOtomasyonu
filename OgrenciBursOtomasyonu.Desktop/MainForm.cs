using System;
using System.Drawing;
using System.Linq;
using DevExpress.Utils.MVVM;
using DevExpress.Utils.Taskbar;
using DevExpress.Utils.Taskbar.Core;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using OgrenciBursOtomasyonu.Desktop.Views.Common;
using OgrenciBursOtomasyonu.Desktop.ViewModels;

namespace OgrenciBursOtomasyonu.Desktop
{
    public partial class MainForm : XtraForm
    {
        static MainForm()
        {
            MVVMContext.RegisterFlyoutDialogService();
        }
        public MainForm()
        {
            TaskbarHelper.InitDemoJumpList(TaskbarAssistant.Default, this);
            // Splash screen - skip if logo not available
            // TODO: Add logo resource if needed
            // SplashScreenManager.ShowSkinSplashScreen(Properties.Resources.DevExpress_Logo, title: "Öğrenci Burs Otomasyonu", subtitle: "DevExpress WinForms Controls");
            InitializeComponent();
            
            navButtonHome.Glyph = WindowExtensions.GetImage("navButtonHome");
            navButtonInfo.Glyph = WindowExtensions.GetImage("navButtonInfo");
            navButtonHelp.Glyph = WindowExtensions.GetImage("navButtonHelp");
            navButtonClose.Glyph = WindowExtensions.GetImage("navButtonClose");
            
            if(!mvvmContext.IsDesignMode)
                InitializeNavigation();
        }
        protected override FormShowMode ShowMode
        {
            get { return FormShowMode.AfterInitialization; }
        }
        protected override void OnShown(EventArgs e)
        {
            SplashScreenManager.CloseForm(false);
            base.OnShown(e);
        }
        void InitializeNavigation()
        {
            mvvmContext.RegisterService(DevExpress.Utils.MVVM.Services.DocumentManagerService.Create(navigationFrame));
            mvvmContext.RegisterService("FilterDialogService", DevExpress.Utils.MVVM.Services.DialogService.CreateFlyoutDialogService(this));
            
            var fluentAPI = mvvmContext.OfType<OgrenciBursDbViewModel>();
            fluentAPI.SetItemsSourceBinding(tileBar,
                tb => tb.Groups, x => x.ModuleGroups,
                (group, moduleGroup) => object.Equals(group.Tag, moduleGroup),
                moduleGroup => CreateGroup(fluentAPI, moduleGroup)
            );
            fluentAPI.WithEvent(this, "Load")
                .EventToCommand(x => x.OnLoaded(null), x => x.DefaultModule);
            fluentAPI.WithEvent(this, "Closing")
                .EventToCommand(x => x.OnClosing(null));
            
            fluentAPI.BindCommand(navButtonInfo, x => x.Info());
            fluentAPI.BindCommand(navButtonHelp, x => x.About());
            fluentAPI.BindCommand(navButtonClose, x => x.Exit());
            
            tileBar.SelectedItem = GetItem(fluentAPI.ViewModel.DefaultModule);
        }
        public void ShowTileNavPane()
        {
            tileNavPane.Visible = true;
        }
        TileBarItem GetItem(OgrenciBursModuleDescription defaultModule)
        {
            foreach(TileBarGroup gr in tileBar.Groups)
            {
                var item = gr.Items.FirstOrDefault(x => x.Tag == defaultModule) as TileBarItem;
                if(item != null) return item;
            }
            return null;
        }
        TileBarGroup CreateGroup(MVVMContextFluentAPI<OgrenciBursDbViewModel> fluentAPI, System.Linq.IGrouping<string, OgrenciBursModuleDescription> moduleGroup)
        {
            TileBarGroup group = new TileBarGroup() { Tag = moduleGroup };
            group.Text = moduleGroup.Key.ToUpper();
            foreach(OgrenciBursModuleDescription module in moduleGroup)
                group.Items.Add(RegisterModuleItem(fluentAPI, module));
            return group;
        }
        TileBarItem RegisterModuleItem(MVVMContextFluentAPI<OgrenciBursDbViewModel> fluentAPI, OgrenciBursModuleDescription module)
        {
            TileBarItem item = new TileBarItem() { Tag = module };
            item.Text = module.ModuleTitle;
            item.Elements[0].ImageUri = MenuExtensions.GetImageUri(module.ModuleTitle);
            item.AppearanceItem.Normal.BackColor = TileColorConverter.GetBackColor(module);
            item.ItemSize = TileBarItemSize.Wide;
            if(module.FilterViewModel != null)
                {
                item.ShowDropDownButton = (module.FilterViewModel.CustomFilters.Count() > 0) ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
                item.DropDownControl = CreateFiltersContainer(module.FilterViewModel);
                item.DropDownOptions.BackColorMode = BackColorMode.UseTileBackColor;
            }
            fluentAPI.BindCommand(item, x => x.Show(null), x => module);
            return item;
            }
        TileBarDropDownContainer CreateFiltersContainer(FilterViewModelBase filterViewModel)
        {
            var filtersContainer = new TileBarDropDownContainer();
            BaseCustomFilterView filterBarView = new BaseCustomFilterView();
            filterBarView.SetViewModel(filterViewModel);
            filtersContainer.Controls.Add(filterBarView);
            return filtersContainer;
        }
        #region TileColorConverter
        static class TileColorConverter
        {
            public static Color GetBackColor(OgrenciBursModuleDescription module)
            {
                switch(module.DocumentType)
        {
                    case OgrenciBursDbViewModel.DashboardViewDocumentType:
                        return Color.FromArgb(0x00, 0x87, 0x9C);
                    case OgrenciBursDbViewModel.OgrenciCollectionViewDocumentType:
                        return Color.FromArgb(0xCC, 0x6D, 0x00);
                    case OgrenciBursDbViewModel.BursCollectionViewDocumentType:
                        return Color.FromArgb(0x00, 0x73, 0xC4);
                    default:
                        return Color.FromArgb(0x40, 0x40, 0x40);
            }
        }
        }
        #endregion
    }
}
