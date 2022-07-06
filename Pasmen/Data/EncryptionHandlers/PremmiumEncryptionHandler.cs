using Pasmen.Data.AbstractFactory;

namespace Pasmen.Data.EncryptionHandlers
{
    public class PremmiumEncryptionHandler : IEncryptionHandler
    {
        private CryptographyHandler CryptographyHandler {get;}

        public PremmiumEncryptionHandler()
        {
            CryptographyHandler = new CryptographyHandler(GetVector());
        }

        public string Decrypt(string data)
        {
            var encryptedData = CryptographyHandler.Decrypt(data, PasmenConfiguration.Instance.Password);
            return encryptedData;
        }

        public string Encrypt(string data)
        {
            var encryptionResult = CryptographyHandler.Encrypt(data, PasmenConfiguration.Instance.Password);
            return encryptionResult;
        }

        private string GetVector()
        {
            var vector = PasmenConfiguration.Instance.DbFileName;

            while (vector.Length < 16)
                vector +=  vector;

            return vector.Substring(0, 16);
        }
    }
}