using System;

namespace Pasmen.Exceptions
{
    public class PasmenDatabaseMissingException : PasmenDatabaseException
    {
        public PasmenDatabaseMissingException()
        {
        }

        public PasmenDatabaseMissingException(string message) : base(message)
        {
        }
    }
}
