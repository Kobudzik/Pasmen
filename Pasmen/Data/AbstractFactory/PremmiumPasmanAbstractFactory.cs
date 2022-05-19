using Pasman.Data.DataSources;
using Pasman.Data.EncryptionHandlers;

namespace Pasman.Data.AbstractFactory
{
    public class PremmiumPasmanAbstractFactory : PasmanAbstractFactory
    {
        public override IDataSource GetDataSource()
        {
            return new PremmiumDataSource();
        }

        public override IEncryptionHandler GetEncryptionHandler()
        {
            return new PremmiumEncryptionHandler();
        }
    }
}