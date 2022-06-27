using Pasmen.Common;
using Pasmen.Data.AbstractFactory;
using Pasmen.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

namespace Pasmen
{
    public static class PasmenService
    {
        public static string FindDatabaseName()
        {
            Console.WriteLine("Checking for Pasmen database existence...");

            var dbFilesPaths = Directory.GetFiles(PasmenConfiguration.Instance.BaseDirectory, "*" + PasmenConfiguration.Pasmen_FILE_EXTENSION);

            if (dbFilesPaths.Length > 1)
                throw new PasmenDatabaseException("More than one Pasmen DB found.");

            if (dbFilesPaths.Length == 0)
                throw new PasmenDatabaseMissingException("No Pasmen DB found.");

            var dbFilePath = dbFilesPaths[0];
            Console.WriteLine($"Found database {dbFilePath}.");

            return Path.GetFileName(dbFilePath);
        }

        public static Dictionary<string, string> ResolvePasswordEntries()
        {
            var conf = PasmenConfiguration.Instance;
            conf.DbFileName = FindDatabaseName();
            conf.Password = UiHelper.PromptDatabasePassword();

            var stringifiedData = GetStringifiedDbData();

            if (!string.IsNullOrEmpty(stringifiedData))
            {
                try
                {
                    var decryptedData = PasmenAbstractFactory.Instance.GetEncryptionHandler().Decrypt(stringifiedData);
                    var deserializedData = PasmenAbstractFactory.Instance.GetDataSource().DeserializeData(stringifiedData);
                    return deserializedData;
                }
                catch (Exception ex)
                {
                    UiHelper.WriteError($"DB corrupted. Error: {ex.Message}");
                    throw;
                }
            }

            return new Dictionary<string, string>();
        }


        public static string GetStringifiedDbData()
        {
            try
            {
                var conf = PasmenConfiguration.Instance;
                Console.WriteLine("Reading Pasmen database...");
                return File.ReadAllText(conf.DbPath);
            }
            catch (PasmenDatabaseMissingException missingEx)
            {
                UiHelper.WriteError(missingEx.Message);

                var conf = PasmenConfiguration.Instance;
                conf.DbFileName = UiHelper.PromptDatabaseName();
                File.Create(conf.BaseDirectory + conf.DbFileName + PasmenConfiguration.Pasmen_FILE_EXTENSION);
                return null;
            }
            catch (PasmenDatabaseException ex)
            {
                UiHelper.WriteError($"Error: {ex.Message}");
                throw;
            }
        }

        public static void SavePasswordEntries(IDictionary<string, string> passwords)
        {
            var serializedData = PasmenAbstractFactory.Instance.GetDataSource().SerializeData(passwords);
            var ecryptedData = PasmenAbstractFactory.Instance.GetEncryptionHandler().Encrypt(serializedData);
            var configuration = PasmenConfiguration.Instance;

            File.WriteAllText(configuration.DbPath, ecryptedData);
            UiHelper.WriteSucccess("File saved succesfully");
        }
    }
}
