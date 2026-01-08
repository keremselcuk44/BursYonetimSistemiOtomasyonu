using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using DevExpress.Data.Filtering;

namespace OgrenciBursOtomasyonu.Desktop.ViewModels
{
    /// <summary>
    /// Generic filtre view model base sınıfı.
    /// </summary>
    /// <typeparam name="TEntity">Entity tipi</typeparam>
    /// <typeparam name="TProjection">Projection tipi</typeparam>
    public abstract class FilterViewModel<TEntity, TProjection> : FilterViewModelBase
        where TEntity : class
        where TProjection : class
    {
        private object viewModel;

        /// <summary>
        /// Yeni bir FilterViewModel instance'ı oluşturur.
        /// </summary>
        /// <param name="settings">Filtre model ayarları</param>
        /// <param name="registerEntityChangedMessageHandler">Entity değişikliği mesaj handler'ı kaydetme aksiyonu</param>
        protected FilterViewModel(IFilterModelPageSpecificSettings settings, Action<object, Action> registerEntityChangedMessageHandler)
            : base(settings)
        {
            // Not: DevExpress.Mvvm paketi olmadığı için Messenger kullanılamıyor
            // registerEntityChangedMessageHandler(this, () => UpdateFilters());
            // Messenger.Default.Register<CreateCustomFilterMessage<TEntity>>(this, message => CreateCustomFilter());
        }

        /// <summary>
        /// Collection view model (projeye özgü implementasyon gerekli).
        /// </summary>
        // protected ReadOnlyCollectionViewModel<TEntity, TProjection, IUnitOfWork> CollectionViewModel
        // {
        //     get { return (ReadOnlyCollectionViewModel<TEntity, TProjection, IUnitOfWork>)viewModel; }
        // }

        /// <summary>
        /// Seçili öğe değiştiğinde çağrılır.
        /// </summary>
        protected override void OnSelectedItemChanged()
        {
            ActiveFilterItem = (SelectedItem != null) ? SelectedItem.Clone() : null;
            UpdateFilterExpression();
            if (NavigateAction != null)
                NavigateAction();
        }

        /// <summary>
        /// Filtre ifadesini günceller.
        /// </summary>
        protected override void UpdateFilterExpression()
        {
            // Not: CollectionViewModel implementasyonu gerekli
            // if (CollectionViewModel != null)
            // {
            //     var criteria = GetSelectedCriteria();
            //     if (!object.ReferenceEquals(criteria, null))
            //         CollectionViewModel.FilterExpression = GetFilterExpression(criteria);
            //     else
            //         CollectionViewModel.FilterExpression = null;
            // }
        }

        /// <summary>
        /// View model set edilir.
        /// </summary>
        public override void SetViewModel(object viewModel)
        {
            this.viewModel = viewModel;
            var viewModelContainer = viewModel as IFilterTreeViewModelContainer<TEntity, TProjection>;
            if (viewModelContainer != null)
                viewModelContainer.FilterViewModel = this;
            UpdateFilters();
            UpdateFilterExpression();
        }

        /// <summary>
        /// Filtreleri günceller.
        /// </summary>
        void UpdateFilters()
        {
            // Not: CollectionViewModel implementasyonu gerekli
            // foreach (var item in StaticFilters)
            //     item.Count = GetEntityCount(item.FilterCriteria);
        }

        /// <summary>
        /// Filtre öğesi oluşturur.
        /// </summary>
        protected override FilterViewModelBase.FilterItem CreateFilterItem(string name, CriteriaOperator filterCriteria, string imageUri)
        {
            var filterItem = base.CreateFilterItem(name, filterCriteria, imageUri) as FilterItem;
            // Not: CollectionViewModel implementasyonu gerekli
            // if (CollectionViewModel != null)
            //     filterItem.Count = GetEntityCount(filterCriteria);
            return filterItem;
        }

        /// <summary>
        /// Entity sayısını alır.
        /// </summary>
        int GetEntityCount(CriteriaOperator filterCriteria)
        {
            // Not: CollectionViewModel implementasyonu gerekli
            // return CollectionViewModel.GetEntities(GetFilterExpression(filterCriteria)).Count();
            return 0;
        }

        /// <summary>
        /// Seçili kriteri alır.
        /// </summary>
        CriteriaOperator GetSelectedCriteria()
        {
            return (ActiveFilterItem != null) ? ActiveFilterItem.FilterCriteria : null;
        }

        /// <summary>
        /// Filtre ifadesini alır.
        /// </summary>
        Expression<Func<TEntity, bool>> GetFilterExpression(CriteriaOperator criteria)
        {
            // Not: CriteriaOperatorToExpressionConverter DevExpress'ten geliyor
            // return CriteriaOperatorToExpressionConverter.GetGenericWhere<TEntity>(criteria);
            throw new NotImplementedException("CriteriaOperatorToExpressionConverter implementasyonu gerekli");
        }

        /// <summary>
        /// Özel filtre oluşturur.
        /// </summary>
        public void CreateCustomFilter()
        {
            FilterItem filterItem = CreateFilterItem(string.Empty, null, null);
            var filterViewModel = CreateCustomFilterViewModel(filterItem, true);
            ShowFilter(filterItem, filterViewModel, () => AddNewCustomFilter(filterItem));
        }

        /// <summary>
        /// Özel filtre view model'i oluşturur.
        /// </summary>
        CustomFilterViewModel CreateCustomFilterViewModel(FilterItem existing, bool save)
        {
            var viewModel = CustomFilterViewModel.Create(typeof(TEntity));
            viewModel.FilterCriteria = existing.FilterCriteria;
            viewModel.FilterName = existing.Name;
            viewModel.Save = save;
            // viewModel.SetParentViewModel(this); // DevExpress.Mvvm gerekli
            return viewModel;
        }

        /// <summary>
        /// Filtre dialog'unu gösterir.
        /// </summary>
        void ShowFilter(FilterItem filterItem, CustomFilterViewModel filterViewModel, Action onSave)
        {
            // Not: IDialogService DevExpress.Mvvm'den geliyor
            // if (FilterDialogService.ShowDialog(MessageButton.OKCancel, "Create Custom Filter", DevAVDbViewModel.CustomFilterViewDocumentType, filterViewModel) != MessageResult.OK)
            //     return;
            // filterItem.FilterCriteria = filterViewModel.FilterCriteria;
            // filterItem.Name = filterViewModel.FilterName;
            // SelectedItem = filterItem;
            // if (filterViewModel.Save)
            // {
            //     onSave();
            //     UpdateFilters();
            // }
            throw new NotImplementedException("IDialogService implementasyonu gerekli");
        }

        /// <summary>
        /// Filter dialog service (DevExpress.Mvvm gerekli).
        /// </summary>
        // IDialogService FilterDialogService { get { return this.GetService<IDialogService>("FilterDialogService"); } }

        const string NewFilterName = @"New Filter";

        /// <summary>
        /// Yeni özel filtre ekler.
        /// </summary>
        void AddNewCustomFilter(FilterItem filterItem)
        {
            if (string.IsNullOrEmpty(filterItem.Name))
            {
                int prevIndex = CustomFilters.Select(fi => Regex.Match(fi.Name, NewFilterName + @" (?<index>\d+)")).Where(m => m.Success).Select(m => int.Parse(m.Groups["index"].Value)).DefaultIfEmpty(0).Max();
                filterItem.Name = NewFilterName + " " + (prevIndex + 1);
            }
            else
            {
                var existing = CustomFilters.FirstOrDefault(fi => fi.Name == filterItem.Name);
                if (existing != null)
                    CustomFilters.Remove(existing);
            }
            CustomFilters.Add(filterItem);
            SaveCustomFilters();
        }

        /// <summary>
        /// Özel filtreleri kaydeder.
        /// </summary>
        void SaveCustomFilters()
        {
            var customFiltersList = CustomFilters as List<FilterItem> ?? new List<FilterItem>(CustomFilters);
            settings.CustomFilters = SaveToSettings(customFiltersList);
            settings.SaveSettings();
        }

        /// <summary>
        /// Filtreleri ayarlara kaydeder.
        /// </summary>
        new FilterInfoList SaveToSettings(List<FilterItem> filters)
        {
            return base.SaveToSettings(filters);
        }
    }

