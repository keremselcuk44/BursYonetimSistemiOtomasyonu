using Microsoft.EntityFrameworkCore;
using OgrenciBursOtomasyonu.Api.Models;

namespace OgrenciBursOtomasyonu.Api.Data
{
    /// <summary>
    /// Entity Framework Core DbContext sınıfı.
    /// SQL Server veritabanı bağlantısını yönetir.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Burs> Burslar { get; set; }
        public DbSet<OgrenciBurs> OgrenciBurslar { get; set; }
        public DbSet<BursOdemeTakip> BursOdemeTakipleri { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ogrenci tablosu yapılandırması
            modelBuilder.Entity<Ogrenci>(entity =>
            {
                entity.ToTable("Ogrenciler");
                entity.HasKey(e => e.Id);
                // TcKimlikNo uzun girişlerde kesilmesin diye 20 karaktere çıkarıldı
                entity.Property(e => e.TcKimlikNo).HasMaxLength(20).IsRequired();
                entity.Property(e => e.Ad).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Soyad).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Universite).HasMaxLength(200);
                entity.Property(e => e.Bolum).HasMaxLength(200);
                entity.Property(e => e.Sinif).HasMaxLength(20); // Hazırlık, 1, 2, 3, 4
                entity.Property(e => e.Agno).HasPrecision(4, 2); // 0.00 - 4.00
            entity.Property(e => e.HaneGeliri).HasPrecision(18, 2);
            entity.Property(e => e.Yas);
                entity.Property(e => e.BursAlmaIhtiyaci).HasColumnType("nvarchar(max)");
                entity.Property(e => e.EgitimMasraflari).HasColumnType("nvarchar(max)");
                entity.Property(e => e.AkademikGelisim).HasColumnType("nvarchar(max)");
            entity.Property(e => e.ToplumaKatki).HasColumnType("nvarchar(max)");
            entity.Property(e => e.BesYilSonrasi).HasColumnType("nvarchar(max)");
            entity.Property(e => e.AiRaporu).HasColumnType("nvarchar(max)");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Telefon).HasMaxLength(20);
            entity.Property(e => e.Iban).HasMaxLength(34); // IBAN maksimum uzunluk 34 karakter
            entity.Property(e => e.ResimYolu).HasColumnType("nvarchar(max)"); // Base64 veya dosya yolu için
        });

            // Burs tablosu yapılandırması
            modelBuilder.Entity<Burs>(entity =>
            {
                entity.ToTable("Burslar");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.BursAdi).HasMaxLength(200).IsRequired();
                entity.Property(e => e.BursTipi).HasMaxLength(100);
                entity.Property(e => e.Aciklama).HasColumnType("nvarchar(max)");
                entity.Property(e => e.AylikTutar).HasPrecision(18, 2);
                entity.Property(e => e.OdemePeriyodu).HasMaxLength(50);
                entity.Property(e => e.BaslangicTarihi).HasColumnType("datetime2");
                entity.Property(e => e.BitisTarihi).HasColumnType("datetime2");
                entity.Property(e => e.Kosullar).HasColumnType("nvarchar(max)");
                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime2").IsRequired();
                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime2");
            });

            // OgrenciBurs tablosu yapılandırması
            modelBuilder.Entity<OgrenciBurs>(entity =>
            {
                entity.ToTable("OgrenciBurslar");
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Ogrenci)
                      .WithMany()
                      .HasForeignKey(e => e.OgrenciId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Burs)
                      .WithMany()
                      .HasForeignKey(e => e.BursId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // BursOdemeTakip tablosu yapılandırması
            modelBuilder.Entity<BursOdemeTakip>(entity =>
            {
                entity.ToTable("BursOdemeTakipleri");
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.OgrenciBurs)
                      .WithMany()
                      .HasForeignKey(e => e.OgrenciBursId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(e => new { e.OgrenciBursId, e.Ay, e.Yil }).IsUnique(); // Aynı öğrenci-burs için aynı ay-yıl tekrar edemez
            });

            // Kullanici tablosu yapılandırması
            modelBuilder.Entity<Kullanici>(entity =>
            {
                entity.ToTable("Kullanicilar");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.KullaniciAdi).HasMaxLength(50).IsRequired();
                entity.Property(e => e.SifreHash).HasMaxLength(256).IsRequired();
                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime2");

                // Varsayılan admin kullanıcısı (admin / 12345)
                var admin = new Kullanici
                {
                    Id = 1,
                    KullaniciAdi = "admin",
                    SifreHash = Services.PasswordHasher.Hash("12345"),
                    Aktif = true,
                    OlusturmaTarihi = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                };

                entity.HasData(admin);
            });
        }
    }
}

