﻿using System;

namespace Pasman.Data.EncryptionHandlers
{
    public class FreeEncryptionHandler : IEncryptionHandler
    {
        public string Decrypt(string data)
        {
            //decrypt  256-bit AES
            throw new NotImplementedException();
        }

        public string Encrypt()
        {
            //encrypt  256-bit AES
            throw new NotImplementedException();
        }
    }
}