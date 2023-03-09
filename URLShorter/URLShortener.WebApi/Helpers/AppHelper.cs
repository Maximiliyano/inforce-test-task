using System.Security.Cryptography;

namespace URLShortener.WebApi.Helpers;

public class AppHelper
{
    private static readonly Random Random = new();

    public static int RandomizeNumber(int from = 1, int to = 100) =>
        Random.Next(from, to);

    public static string RandomizeCharacters(int lenght)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var stringChars = new char[lenght];
        for (var i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[Random.Next(chars.Length)];
        }

        return new string(stringChars);
    }
    
    public static byte[] GetRandomBytes(int length = 32)
    {
        using var randomNumberGenerator = new RNGCryptoServiceProvider();
        var salt = new byte[length];
        randomNumberGenerator.GetBytes(salt);

        return salt;
    }
}