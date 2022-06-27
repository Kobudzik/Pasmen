using Pasmen.Data.DataSources;
using Pasmen.Data.EncryptionHandlers;
using System;
using System.IO;

namespace Pasmen.Data.AbstractFactory
{
    public abstract class PasmenAbstractFactory
    {
        public static PasmenAbstractFactory Instance { get; } = CreateInstance();

        private static PasmenAbstractFactory CreateInstance()
            => ResolvePasmenFactory(AppDomain.CurrentDomain.BaseDirectory);

        private static PasmenAbstractFactory ResolvePasmenFactory(string licenceDirectory)
        {
            var licenseFiles = Directory.GetFiles(licenceDirectory, "*.lic");

            if (licenseFiles.Length > 0)
                return new PremmiumPasmenFactory();
            else
                return new FreePasmenFactory();
        }

        public abstract IDataSerializer GetDataSource();
        public abstract IEncryptionHandler GetEncryptionHandler();
    }
}
