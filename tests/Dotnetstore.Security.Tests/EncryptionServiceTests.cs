using FluentAssertions;
using FluentAssertions.Execution;

namespace Dotnetstore.Security.Tests;

public class EncryptionServiceTests
{
    private readonly IEncryptionService _encryptionService = new EncryptionService();

    [Fact]
    public void EncryptDecrypt_ShouldReturnOriginalText()
    {
        // Arrange
        const string plainText = "Hello, World!";

        // Act
        var (encryptedData, key, iv) = _encryptionService.Encrypt(plainText);
        var decryptedText = _encryptionService.Decrypt(encryptedData, key, iv);

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
        var (encryptedData1, _, _) = _encryptionService.Encrypt(plainText1);
        var (encryptedData2, _, _) = _encryptionService.Encrypt(plainText2);

        // Assert
        Convert.ToBase64String(encryptedData1).Should().NotBe(Convert.ToBase64String(encryptedData2));
    }

    [Fact]
    public void Encrypt_ShouldProduceDifferentOutputForSameInputWithDifferentKeys()
    {
        // Arrange
        const string plainText = "Hello, World!";

        // Act
        var (encryptedData1, key1, iv1) = _encryptionService.Encrypt(plainText);
        var (encryptedData2, key2, iv2) = _encryptionService.Encrypt(plainText);

        // Assert
        using (new AssertionScope())
        {
            Convert.ToBase64String(encryptedData1).Should().NotBe(Convert.ToBase64String(encryptedData2));
            Convert.ToBase64String(key1).Should().NotBe(Convert.ToBase64String(key2));
            Convert.ToBase64String(iv1).Should().NotBe(Convert.ToBase64String(iv2));
        }
    }
}