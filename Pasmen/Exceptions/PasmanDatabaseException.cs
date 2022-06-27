using System;

namespace Pasmen.Exceptions
{
    public class PasmenDatabaseException : Exception
    {
        public PasmenDatabaseException()
        {
        }

        public PasmenDatabaseException(string message) : base(message)
        {
        }
    }
}
