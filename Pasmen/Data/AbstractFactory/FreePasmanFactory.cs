using Pasmen.Data.DataSources;
using Pasmen.Data.EncryptionHandlers;

namespace Pasmen.Data.AbstractFactory
{
    public class FreePasmenFactory : PasmenAbstractFactory
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
