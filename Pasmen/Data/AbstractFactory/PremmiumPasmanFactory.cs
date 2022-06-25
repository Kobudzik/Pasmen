using Pasman.Data.DataSources;
using Pasman.Data.EncryptionHandlers;

namespace Pasman.Data.AbstractFactory
{
    public class PremmiumPasmanFactory : PasmanAbstractFactory
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