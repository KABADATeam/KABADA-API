using System;
using System.Security.Cryptography;
using System.Text;

namespace KabadaAPI.DataSource.Utilities
{
    public static class Cryptography
    {
        public static string GetSalt()
        {
            byte[] bytes = new byte[16];
            using (var keyGenerator = RandomNumberGenerator.Create())
            {
                keyGenerator.GetBytes(bytes);
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        public static string GetHash(string plainText, string saltValue)
        {
            string text = $"{plainText}{saltValue}";
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
