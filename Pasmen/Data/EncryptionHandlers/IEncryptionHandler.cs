namespace Pasmen.Data.EncryptionHandlers
{
    public interface IEncryptionHandler
    {
        string Encrypt(string data);
        string Decrypt(string data);
    }
}