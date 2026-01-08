using System;
using DevExpress.Data.Filtering;

namespace OgrenciBursOtomasyonu.Desktop.ViewModels
{
    /// <summary>
    /// Özel filtre view model'i. Entity tipi için filtre kriterleri ve filtre adı yönetir.
    /// </summary>
    public class CustomFilterViewModel
    {
        /// <summary>
        /// Yeni bir CustomFilterViewModel instance'ı oluşturur.
        /// </summary>
        /// <param name="entityType">Filtre uygulanacak entity tipi</param>
        /// <returns>Yeni CustomFilterViewModel instance'ı</returns>
        public static CustomFilterViewModel Create(Type entityType)
        {
            return new CustomFilterViewModel(entityType);
        }

        protected CustomFilterViewModel(Type entityType)
        {
            EntityType = entityType;
        }

        /// <summary>
        /// Filtre uygulanacak entity tipi.
        /// </summary>
        public virtual Type EntityType { get; protected set; }

        /// <summary>
        /// Filtrenin kaydedilip kaydedilmeyeceği.
        /// </summary>
        public virtual bool Save { get; set; }

        /// <summary>
        /// Filtre kriterleri (CriteriaOperator).
        /// </summary>
        public virtual CriteriaOperator FilterCriteria { get; set; }

        /// <summary>
        /// Filtre adı.
        /// </summary>
        public virtual string FilterName { get; set; }
    }
}

