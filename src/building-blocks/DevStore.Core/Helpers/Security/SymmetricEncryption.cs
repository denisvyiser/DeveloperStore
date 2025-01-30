using System.Security.Cryptography;
using System.Text;

namespace DevStore.Core.Helpers.Security
{
    public class SymmetricEncryption
    {
        const int iterations = 5000;
        static HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        static int saltSize = 16, keySize = 20;
        public static string HashText(string text)
        {
            byte[] salt;

            RandomNumberGenerator.Create().GetBytes(salt = new byte[saltSize]);

            var pbkdf2hash = new Rfc2898DeriveBytes(
                Encoding.UTF8.GetBytes(text),
                salt,
                iterations,
                hashAlgorithm);

            byte[] hashBytes = pbkdf2hash.GetBytes(keySize);

            byte[] hash_salt_Bytes = new byte[saltSize + keySize];

            Array.Copy(salt, 0, hash_salt_Bytes, 0, saltSize);
            Array.Copy(hashBytes, 0, hash_salt_Bytes, saltSize, keySize);

            return Convert.ToBase64String(hash_salt_Bytes);
        }

        public static string HashRandom(int saltSize = 16)
        {
            byte[] salt;

            RandomNumberGenerator.Create().GetBytes(salt = new byte[saltSize]);

            return Convert.ToBase64String(salt);
        }

        public static bool VerifyHashText(string text, string hashedtext)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedtext);
            /* Get the salt */
            byte[] salt = new byte[saltSize];

            Array.Copy(hashBytes, 0, salt, 0, saltSize);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(text), salt, iterations, hashAlgorithm);
            byte[] hash = pbkdf2.GetBytes(keySize);
            /* Compare the results */
            for (int i = 0; i < keySize; i++)
            {
                if (hashBytes[i + saltSize] != hash[i])
                    return false;
            }

            return true;
        }
    }
}
