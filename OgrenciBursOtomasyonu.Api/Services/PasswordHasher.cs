using System;
using System.Security.Cryptography;
using System.Text;

namespace OgrenciBursOtomasyonu.Api.Services
{
    /// <summary>
    /// Basit SHA256 tabanlı parola hash'leme yardımcı sınıfı.
    /// </summary>
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = sha.ComputeHash(bytes);
            return Convert.ToHexString(hashBytes);
        }
    }
}

