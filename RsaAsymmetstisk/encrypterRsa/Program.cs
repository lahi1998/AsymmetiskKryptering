using encrypterRsa;
using EncrypterRSA;
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
        Console.WriteLine();
        Console.WriteLine(" besked til kryptering med rsa.");


        HexToByteArrayConverter Conv = new HexToByteArrayConverter();

        // Modtager hexadecimal, find virkne convertering løsning
        Console.WriteLine();
        Console.WriteLine(" Indtast/paste Exponent :");
        string exponentString = Console.ReadLine();
        byte[] exponent = Conv.StringToByteArray(exponentString);

        Console.WriteLine();
        Console.WriteLine(" Indtast/paste Modulus :");
        string modulusString = Console.ReadLine();
        byte[] modulus = Conv.StringToByteArray(modulusString);

        Console.WriteLine();
        Console.Write(" Indtast besked : ");
        string? Message = Console.ReadLine();



        var rsaen = new Encrypter(modulus, exponent);

        var encryptedMessage = rsaen.EncryptData(Encoding.ASCII.GetBytes(Message));
        rsaen.DeleteKey();

        var lentghten = BitConverter.ToString(value: encryptedMessage).Replace("-", ""); ;
        Console.WriteLine($"Encrypted Message Length: {lentghten.Length} bytes");
        

        // output area for 
        //Console.Clear();
        Console.WriteLine();
        Console.WriteLine(" Original Text = " + Message);
        Console.WriteLine();
        Console.WriteLine($" Encrypted Text = {BitConverter.ToString(value: encryptedMessage)}");
        Console.ReadKey();
    }

}
