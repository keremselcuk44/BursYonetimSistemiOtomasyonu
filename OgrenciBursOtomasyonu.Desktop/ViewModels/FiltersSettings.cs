using System;

namespace OgrenciBursOtomasyonu.Desktop.ViewModels
{
    /// <summary>
    /// Filtre ayarları static sınıfı. Farklı entity'ler için filtre view model'leri oluşturur.
    /// </summary>
    public static class FiltersSettings
    {
        // Not: DevExpress.Mvvm paketi projede olmadığı için ViewModelSource ve Messenger kullanılamıyor.
        // Bu metodlar şimdilik yorum satırında. DevExpress.Mvvm paketi eklendiğinde aktif edilebilir.
        
        /*
        public static EmployeeTaskFilterViewModel GetTaskFilter(object parentViewModel)
        {
            return ViewModelSource.Create<EmployeeTaskFilterViewModel>().SetParentViewModel(parentViewModel);
        }

        public static EmployeesFilterViewModel GetEmployeeFilter(object parentViewModel)
        {
            return ViewModelSource.Create<EmployeesFilterViewModel>().SetParentViewModel(parentViewModel);
        }

        public static ProductFilterViewModel GetProductFilter(object parentViewModel)
        {
            return ViewModelSource.Create<ProductFilterViewModel>().SetParentViewModel(parentViewModel);
        }

        public static CustomerFilterViewModel GetCustomerFilter(object parentViewModel)
        {
            return ViewModelSource.Create<CustomerFilterViewModel>().SetParentViewModel(parentViewModel);
        }

        public static void RegisterEntityChangedMessageHandler<TEntity, TPrimaryKey>(object recipient, Action handler)
        {
            Messenger.Default.Register<EntityMessage<TEntity, TPrimaryKey>>(recipient, message => handler());
        }
        */
        
        // Geçici olarak, projeye özgü filtre metodları eklenebilir:
        // Örnek:
        // public static OgrenciFilterViewModel GetOgrenciFilter(object parentViewModel)
        // {
        //     return new OgrenciFilterViewModel(parentViewModel);
        // }
    }
}

