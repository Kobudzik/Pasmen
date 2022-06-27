using Pasmen.Data.AbstractFactory;
using Pasmen.Exceptions;
using System;
using System.IO;

namespace Pasmen
{
    public static class PasmenFileReader
    {
        public static string PromptDatabaseName()
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

        public static string ReadFile(string path)
        {
            Console.WriteLine("Reading Pasmen database...");
            return File.ReadAllText(path);
        }
    }
}
