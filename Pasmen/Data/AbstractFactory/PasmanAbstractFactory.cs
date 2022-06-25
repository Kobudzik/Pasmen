using Pasman.Data.DataSources;
using Pasman.Data.EncryptionHandlers;
using System;
using System.IO;

namespace Pasman.Data.AbstractFactory
{
    public abstract class PasmanAbstractFactory
    {
        public static PasmanAbstractFactory Instance { get; } = CreateInstance();

        private static PasmanAbstractFactory CreateInstance()
            => ResolvePasmanFactory(AppDomain.CurrentDomain.BaseDirectory);

        private static PasmanAbstractFactory ResolvePasmanFactory(string licenceDirectory)
        {
            var licenseFiles = Directory.GetFiles(licenceDirectory, "*.lic");

            if (licenseFiles.Length > 0)
                return new PremmiumPasmanFactory();
            else
                return new FreePasmanFactory();
        }

        public abstract IDataSerializer GetDataSource();
        public abstract IEncryptionHandler GetEncryptionHandler();
    }
}
