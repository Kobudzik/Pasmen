using Pasman.Data.AbstractFactory;
using Pasman.Exceptions;
using System;
using System.IO;

namespace Pasman
{
    internal static class Client
    {

        private static void Main()
        {
            Console.ResetColor();

            var pasmanFactory = PasmanAbstractFactory.Instance;
            var configuration = PasmanConfiguration.Instance;

            var fileHelper = new PasmanFileReader(configuration.BaseDirectory, "*" + configuration.PASMAN_FILE_EXTENSION);

            string stringifiedData = null;

            try
            {
                configuration.DbFileName = fileHelper.GetDatabaseName();
                stringifiedData = fileHelper.ReadPasmanDatabase(configuration.BaseDirectory + configuration.DbFileName);
            }
            catch (PasmanDatabaseMissingException misingEx)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                configuration.DbFileName = AskDataBaseName();

            }
            catch (PasmanDatabaseException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Error: {ex.Message}");
            }
        

            try
            {
                var decodedString = pasmanFactory.GetEncryptionHandler().Decrypt(stringifiedData);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"DB corrupted. DB deserialization error: {ex.Message}");
            }
            var deserializedData = pasmanFactory.GetDataSource();

            //tworzyć singletona pasman settings: filename(s), db name, password
            ///DECODE data
            /// DESERIALIZE DATA
        }

        private static string AskDataBaseName()
        {
            Console.ResetColor();
            Console.WriteLine("Enter Pasman DB filename");

            return Console.ReadLine();
        }

        private static void CreateDatabaseFile()
        {
            File.Create(baseDirectory + "pasmanDbName"); //basedir nazwa z settings
        }

        private void
    }
}
