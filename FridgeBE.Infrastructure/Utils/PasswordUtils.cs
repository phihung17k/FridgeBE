using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace FridgeBE.Infrastructure.Utils
{
    public class PasswordUtils
    {
        public static void HashPassword(string password, out string passwordHash, out byte[] passwordSalt)
        {
            passwordSalt = RandomNumberGenerator.GetBytes(16);
            byte[] passwordBytes = KeyDerivation.Pbkdf2(password, passwordSalt, KeyDerivationPrf.HMACSHA1, 1000, 32);
            passwordHash = Convert.ToBase64String(passwordBytes);
        }

        public static bool VerifyPasswordHash(string password, string passwordHash, byte[] passwordSalt)
        {
            byte[] passwordHashBytes = KeyDerivation.Pbkdf2(password, passwordSalt, KeyDerivationPrf.HMACSHA1, 1000, 32);

            return CryptographicOperations.FixedTimeEquals(passwordHashBytes, Convert.FromBase64String(passwordHash));
        }
    }
}