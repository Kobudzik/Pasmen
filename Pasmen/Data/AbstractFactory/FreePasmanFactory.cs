using Pasman.Data.DataSources;
using Pasman.Data.EncryptionHandlers;

namespace Pasman.Data.AbstractFactory
{
    public class FreePasmanFactory : PasmanAbstractFactory
    {
        public override IDataSerializer GetDataSource()
        {
            return new XmlDataSerializer();
        }

        public override IEncryptionHandler GetEncryptionHandler()
        {
            return new FreeEncryptionHandler();
        }
    }
}
