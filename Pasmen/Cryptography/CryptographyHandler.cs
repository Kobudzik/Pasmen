using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Pasmen
{
    public class CryptographyHandler
    {
        #region Settings
        private readonly string _vector;
        private const int _iterations = 2;
        private const int _keySize = 256;

        private const string _hash = "SHA1";
        private const string _salt = "aselrias38490a32"; // Random
        #endregion

        public CryptographyHandler(string vector)
        {
            _vector = vector;
        }

        public string Encrypt<T>(string data, string password)
                where T : SymmetricAlgorithm, new()
        {
            byte[] vectorBytes = Encoding.ASCII.GetBytes(_vector);
            byte[] saltBytes = Encoding.ASCII.GetBytes(_salt);
            byte[] valueBytes = Encoding.UTF8.GetBytes(data);

            byte[] encrypted;

            using (var cipher = new T())
            {
                var _passwordBytes = new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;

                using (ICryptoTransform encryptor = cipher.CreateEncryptor(keyBytes, vectorBytes))
                {
                    using (var to = new MemoryStream())
                    using (var writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write))
                    {
                        writer.Write(valueBytes, 0, valueBytes.Length);
                        writer.FlushFinalBlock();
                        encrypted = to.ToArray();
                    }
                }

                cipher.Clear();
            }

            return Convert.ToBase64String(encrypted);
        }

        public string Encrypt(string data, string password)
            => Encrypt<AesManaged>(data, password);

        public string Decrypt<T>(string data, string password)
            where T : SymmetricAlgorithm, new()
        {
            byte[] vectorBytes = Encoding.ASCII.GetBytes(_vector);
            byte[] saltBytes = Encoding.ASCII.GetBytes(_salt);
            byte[] valueBytes = Convert.FromBase64String(data);

            byte[] decrypted;
            int decryptedByteCount = 0;

            using (var cipher = new T())
            {
                var _passwordBytes = new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;

                try
                {
                    using (ICryptoTransform decryptor = cipher.CreateDecryptor(keyBytes, vectorBytes))
                    using (var from = new MemoryStream(valueBytes))
                    using (var reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read))
                    {
                        decrypted = new byte[valueBytes.Length];
                        decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }

                cipher.Clear();
            }
            return Encoding.UTF8.GetString(decrypted, 0, decryptedByteCount);
        }

        public string Decrypt(string data, string password)
            => Decrypt<AesManaged>(data, password);
    }
}