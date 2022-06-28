using Pasmen.Data.AbstractFactory;
using Pasmen.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace Pasmen
{
    public static class PasmenService
    {
        public static Dictionary<string, string> ResolvePasswordEntries()
        {
            var conf = PasmenConfiguration.Instance;

            if(string.IsNullOrEmpty(conf.DbFileName))
            {
                conf.DbFileName = FindExistingDatabaseName();

                if(string.IsNullOrEmpty(conf.DbFileName))
                    conf.DbFileName = UiHelper.PromptDatabaseName();
            }

            if(string.IsNullOrEmpty(conf.Password))
                conf.Password = UiHelper.PromptDatabasePassword();

            AssertFileExistence(conf.DbPath);

            var stringifiedData = File.ReadAllText(PasmenConfiguration.Instance.DbPath);

            if (!string.IsNullOrEmpty(stringifiedData))
            {
                try
                {
                    var decryptedData = PasmenAbstractFactory.Instance.GetEncryptionHandler().Decrypt(stringifiedData);
                    var deserializedData = PasmenAbstractFactory.Instance.GetDataSource().DeserializeData(decryptedData);
                    return deserializedData;
                }
                catch(CryptographicException)
                {
                    UiHelper.WriteError("Wrong password entered");
                    conf.Password = null;
                    return ResolvePasswordEntries();
                }
            }

            return new Dictionary<string, string>();
        }

        private static string FindExistingDatabaseName()
        {
            Console.WriteLine("Checking for Pasmen database existence...");

            var dbFilesPaths = Directory.GetFiles(PasmenConfiguration.Instance.BaseDirectory, "*" + PasmenConfiguration.Pasmen_FILE_EXTENSION);

            if (dbFilesPaths.Length > 1)
                throw new PasmenDatabaseException("More than one Pasmen DB found.");

            if (dbFilesPaths.Length == 0)
                return null;
            //throw new PasmenDatabaseMissingException("No Pasmen DB found.");

            var dbFilePath = dbFilesPaths[0];
            Console.WriteLine($"Found database {dbFilePath}.");
            return Path.GetFileNameWithoutExtension(dbFilePath);
        }


        private static void AssertFileExistence(string path)
        {
            if (!File.Exists(path))
                File.Create(path).Close();
        }

        public static void SavePasswordEntries(IDictionary<string, string> passwords)
        {
            var serializedData = PasmenAbstractFactory.Instance.GetDataSource().SerializeData(passwords);
            var ecryptedData = PasmenAbstractFactory.Instance.GetEncryptionHandler().Encrypt(serializedData);

            File.WriteAllText(PasmenConfiguration.Instance.DbPath, ecryptedData);
        }
    }
}
