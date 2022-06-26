using System;

namespace Pasman.Exceptions
{
    public class PasmanDatabaseCorruptedException : PasmanDatabaseException
    {
        public PasmanDatabaseCorruptedException()
        {
        }

        public PasmanDatabaseCorruptedException(string message) : base(message)
        {
        }
    }
}
