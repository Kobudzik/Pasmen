using Pasmen.Data.AbstractFactory;
using System;

namespace Pasmen.Data.EncryptionHandlers
{
    public class PremmiumEncryptionHandler : IEncryptionHandler
    {
        public string Decrypt(string data)
        {
            var encryptionHandler = new CryptographyHandler(PasmenConfiguration.Instance.DbFileName);
            var encryptedData = encryptionHandler.Decrypt(data, PasmenConfiguration.Instance.Password);
            return encryptedData;
        }

        public string Encrypt(string data)
        {
            var encryptionHandler = new CryptographyHandler(PasmenConfiguration.Instance.DbFileName);
            var encryptionResult = encryptionHandler.Encrypt(data, PasmenConfiguration.Instance.Password);
            return encryptionResult;
        }
    }
}