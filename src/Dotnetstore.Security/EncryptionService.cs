using System.Security.Cryptography;

namespace Dotnetstore.Security;

public sealed class EncryptionService : IEncryptionService
{
    (byte[] EncryptedData, byte[] Key, byte[] IV) IEncryptionService.Encrypt(string plainText)
    {
        using var aes = Aes.Create();
        aes.GenerateKey();
        aes.GenerateIV();

        using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream();
        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        using (var writer = new StreamWriter(cs))
        {
            writer.Write(plainText);
        }

        return (ms.ToArray(), aes.Key, aes.IV);
    }

    string IEncryptionService.Decrypt(byte[] encryptedData, byte[] key, byte[] iv)
    {
        using var aes = Aes.Create();
        using var decryptor = aes.CreateDecryptor(key, iv);
        using var ms = new MemoryStream(encryptedData);
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var reader = new StreamReader(cs);

        return reader.ReadToEnd();
    }
}