using System;

namespace Pasmen.Data.AbstractFactory
{
    public class PasmenConfiguration
    {
        public const string Pasmen_FILE_EXTENSION = ".pasmen";

        public string BaseDirectory { get; set; } = AppDomain.CurrentDomain.BaseDirectory;
        public string DbFileName { get; set; }
        public string Password { get; set; }

        public string DbPath
            => BaseDirectory + DbFileName + Pasmen_FILE_EXTENSION;

        public static PasmenConfiguration Instance { get; } = CreateInstance();

        private static PasmenConfiguration CreateInstance()
            => new PasmenConfiguration();
    }
}
