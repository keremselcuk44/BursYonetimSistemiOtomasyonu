using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Filtering;

namespace OgrenciBursOtomasyonu.Desktop.ViewModels
{
    /// <summary>
    /// Filtre view model base sınıfı.
    /// </summary>
    public abstract class FilterViewModelBase
    {
        /// <summary>
        /// Navigate action.
        /// </summary>
        public Action NavigateAction { get; set; }

        protected readonly IFilterModelPageSpecificSettings settings;

        /// <summary>
        /// Yeni bir FilterViewModelBase instance'ı oluşturur.
        /// </summary>
        /// <param name="settings">Filtre model ayarları</param>
        public FilterViewModelBase(IFilterModelPageSpecificSettings settings)
        {
            this.settings = settings;
            Init();
        }

        /// <summary>
        /// İlk başlatma yapar.
        /// </summary>
        protected virtual void Init()
        {
            StaticFilters = CreateFilterItems(settings.StaticFilters);
            CustomFilters = CreateFilterItems(settings.CustomFilters);
        }

        /// <summary>
        /// Statik filtreler.
        /// </summary>
        public virtual IList<FilterItem> StaticFilters { get; protected set; }

        /// <summary>
        /// Özel filtreler.
        /// </summary>
        public virtual IList<FilterItem> CustomFilters { get; protected set; }

        /// <summary>
        /// Statik filtreler değiştiğinde çağrılır.
        /// </summary>
        protected virtual void OnStaticFiltersChanged()
        {
            SelectedItem = StaticFilters.FirstOrDefault();
        }

        /// <summary>
        /// Seçili filtre öğesi.
        /// </summary>
        public virtual FilterItem SelectedItem { get; set; }

        /// <summary>
        /// Aktif filtre öğesi.
        /// </summary>
        public virtual FilterItem ActiveFilterItem { get; set; }

        /// <summary>
        /// Seçili öğe değiştiğinde çağrılır.
        /// </summary>
        protected virtual void OnSelectedItemChanged()
        {
        }

        /// <summary>
        /// Filtre ifadesini günceller.
        /// </summary>
        protected virtual void UpdateFilterExpression()
        {
        }

        /// <summary>
        /// FilterInfo koleksiyonundan FilterItem listesi oluşturur.
        /// </summary>
        protected List<FilterItem> CreateFilterItems(IEnumerable<FilterInfo> filterInfos)
        {
            var infos = filterInfos ?? new List<FilterInfo>();
            return new List<FilterItem>(infos.Select(x => CreateFilterItem(x.Name, CriteriaOperator.Parse(x.FilterCriteria), x.ImageUri)));
        }

        /// <summary>
        /// Filtre öğesi oluşturur.
        /// </summary>
        protected virtual FilterItem CreateFilterItem(string name, CriteriaOperator filterCriteria, string imageUri)
        {
            return FilterItem.Create(name, filterCriteria, imageUri);
        }

        /// <summary>
        /// Filtreleri ayarlara kaydeder.
        /// </summary>
        protected FilterInfoList SaveToSettings(List<FilterItem> filters)
        {
            return new FilterInfoList(filters.Select(fi => new FilterInfo 
            { 
                Name = fi.Name, 
                FilterCriteria = !object.ReferenceEquals(fi.FilterCriteria, null) ? CriteriaOperator.ToString(fi.FilterCriteria) : string.Empty,
                ImageUri = fi.ImageUri 
            }));
        }

        #region Filter Item ViewModel

        /// <summary>
        /// Filtre öğesi sınıfı.
        /// </summary>
        public class FilterItem
        {
            /// <summary>
            /// Yeni bir FilterItem instance'ı oluşturur.
            /// </summary>
            /// <param name="name">Filtre adı</param>
            /// <param name="filterCriteria">Filtre kriterleri</param>
            /// <param name="imageUri">Görsel URI</param>
            protected FilterItem(string name, CriteriaOperator filterCriteria, string imageUri)
            {
                this.Name = name;
                this.FilterCriteria = filterCriteria;
                this.ImageUri = imageUri;
            }

            /// <summary>
            /// Filtre adı.
            /// </summary>
            public virtual string Name { get; set; }

            /// <summary>
            /// Filtre kriterleri.
            /// </summary>
            public virtual CriteriaOperator FilterCriteria { get; set; }

            /// <summary>
            /// Görsel URI.
            /// </summary>
            public virtual string ImageUri { get; set; }

            /// <summary>
            /// Entity sayısı.
            /// </summary>
            public virtual int Count { get; set; }

            /// <summary>
            /// Yeni bir FilterItem instance'ı oluşturur.
            /// </summary>
            /// <param name="name">Filtre adı</param>
            /// <param name="filterCriteria">Filtre kriterleri</param>
            /// <param name="imageUri">Görsel URI</param>
            /// <returns>Yeni FilterItem instance'ı</returns>
            public static FilterItem Create(string name, CriteriaOperator filterCriteria, string imageUri)
            {
                // Not: DevExpress.Mvvm paketi olmadığı için ViewModelSource.Create kullanılamıyor
                // return ViewModelSource.Create(() => new FilterItem(name, filterCriteria, imageUri));
                return new FilterItem(name, filterCriteria, imageUri);
            }

            /// <summary>
            /// Filtre öğesini klonlar.
            /// </summary>
            /// <returns>Klonlanmış FilterItem</returns>
            public FilterItem Clone()
            {
                FilterItem item = FilterItem.Create(Name, FilterCriteria, ImageUri);
                item.Count = this.Count;
                return item;
            }
        }

        #endregion Filter Item ViewModel

        /// <summary>
        /// View model set edilir.
        /// </summary>
        /// <param name="viewModel">View model</param>
        public virtual void SetViewModel(object viewModel)
        {
        }
    }
}
