using FluentAssertions;

namespace Dotnetstore.Security.Tests;

public class HashServiceTests
{
    private readonly IHashService _hashService = new HashService();

    [Fact]
    public void Create256Hash_ShouldReturnConsistentHash()
    {
        // Arrange
        const string input = "test-input";

        // Act
        var hash1 = _hashService.Create256Hash(input);
        var hash2 = _hashService.Create256Hash(input);

        // Assert
        hash1.Should().Be(hash2);
    }

    [Fact]
    public void Create512Hash_ShouldReturnConsistentHash()
    {
        // Arrange
        const string input = "test-input";

        // Act
        var hash1 = _hashService.Create512Hash(input);
        var hash2 = _hashService.Create512Hash(input);

        // Assert
        hash1.Should().Be(hash2);
    }

    [Fact]
    public void Create1024Hash_ShouldReturnConsistentHash()
    {
        // Arrange
        const string input = "test-input";

        // Act
        var hash1 = _hashService.Create1024Hash(input);
        var hash2 = _hashService.Create1024Hash(input);

        // Assert
        hash1.Should().Be(hash2);
    }

    [Fact]
    public void Create256Hash_ShouldReturnDifferentHashForDifferentInputs()
    {
        // Arrange
        const string input1 = "test-input-1";
        const string input2 = "test-input-2";

        // Act
        var hash1 = _hashService.Create256Hash(input1);
        var hash2 = _hashService.Create256Hash(input2);

        // Assert
        hash1.Should().NotBe(hash2);
    }

    [Fact]
    public void Create512Hash_ShouldReturnDifferentHashForDifferentInputs()
    {
        // Arrange
        const string input1 = "test-input-1";
        const string input2 = "test-input-2";

        // Act
        var hash1 = _hashService.Create512Hash(input1);
        var hash2 = _hashService.Create512Hash(input2);

        // Assert
        hash1.Should().NotBe(hash2);
    }

    [Fact]
    public void Create1024Hash_ShouldReturnDifferentHashForDifferentInputs()
    {
        // Arrange
        const string input1 = "test-input-1";
        const string input2 = "test-input-2";

        // Act
        var hash1 = _hashService.Create1024Hash(input1);
        var hash2 = _hashService.Create1024Hash(input2);

        // Assert
        hash1.Should().NotBe(hash2);
    }
}