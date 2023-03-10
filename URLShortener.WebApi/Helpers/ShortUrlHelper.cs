using System.Security.Cryptography;
using System.Text;

namespace URLShortener.WebApi.Helpers;

public abstract class ShortUrlHelper
{
    private const string AllowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public static string[] _sites = 
    {
        "https://mail.google.com/mail/u/0/?pli=1#inbox",
        "https://calendar.google.com/calendar/u/0/r",
        "https://github.com/Maximiliyano?tab=repositories",
        "https://learnenglish.britishcouncil.org/",
        "https://www.youtube.com/"
    };

    public static string ConcatString(string url)
    {
        var hash = MD5.HashData(Encoding.UTF8.GetBytes(url));
        var value = BitConverter.ToUInt32(hash, 0);

        var chars = new char[6];

        for (var i = 0; i < 6; i++)
        {
            chars[i] = AllowedChars[(int)(value % 62)];
            value /= 62;
        }

        return new string(chars);
    }
}