    /// <summary>
    /// Generic filtre view model (projection olmadan).
    /// </summary>
    /// <typeparam name="TEntity">Entity tipi</typeparam>
    public abstract class FilterViewModel<TEntity> : FilterViewModel<TEntity, TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Yeni bir FilterViewModel instance'ı oluşturur.
        /// </summary>
        /// <param name="settings">Filtre model ayarları</param>
        /// <param name="registerEntityChangedMessageHandler">Entity değişikliği mesaj handler'ı kaydetme aksiyonu</param>
        protected FilterViewModel(IFilterModelPageSpecificSettings settings, Action<object, Action> registerEntityChangedMessageHandler)
            : base(settings, registerEntityChangedMessageHandler)
        {
        }
    }

    /// <summary>
    /// Filtre tree view model container interface'i.
    /// </summary>
    /// <typeparam name="TEntity">Entity tipi</typeparam>
    /// <typeparam name="TProjection">Projection tipi</typeparam>
    public interface IFilterTreeViewModelContainer<TEntity, TProjection>
        where TEntity : class
        where TProjection : class
    {
        /// <summary>
        /// Filtre view model'i.
        /// </summary>
        FilterViewModel<TEntity, TProjection> FilterViewModel { get; set; }
    }

    /// <summary>
    /// Filtre tree view model container interface'i (projection olmadan).
    /// </summary>
    /// <typeparam name="TEntity">Entity tipi</typeparam>
    public interface IFilterTreeViewModelContainer<TEntity> : IFilterTreeViewModelContainer<TEntity, TEntity>
        where TEntity : class
    {
    }

    /// <summary>
    /// Özel filtre oluşturma mesajı.
    /// </summary>
    /// <typeparam name="TEntity">Entity tipi</typeparam>
    public class CreateCustomFilterMessage<TEntity> where TEntity : class
    {
    }
}

