using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace FridgeBE.Infrastructure.Utils
{
    public class PasswordUtils
    {
        public static void HashPassword(string password, out string passwordHash, out string passwordSalt)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            byte[] passwordBytes = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA1, 1000, 32);
            passwordHash = Convert.ToBase64String(passwordBytes);
            passwordSalt = Convert.ToBase64String(salt);
        }

        public static bool VerifyPasswordHash(string password, string storedPasswordHash, string storedPasswordSalt)
        {
            byte[] salt = Convert.FromBase64String(storedPasswordSalt);
            byte[] passwordHash = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA1, 1000, 32);

            return CryptographicOperations.FixedTimeEquals(passwordHash, Convert.FromBase64String(storedPasswordHash));
        }
    }
}