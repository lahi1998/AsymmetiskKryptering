using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace encrypterRsa
{
    internal class Encrypter
    {
        private RSA rsa;

        public Encrypter(byte[] modulus, byte[] exponent)
        {
            rsa = RSA.Create();
            rsa.KeySize = 2048;
            RSAParameters publicKey = new RSAParameters
            {
                Modulus = modulus,
                Exponent = exponent
            };
            rsa.ImportParameters(publicKey);
        }

        public void DeleteKey()
        {
            rsa.Clear();
        }

        public byte[] EncryptData(byte[] dataEncrypt)
        {
            return rsa.Encrypt(dataEncrypt, RSAEncryptionPadding.OaepSHA256);
        }
    }
}

