using URLShortener.WebApi.Enums;

namespace URLShortener.WebApi.Helpers;

public abstract class AppHelper
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
    
    public static UserRoles GetRole(bool isAdmin) =>
        isAdmin ? UserRoles.Admin : UserRoles.User;

    public static string DefaultAboutText() =>
        "An URL shortening algorithm in ASP.NET MVC Core typically involves generating\"" +
        "a shorter unique identifier for a given URL and storing it in a database. \"" +
        "When a user accesses the shortened URL, the application retrieves the original URL from the database \"" +
        "and redirects the user to the original URL.";
}