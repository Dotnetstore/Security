namespace Dotnetstore.Security;

public interface IHashService
{
    string Create256Hash(string input);
    string Create512Hash(string input);
    string Create1024Hash(string input);
}