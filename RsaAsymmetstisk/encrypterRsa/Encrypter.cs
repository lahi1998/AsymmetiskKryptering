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


        // kryptere et byte[] og retunere det, ligger i en try catch så hvis der fejl får man udprinted en fejl besked, og retunere null.
        public byte[] EncryptData(byte[] dataEncrypt)
        {
            try
            {
                return rsa.Encrypt(dataEncrypt, RSAEncryptionPadding.OaepSHA256);
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine($" Encryption Error: {ex.Message}");
                Console.ReadKey();
                return null;
            }
        }
    }
}

