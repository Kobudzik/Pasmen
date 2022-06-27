using System;

namespace Pasmen.Exceptions
{
    public class PasmenDatabaseCorruptedException : PasmenDatabaseException
    {
        public PasmenDatabaseCorruptedException()
        {
        }

        public PasmenDatabaseCorruptedException(string message) : base(message)
        {
        }
    }
}
