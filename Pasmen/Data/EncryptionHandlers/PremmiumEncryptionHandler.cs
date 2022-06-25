using System;

namespace Pasman.Data.EncryptionHandlers
{
    public class PremmiumEncryptionHandler : IEncryptionHandler
    {
        public string Decrypt(string data)
        {
            var encryptionHandler = new CryptographyHandler("rJ23$2Fgfds"); //todo set from db name
            var encryptedData = encryptionHandler.Decrypt(data, "test"); //todo set from client input
            return encryptedData;
        }

        public string Encrypt(string data)
        {
            //encrypt  64-bit des
            throw new NotImplementedException();
        }
    }
}