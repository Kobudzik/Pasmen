using System;

namespace Pasman.Exceptions
{
    public class PasmanDatabaseException : Exception
    {
        public PasmanDatabaseException()
        {
        }

        public PasmanDatabaseException(string message) : base(message)
        {
        }
    }
}
