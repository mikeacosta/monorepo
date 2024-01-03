// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;
using AES;

AES_CBC();

static void AES_CBC()
{
    const string textToEncrypt = "If at first you don’t succeed; call it version 1.0";
    
    // 256-bit encryption key
    var key = RandomNumberGenerator.GetBytes(32);
    
    // 128-bit initialization vector
    var iv =  RandomNumberGenerator.GetBytes(16);
    
    // CipherMode = (default) cipher block chaining (CBC)
    // PaddingMode = (default) PKCS7
    
    var encrypted = AesEncryption.Encrypt(Encoding.UTF8.GetBytes(textToEncrypt), key, iv);
    var decrypted = AesEncryption.Decrypt(encrypted, key, iv);

    var decryptedMessage = Encoding.UTF8.GetString(decrypted);

    Console.WriteLine("AES Encryption in .NET");
    Console.WriteLine("------------------------------------");
    Console.WriteLine();
    Console.WriteLine("Plain Text = " + textToEncrypt);
    Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(encrypted));
    Console.WriteLine("Decrypted Text = " + decryptedMessage);    
}