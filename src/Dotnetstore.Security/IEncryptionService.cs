namespace Dotnetstore.Security;

public interface IEncryptionService
{
    (byte[] EncryptedData, byte[] Key, byte[] IV) Encrypt(string plainText);
    
    string Decrypt(byte[] encryptedData, byte[] key, byte[] iv);
}