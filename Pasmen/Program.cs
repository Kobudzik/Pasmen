using Pasman.Data.AbstractFactory;
using System;

namespace Pasman
{
    internal static class Program
    {
        public static string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public const string pasmanFileName = "pasman.data";

        private static void Main()
        {
            var pasmanFactory = PasmanAbstractFactory.Instance;

            var fileHelper = new PasmanFileReader(baseDirectory, pasmanFileName);

            var pasmanDbName = fileHelper.GetDatabaseName();
            var data = fileHelper.ReadPasmanDatabase();
        }
    }
}
