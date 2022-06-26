using System;

namespace Pasman.Data.AbstractFactory
{
    public class PasmanConfiguration
    {
        public string PASMAN_FILE_EXTENSION = "*.pasman";
        public string BaseDirectory { get; set; } = AppDomain.CurrentDomain.BaseDirectory;

        public string DbFileName { get; set; }
        public string DbPath { get; set; }
        public string Password { get; set; }

        public static PasmanConfiguration Instance { get; } = CreateInstance();

        private static PasmanConfiguration CreateInstance()
            => new PasmanConfiguration();
    }
}
