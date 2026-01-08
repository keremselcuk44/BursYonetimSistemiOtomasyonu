using System;
using System.ComponentModel.DataAnnotations;

namespace OgrenciBursOtomasyonu.Api.Models
{
    /// <summary>
    /// Uygulama girişleri için temel kullanıcı modeli.
    /// </summary>
    public class Kullanici
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string KullaniciAdi { get; set; } = string.Empty;

        [Required]
        [MaxLength(256)]
        public string SifreHash { get; set; } = string.Empty;

        public bool Aktif { get; set; } = true;

        public DateTime OlusturmaTarihi { get; set; } = DateTime.UtcNow;
    }
}

