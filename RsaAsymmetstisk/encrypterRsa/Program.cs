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

        //modtager indput fra bruger og sender det til en klasse med en metode der convertere det fra en string med hex om til byte[].
        Console.WriteLine();
        Console.Write(" Indtast/paste Exponent :");
        string exponentString = Console.ReadLine();
        byte[] exponent = Conv.StringToByteArray(exponentString);

        Console.WriteLine();
        Console.Write(" Indtast/paste Modulus :");
        string modulusString = Console.ReadLine();
        byte[] modulus = Conv.StringToByteArray(modulusString);

        // sender modulus og exponet til encrypter så den kan lave nøgle og erstatte modulus og exponet parameterne, med dem fra bruger indput
        var rsaen = new Encrypter(modulus, exponent);

        // modtager input fra bruger og laver det om til en bytes og sender det til EncryptData som så returnere den kryptered besked.
        Console.WriteLine();
        Console.Write(" Indtast besked : ");
        string? Message = Console.ReadLine();
        var encryptedMessage = rsaen.EncryptData(Encoding.ASCII.GetBytes(Message));
        rsaen.DeleteKey();


        

        // udskriver antal bytes og orginal besked og den kryptered besked, ved godt det ikke er sikkert, gør det for demostrations grundlag.
        Console.Clear();
        var lentghten = BitConverter.ToString(value: encryptedMessage).Replace("-", ""); ;
        Console.WriteLine($" Encrypted Message Length: {lentghten.Length} bytes");
        Console.WriteLine();
        Console.WriteLine(" Original Text = " + Message);
        Console.WriteLine();
        Console.WriteLine($" Encrypted Text = {BitConverter.ToString(value: encryptedMessage)}");
        Console.ReadKey();
    }

}
