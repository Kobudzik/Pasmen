using Pasman.Data.DataSources;
using Pasman.Data.EncryptionHandlers;

namespace Pasman.Data.AbstractFactory
{
    public class FreePasmanFactory : PasmanAbstractFactory
    {
        public override IDataSource GetDataSource()
        {
            return new FreeDataSource();
        }

        public override IEncryptionHandler GetEncryptionHandler()
        {
            return new FreeEncryptionHandler();
        }
    }
}
