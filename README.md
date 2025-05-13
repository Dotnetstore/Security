# Dotnetstore.Security

`Dotnetstore.Security` is a NuGet package that provides utilities for cryptographic operations, including hashing, symmetric encryption, and asymmetric encryption. It is designed to integrate seamlessly with .NET applications and supports dependency injection via `IServiceCollection`.

## Features

- **Hashing Services**:
    - Generate consistent and secure hashes using SHA-256, SHA-512, and SHA-1024 algorithms.
    - Ensure data integrity and uniqueness.

- **Symmetric Encryption**:
    - Encrypt and decrypt data using the AES algorithm.
    - Securely manage encryption keys and initialization vectors (IV).

- **Asymmetric Encryption**:
    - Encrypt data using public keys and decrypt using private keys with RSA.
    - Generate and manage RSA key pairs.

## Installation

Install the package via NuGet:

```bash
dotnet add package Dotnetstore.Security
```

## Usage

### 1. Register Services

Add the `Dotnetstore.Security` services to your application's dependency injection container in `Startup.cs` or `Program.cs`:

```csharp
using Dotnetstore.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDotnetstoreSecurity();

var app = builder.Build();
```

### 2. Hashing Service

Use the `IHashService` to generate secure hashes:

```csharp
using Dotnetstore.Security;

public class Example
{
    private readonly IHashService _hashService;

    public Example(IHashService hashService)
    {
        _hashService = hashService;
    }

    public void GenerateHash()
    {
        var input = "example-data";
        var hash = _hashService.Create256Hash(input);
        Console.WriteLine($"SHA-256 Hash: {hash}");
    }
}
```

### 3. Symmetric Encryption Service

Use the `IEncryptionService` for AES-based encryption and decryption:

```csharp
using Dotnetstore.Security;

public class Example
{
    private readonly IEncryptionService _encryptionService;

    public Example(IEncryptionService encryptionService)
    {
        _encryptionService = encryptionService;
    }

    public void EncryptDecrypt()
    {
        var plainText = "Hello, World!";
        var (encryptedData, key, iv) = _encryptionService.Encrypt(plainText);
        var decryptedText = _encryptionService.Decrypt(encryptedData, key, iv);

        Console.WriteLine($"Decrypted Text: {decryptedText}");
    }
}
```

### 4. Asymmetric Encryption Service

Use the `IAsymmetricEncryptionService` for RSA-based encryption and decryption:

```csharp
using Dotnetstore.Security;

public class Example
{
    private readonly IAsymmetricEncryptionService _asymmetricEncryptionService;

    public Example(IAsymmetricEncryptionService asymmetricEncryptionService)
    {
        _asymmetricEncryptionService = asymmetricEncryptionService;
    }

    public void EncryptDecrypt()
    {
        var plainText = "Hello, World!";
        var privateKey = _asymmetricEncryptionService.GetPrivateKey();

        var (encryptedData, publicKey) = _asymmetricEncryptionService.Encrypt(plainText);
        var decryptedText = _asymmetricEncryptionService.Decrypt(encryptedData, privateKey);

        Console.WriteLine($"Decrypted Text: {decryptedText}");
    }
}
```

## API Reference

### `IHashService`

- `string Create256Hash(string input)`
- `string Create512Hash(string input)`
- `string Create1024Hash(string input)`

### `IEncryptionService`

- `(byte[] EncryptedData, byte[] Key, byte[] IV) Encrypt(string plainText)`
- `string Decrypt(byte[] encryptedData, byte[] key, byte[] iv)`

### `IAsymmetricEncryptionService`

- `(byte[] EncryptedData, string PublicKey) Encrypt(string plainText)`
- `string Decrypt(byte[] encryptedData, string privateKey)`
- `string GetPrivateKey()`

## Testing

Unit tests are included for all services to ensure correctness and reliability. Use the `Xunit` framework to run the tests.

## License

This package is licensed under the MIT License. See the `LICENSE` file for details.