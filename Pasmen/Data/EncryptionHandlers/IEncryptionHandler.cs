namespace Pasman.Data.EncryptionHandlers
{
    public interface IEncryptionHandler
    {
        public string Encrypt();
        public string Decrypt(string data);
    }
}