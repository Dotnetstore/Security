using System.Security.Cryptography;
using System.Text;

namespace Dotnetstore.Security;

public sealed class AsymmetricEncryptionService : IAsymmetricEncryptionService
{
    private readonly RSA _rsa = RSA.Create();
    
    (byte[] EncryptedData, string PublicKey) IAsymmetricEncryptionService.Encrypt(string plainText)
    {
        var publicKey = _rsa.ToXmlString(false);
        var dataToEncrypt = Encoding.UTF8.GetBytes(plainText);
        var encryptedData = _rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.Pkcs1);
        
        return (encryptedData, publicKey);
    }

    string IAsymmetricEncryptionService.Decrypt(byte[] encryptedData, string privateKey)
    {
        _rsa.FromXmlString(privateKey);
        var decryptedData = _rsa.Decrypt(encryptedData, RSAEncryptionPadding.Pkcs1);
        
        return Encoding.UTF8.GetString(decryptedData);
    }
    
    string IAsymmetricEncryptionService.GetPrivateKey()
    {
        return _rsa.ToXmlString(true);
    }
}