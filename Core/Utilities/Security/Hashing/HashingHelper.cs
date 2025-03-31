using System.Security.Cryptography;

namespace Core.Utilities.Security.Hashing
{
    public static class HashingHelper
    {
        private const int SaltSize = 64;
        private const int HashSize = 128;
        private const int Iterations = 10000;

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            passwordSalt = RandomNumberGenerator.GetBytes(SaltSize);
            passwordHash = Rfc2898DeriveBytes.Pbkdf2(password, passwordSalt, Iterations, HashAlgorithmName.SHA512, HashSize);
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, passwordSalt, Iterations, HashAlgorithmName.SHA512, HashSize);

            return CryptographicOperations.FixedTimeEquals(inputHash, passwordHash);
        }
    }
}
