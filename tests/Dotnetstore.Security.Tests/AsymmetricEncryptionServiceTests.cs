using Dotnetstore.Security;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Security.Tests;

public class AsymmetricEncryptionServiceTests
{
    private readonly IAsymmetricEncryptionService _asymmetricEncryptionService = new AsymmetricEncryptionService();

    [Fact]
    public void EncryptDecrypt_ShouldReturnOriginalText()
    {
        // Arrange
        const string plainText = "Hello, World!";
        var privateKey = _asymmetricEncryptionService.GetPrivateKey();

        // Act
        var (encryptedData, _) = _asymmetricEncryptionService.Encrypt(plainText);
        var decryptedText = _asymmetricEncryptionService.Decrypt(encryptedData, privateKey);

        // Assert
        plainText.Should().Be(decryptedText);
    }

    [Fact]
    public void Encrypt_ShouldProduceDifferentOutputForDifferentInputs()
    {
        // Arrange
        const string plainText1 = "Hello, World!";
        const string plainText2 = "Goodbye, World!";

        // Act
        var (encryptedData1, _) = _asymmetricEncryptionService.Encrypt(plainText1);
        var (encryptedData2, _) = _asymmetricEncryptionService.Encrypt(plainText2);

        // Assert
        encryptedData1.Should().NotBeEquivalentTo(encryptedData2);
    }

    [Fact]
    public void Encrypt_ShouldProduceDifferentOutputForSameInputWithDifferentKeys()
    {
        // Arrange
        const string plainText = "Hello, World!";
        IAsymmetricEncryptionService service1 = new AsymmetricEncryptionService();
        IAsymmetricEncryptionService service2 = new AsymmetricEncryptionService();

        // Act
        var (encryptedData1, _) = service1.Encrypt(plainText);
        var (encryptedData2, _) = service2.Encrypt(plainText);

        // Assert
        encryptedData1.Should().NotBeEquivalentTo(encryptedData2);
    }
}