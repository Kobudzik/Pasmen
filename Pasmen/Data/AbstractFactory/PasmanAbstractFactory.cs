using Pasman.Data.DataSources;
using Pasman.Data.EncryptionHandlers;
using System;
using System.IO;

namespace Pasman.Data.AbstractFactory
{
    public abstract class PasmanAbstractFactory
    {
        public static PasmanAbstractFactory Instance { get; } = GetInstance();

        private static PasmanAbstractFactory GetInstance()
            => ResolvePasmanFactory(AppDomain.CurrentDomain.BaseDirectory);

        public static PasmanAbstractFactory ResolvePasmanFactory(string licenceDirectory)
        {
            var licenseFiles = Directory.GetFiles(licenceDirectory, "*.lic");

            return licenseFiles.Length > 0
                ? new PremmiumPasmanAbstractFactory()
                : new FreePasmanAbstractFactory();
        }

        public abstract IDataSource GetDataSource();
        public abstract IEncryptionHandler GetEncryptionHandler();
    }
}
