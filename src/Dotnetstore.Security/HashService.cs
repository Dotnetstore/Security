using System.Security.Cryptography;

namespace Dotnetstore.Security;

public sealed class HashService : IHashService
{
    string IHashService.Create256Hash(string input)
    {
        var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
        var hashBytes = SHA256.HashData(inputBytes);
        return Convert.ToBase64String(hashBytes);
    }

    string IHashService.Create512Hash(string input)
    {
        var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
        var hashBytes = SHA512.HashData(inputBytes);
        return Convert.ToBase64String(hashBytes);
    }

    string IHashService.Create1024Hash(string input)
    {
        var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);

        // SHA512 does not support 1024 bits directly, so we can use SHA512 and then hash the result again
        var firstHash = SHA512.HashData(inputBytes);
        var secondHash = SHA512.HashData(firstHash);

        var combinedHash = firstHash.Concat(secondHash).ToArray();
        return Convert.ToBase64String(combinedHash);
    }
}