namespace Dotnetstore.Security;

public interface IAsymmetricEncryptionService
{
    (byte[] EncryptedData, string PublicKey) Encrypt(string plainText);
    
    string Decrypt(byte[] encryptedData, string privateKey);
    
    string GetPrivateKey();
}