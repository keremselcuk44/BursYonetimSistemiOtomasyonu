using Microsoft.EntityFrameworkCore;

namespace OgrenciBursOtomasyonu.Api.Data
{
    /// <summary>
    /// Unit of Work Factory pattern. UnitOfWork instance'ları oluşturmak için kullanılır.
    /// </summary>
    public static class UnitOfWorkSource
    {
        /// <summary>
        /// ApplicationDbContext kullanarak yeni bir UnitOfWork instance'ı oluşturur.
        /// </summary>
        /// <param name="context">DbContext instance'ı</param>
        /// <returns>Yeni oluşturulmuş UnitOfWork instance'ı</returns>
        public static IUnitOfWork GetUnitOfWork(ApplicationDbContext context)
        {
            return new UnitOfWork(context);
        }

        /// <summary>
        /// DbContextOptions kullanarak yeni bir UnitOfWork instance'ı oluşturur.
        /// </summary>
        /// <param name="options">DbContextOptions instance'ı</param>
        /// <returns>Yeni oluşturulmuş UnitOfWork instance'ı</returns>
        public static IUnitOfWork GetUnitOfWork(DbContextOptions<ApplicationDbContext> options)
        {
            var context = new ApplicationDbContext(options);
            return new UnitOfWork(context);
        }

        /// <summary>
        /// Connection string kullanarak yeni bir UnitOfWork instance'ı oluşturur.
        /// </summary>
        /// <param name="connectionString">Veritabanı bağlantı dizisi</param>
        /// <returns>Yeni oluşturulmuş UnitOfWork instance'ı</returns>
        public static IUnitOfWork GetUnitOfWork(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            var context = new ApplicationDbContext(optionsBuilder.Options);
            return new UnitOfWork(context);
        }
    }
}

