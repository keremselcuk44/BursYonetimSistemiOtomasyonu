using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;

namespace OgrenciBursOtomasyonu.Desktop.ViewModels
{
    /// <summary>
    /// Filtre model sayfa özel ayarları interface'i.
    /// </summary>
    public interface IFilterModelPageSpecificSettings
    {
        /// <summary>
        /// Statik filtreler listesi.
        /// </summary>
        FilterInfoList StaticFilters { get; set; }

        /// <summary>
        /// Özel filtreler listesi.
        /// </summary>
        FilterInfoList CustomFilters { get; set; }

        /// <summary>
        /// Uygulama ayarları.
        /// </summary>
        ApplicationSettingsBase Settings { get; }

        /// <summary>
        /// Ayarları kaydet.
        /// </summary>
        void SaveSettings();
    }

    /// <summary>
    /// Filtre bilgisi sınıfı.
    /// </summary>
    public class FilterInfo
    {
        /// <summary>
        /// Filtre adı.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Filtre kriterleri (string olarak).
        /// </summary>
        public string FilterCriteria { get; set; }

        /// <summary>
        /// Filtre görsel URI'si.
        /// </summary>
        public string ImageUri { get; set; }
    }

    /// <summary>
    /// Filtre bilgisi listesi.
    /// </summary>
    public class FilterInfoList : List<FilterInfo>
    {
        /// <summary>
        /// Yeni bir FilterInfoList instance'ı oluşturur.
        /// </summary>
        public FilterInfoList()
        {
        }

        /// <summary>
        /// Filtre koleksiyonundan yeni bir FilterInfoList instance'ı oluşturur.
        /// </summary>
        /// <param name="filters">Filtre koleksiyonu</param>
        public FilterInfoList(IEnumerable<FilterInfo> filters)
            : base(filters)
        {
        }
    }

    /// <summary>
    /// Filtre model sayfa özel ayarları generic sınıfı.
    /// </summary>
    /// <typeparam name="TSettings">Ayarlar tipi (ApplicationSettingsBase'den türemeli)</typeparam>
    public class FilterModelPageSpecificSettings<TSettings> : IFilterModelPageSpecificSettings where TSettings : ApplicationSettingsBase
    {
        private readonly TSettings _settings;
        private readonly PropertyDescriptor _staticFiltersProperty;
        private readonly PropertyDescriptor _customFiltersProperty;

        static FilterModelPageSpecificSettings()
        {
            // Enum'ları kaydet (ihtiyaç varsa)
            // Not: EnumProcessingHelper DevExpress'ten geliyor, projede yoksa bu kısım kaldırılabilir
            // var enums = typeof(EmployeeStatus).Assembly.GetTypes().Where(t => t.IsEnum);
            // foreach (Type e in enums) EnumProcessingHelper.RegisterEnum(e);
        }

        /// <summary>
        /// Yeni bir FilterModelPageSpecificSettings instance'ı oluşturur.
        /// </summary>
        /// <param name="settings">Ayarlar instance'ı</param>
        /// <param name="getStaticFiltersExpression">Statik filtreler property'si expression'ı</param>
        /// <param name="getCustomFiltersExpression">Özel filtreler property'si expression'ı</param>
        public FilterModelPageSpecificSettings(
            TSettings settings,
            Expression<Func<TSettings, FilterInfoList>> getStaticFiltersExpression,
            Expression<Func<TSettings, FilterInfoList>> getCustomFiltersExpression)
        {
            _settings = settings;
            _staticFiltersProperty = GetProperty(getStaticFiltersExpression);
            _customFiltersProperty = GetProperty(getCustomFiltersExpression);
        }

        /// <summary>
        /// Statik filtreler listesi.
        /// </summary>
        FilterInfoList IFilterModelPageSpecificSettings.StaticFilters
        {
            get { return GetFilters(_staticFiltersProperty); }
            set { SetFilters(_staticFiltersProperty, value); }
        }

        /// <summary>
        /// Özel filtreler listesi.
        /// </summary>
        FilterInfoList IFilterModelPageSpecificSettings.CustomFilters
        {
            get { return GetFilters(_customFiltersProperty); }
            set { SetFilters(_customFiltersProperty, value); }
        }

        /// <summary>
        /// Uygulama ayarları.
        /// </summary>
        ApplicationSettingsBase IFilterModelPageSpecificSettings.Settings
        {
            get { return _settings; }
        }

        /// <summary>
        /// Expression'dan PropertyDescriptor alır.
        /// </summary>
        private PropertyDescriptor GetProperty(Expression<Func<TSettings, FilterInfoList>> expression)
        {
            return (expression != null) ? TypeDescriptor.GetProperties(_settings)[GetPropertyName(expression)] : null;
        }

        /// <summary>
        /// Property'den FilterInfoList alır.
        /// </summary>
        private FilterInfoList GetFilters(PropertyDescriptor property)
        {
            return (property != null) ? (FilterInfoList)property.GetValue(_settings) : null;
        }

        /// <summary>
        /// Property'ye FilterInfoList set eder.
        /// </summary>
        private void SetFilters(PropertyDescriptor property, FilterInfoList value)
        {
            if (property != null) property.SetValue(_settings, value);
        }

        /// <summary>
        /// Expression'dan property adını alır.
        /// </summary>
        private static string GetPropertyName(Expression<Func<TSettings, FilterInfoList>> expression)
        {
            MemberExpression memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("expression");
            return memberExpression.Member.Name;
        }

        /// <summary>
        /// Ayarları kaydet.
        /// </summary>
        public void SaveSettings()
        {
            _settings.Save();
        }
    }
}

