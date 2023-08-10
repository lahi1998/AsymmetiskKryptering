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
        private RSAParameters _publicKey;
        private RSAParameters _privateKey;

        public Encrypter(byte[] modulus, byte[] exponent)
        {
            rsa = RSA.Create();
            rsa.KeySize = 2048;
            _publicKey = new RSAParameters
            {
                Modulus = modulus,
                Exponent = exponent
            };
        }

        public void DeleteKey()
        {
            rsa.Clear();
        }

        public byte[] EncryptData(byte[] dataEncrypt)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(_publicKey);
                return rsa.Encrypt(dataEncrypt, RSAEncryptionPadding.OaepSHA256);
            }
        }

    }

}

