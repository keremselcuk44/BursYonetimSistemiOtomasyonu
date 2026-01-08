using System;

namespace OgrenciBursOtomasyonu.Desktop.Services
{
    /// <summary>
    /// Rapor interface'i. DevExpress XtraReports için temel rapor arayüzü.
    /// Not: DevExpress.XtraReports paketi eklendiğinde IReport yerine DevExpress.XtraReports.IReport kullanılabilir.
    /// </summary>
    public interface IReport
    {
    }

    /// <summary>
    /// Rapor bilgisi interface'i. Rapor parametrelerini ve rapor oluşturma işlevini tanımlar.
    /// </summary>
    public interface IReportInfo
    {
        /// <summary>
        /// Rapor parametreleri view model'i.
        /// </summary>
        object ParametersViewModel { get; }

        /// <summary>
        /// Rapor oluşturur.
        /// </summary>
        /// <returns>Oluşturulmuş rapor</returns>
        IReport CreateReport();
    }

    /// <summary>
    /// Generic rapor bilgisi sınıfı. Belirli bir parametre view model tipi için rapor oluşturur.
    /// </summary>
    /// <typeparam name="TParametersViewModel">Parametre view model tipi</typeparam>
    public class ReportInfo<TParametersViewModel> : IReportInfo
    {
        private readonly TParametersViewModel _parametersViewModel;
        private readonly Func<TParametersViewModel, IReport> _reportFactory;

        /// <summary>
        /// Yeni bir ReportInfo instance'ı oluşturur.
        /// </summary>
        /// <param name="parametersViewModel">Rapor parametreleri view model'i</param>
        /// <param name="reportFactory">Rapor oluşturma fonksiyonu</param>
        public ReportInfo(TParametersViewModel parametersViewModel, Func<TParametersViewModel, IReport> reportFactory)
        {
            _parametersViewModel = parametersViewModel;
            _reportFactory = reportFactory;
        }

        /// <summary>
        /// Rapor parametreleri view model'i.
        /// </summary>
        object IReportInfo.ParametersViewModel
        {
            get { return _parametersViewModel!; }
        }

        /// <summary>
        /// Rapor oluşturur.
        /// </summary>
        /// <returns>Oluşturulmuş rapor</returns>
        IReport IReportInfo.CreateReport()
        {
            return _reportFactory(_parametersViewModel);
        }
    }
}

