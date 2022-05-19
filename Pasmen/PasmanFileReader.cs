using System;
using System.IO;

namespace Pasman
{
    public class PasmanFileReader
    {
        private readonly string _baseDirectory;
        private readonly string _pasmanFileName;

        public PasmanFileReader(string baseDirectory, string pasmanFileName)
        {
            _baseDirectory = baseDirectory;
            this._pasmanFileName = pasmanFileName;
        }

        public string GetDatabaseName()
        {
            Console.WriteLine("Checking for Pasman database existence...");

            var dbFiles = Directory.GetFiles(_baseDirectory, _pasmanFileName);

            if (dbFiles.Length > 1)
                throw new Exception("More than one Pasman DB found.");

            if (dbFiles.Length == 0)
                throw new Exception("No Pasman DB found.");

            var dbName = dbFiles[0];
            Console.WriteLine($"Found database {dbName}.");

            return dbName;
        }

        public string ReadPasmanDatabase()
        {
            Console.WriteLine("Reading Pasman database...");
            var data = File.ReadAllText(_baseDirectory + _pasmanFileName);

            return data;
        }
    }
}
