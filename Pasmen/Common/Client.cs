using Pasman.Data.AbstractFactory;
using Pasman.Exceptions;
using System;

namespace Pasman
{
    internal static class Client
    {
        public static string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public const string pasmanFileNameExtension = ".pasman";

        private static void Main()
        {
            var pasmanFactory = PasmanAbstractFactory.Instance;

            var fileHelper = new PasmanFileReader(baseDirectory, pasmanFileNameExtension);

            string pasmanDbFileName = null;
            string stringifiedData = null;

            try
            {
                pasmanDbFileName = fileHelper.GetDatabaseName();
                stringifiedData = fileHelper.ReadPasmanDatabase();
            }
            catch (PasmanDatabaseException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Error: {ex.Message}");
            }

            var decodedString =pasmanFactory.GetEncryptionHandler().Decrypt(stringifiedData);
            var deserializedData = pasmanFactory.GetDataSource();

            //tworzyć singletona pasman settings: filename(s), db name, password
            ///DECODE data
            /// DESERIALIZE DATA
        }
    }
}
