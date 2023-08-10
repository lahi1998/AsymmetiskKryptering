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

        //køre en metode med alle keys både privat i writelines.
        RSADE.DisplayKeys();
        
        Console.WriteLine();
        Console.WriteLine(" besked til decryptering med rsa.");
        Console.WriteLine();
        Console.Write(" Indtast krypted besked : ");
        string? encryptedMessagestring = Console.ReadLine();
        byte[] encryptedMessage = Encoding.UTF8.GetBytes(encryptedMessagestring);

        sender beskeden til decryptering
        var decryptedMessage = RSADE.DecryptData(encryptedMessage);

        RSADE.DeleteKey();
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine($" Encrypted Text = {BitConverter.ToString(value: encryptedMessage)}");
        Console.WriteLine();
        Console.WriteLine($" Decrypted Text = {Encoding.Default.GetString(decryptedMessage)}");
    }


}
