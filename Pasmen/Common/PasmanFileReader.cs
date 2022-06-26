using Pasman.Exceptions;
using System;
using System.IO;

namespace Pasman
{
    public class PasmanFileReader
    {
        private readonly string _baseDirectory;
        private readonly string _filesSearchPattern;

        public PasmanFileReader(string baseDirectory, string filesSearchPattern)
        {
            _baseDirectory = baseDirectory;
            this._filesSearchPattern = filesSearchPattern;
        }

        public string GetDatabaseName()
        {
            Console.WriteLine("Checking for Pasman database existence...");

            var dbFilesPaths = Directory.GetFiles(_baseDirectory, _filesSearchPattern);

            if (dbFilesPaths.Length > 1)
                throw new PasmanDatabaseException("More than one Pasman DB found.");

            if (dbFilesPaths.Length == 0)
                throw new PasmanDatabaseMissingException("No Pasman DB found.");

            var dbFilePath = dbFilesPaths[0];
            Console.WriteLine($"Found database {dbFilePath}.");

            var fileName = Path.GetFileName(dbFilePath);

            return fileName;
        }

        public string ReadPasmanDatabase(string path)
        {
            Console.WriteLine("Reading Pasman database...");
            var data = File.ReadAllText(path);

            if(string.IsNullOrEmpty(data))
                throw new PasmanDatabaseMissingException("Pasman DB file does not contain data.");

            return data;
        }
    }
}
