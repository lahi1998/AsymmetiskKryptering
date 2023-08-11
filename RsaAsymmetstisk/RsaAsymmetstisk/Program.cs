using EncrypterRSA;
using RsaAsymmetstisk;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("                    Asymmetrisk kryptering");
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------------------");

        var RSADE = new Decrypter();
        HexToByteArrayConverter Conv = new HexToByteArrayConverter();

        RSADE.DisplayKeys();
        Console.WriteLine();
        Console.WriteLine(" besked til decryptering med rsa.");
        Console.WriteLine();
        Console.Write(" Indtast krypted besked : ");
        string? encryptedMessagestring = Console.ReadLine();
        byte[] encryptedMessage = Conv.StringToByteArray(encryptedMessagestring);
        byte[] decryptedMessage = null;

        try
        {
            Console.WriteLine($"Encrypted Message Length: {encryptedMessage.Length} bytes");
            Console.ReadKey();
            decryptedMessage = RSADE.DecryptData(encryptedMessage);
        }
        catch (CryptographicException ex)
        {
            Console.WriteLine($"Decryption Error: {ex.Message}");
            Console.ReadKey();
        }

        RSADE.DeleteKey();
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine($" Encrypted Text = {BitConverter.ToString(value: encryptedMessage)}");
        Console.WriteLine();
        Console.WriteLine($" Decrypted Text = {Encoding.Default.GetString(decryptedMessage)}");
    }

}