using Pasmen.Data.DataSources;
using Pasmen.Data.EncryptionHandlers;

namespace Pasmen.Data.AbstractFactory
{
    public class PremmiumPasmenFactory : PasmenAbstractFactory
    {
        public override IDataSerializer GetDataSource()
        {
            return new JsonDataSerializer();
        }

        public override IEncryptionHandler GetEncryptionHandler()
        {
            return new PremmiumEncryptionHandler();
        }
    }
}