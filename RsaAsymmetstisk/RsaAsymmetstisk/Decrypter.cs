using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RsaAsymmetstisk
{
    internal class Decrypter
    {
        private RSA rsa;
        private RSAParameters _publicKey;
        private RSAParameters _privateKey;

        public void AssignKey()
        {
            _publicKey = rsa.ExportParameters(false); // Export the public key
            _privateKey = rsa.ExportParameters(true); // Export the private key
        }

        public Decrypter()
        {
            rsa = RSA.Create();
            rsa.KeySize = 2048;
            AssignKey(); // Call AssignKey to generate keys in the constructor
        }

        public void DeleteKey()
        {
            rsa.Clear();
        }

        // Dekryptere det byte array det bliver fodret fra program.
        public byte[] DecryptData(byte[] dataDecrypt)
        {
            byte[] cipherbytes;
            cipherbytes = rsa.Decrypt(dataDecrypt, RSAEncryptionPadding.OaepSHA256);
            return cipherbytes;
        }

        // Display af keys bruge a program.
        public void DisplayKeys()
        {
            Console.WriteLine();
            Console.WriteLine($" Public Key Exponent: {BitConverter.ToString(value: _publicKey.Exponent)}");
            Console.WriteLine();
            Console.WriteLine($" Public Key Modulus: {BitConverter.ToString(value: _publicKey.Modulus)}");
            Console.WriteLine();
            Console.WriteLine($" Private Key D: {BitConverter.ToString(value: _privateKey.D)}");
            Console.WriteLine();
            Console.WriteLine($" Private Key DP: {BitConverter.ToString(value: _privateKey.DP)}");
            Console.WriteLine();
            Console.WriteLine($" Private Key DQ: {BitConverter.ToString(value: _privateKey.DQ)}");
            Console.WriteLine();
            Console.WriteLine($" Private Key InverseQ: {BitConverter.ToString(value: _privateKey.InverseQ)}");
            Console.WriteLine();
            Console.WriteLine($" Private Key P: {BitConverter.ToString(value: _privateKey.P)}");
            Console.WriteLine();
            Console.WriteLine($" Private Key Q: {BitConverter.ToString(value: _privateKey.Q)}");
        }
    }
}

