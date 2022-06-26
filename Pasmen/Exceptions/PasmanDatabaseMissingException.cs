using System;

namespace Pasman.Exceptions
{
    public class PasmanDatabaseMissingException : PasmanDatabaseException
    {
        public PasmanDatabaseMissingException()
        {
        }

        public PasmanDatabaseMissingException(string message) : base(message)
        {
        }
    }
}
