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

        // Genere nøgle og display de være med en displaykeys metode over fra decrypter.
        var RSADE = new Decrypter();
        RSADE.DisplayKeys();

        // modtager den kryptered besked fra bruger og sender det til en klasse med en metode der convertere det fra en string med hex om til byte[].
        //
        HexToByteArrayConverter Conv = new HexToByteArrayConverter();
        Console.WriteLine();
        Console.WriteLine(" besked til decryptering med rsa.");
        Console.WriteLine();
        Console.Write(" Indtast krypted besked : ");
        string? encryptedMessagestring = Console.ReadLine();
        byte[] encryptedMessage = Conv.StringToByteArray(encryptedMessagestring);
        byte[] decryptedMessage = null;

        // try catch til og fange evt fejl besked hvis bruger skulle indputte en kryptered besked der ikke matcher eller noget andet.
        try
        {
            decryptedMessage = RSADE.DecryptData(encryptedMessage);
        }
        catch (CryptographicException ex)
        {
            Console.WriteLine($" Decryption Error: {ex.Message}");
            Console.ReadKey();
        }

        RSADE.DeleteKey();
        Console.Clear();
        Console.WriteLine($" Encrypted Message Length: {encryptedMessage.Length} bytes");
        Console.WriteLine();
        Console.WriteLine($" Encrypted Text = {BitConverter.ToString(value: encryptedMessage)}");
        Console.WriteLine();
        Console.WriteLine($" Decrypted Text = {Encoding.Default.GetString(decryptedMessage)}");
        Console.ReadKey();
    }

}