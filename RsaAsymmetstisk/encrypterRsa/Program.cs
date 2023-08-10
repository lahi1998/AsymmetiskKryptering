using encrypterRsa;
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
        Console.WriteLine();

        Console.WriteLine("Indtast/paste Modulus :");
        string? modulusString = Console.ReadLine().Replace("-", "");
        byte[] modulus = Encoding.UTF8.GetBytes(modulusString);

        Console.WriteLine();
        Console.WriteLine("Indtast/paste Exponent :");
        string? exponentString = Console.ReadLine();
        byte[] exponent = Encoding.UTF8.GetBytes(exponentString);

        Console.Write(" Indtast krypted besked : ");
        string? Message = Console.ReadLine();


        
        var rsaen = new Encrypter(modulus, exponent);

        //sender beskeden til kryptering
        var encryptedMessage = rsaen.EncryptData(Encoding.UTF8.GetBytes(Message));
        rsaen.DeleteKey();

        // output area for 
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("   Original Text = " + Message);
        Console.WriteLine();
        Console.WriteLine($"   Encrypted Text = {BitConverter.ToString(value: encryptedMessage)}");
        Console.ReadKey();
    }

}
