using Microsoft.EntityFrameworkCore;
using URLShortener.WebApi.Data;
using URLShortener.WebApi.Data.Dtos;
using URLShortener.WebApi.Helpers;

namespace URLShortener.WebApi.Extensions;

public static class ModelBuilderExtensions
{
    public static void Configure(this ModelBuilder modelBuilder)
    {
    }
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var users = BuildListWithUsersDto(10);
        var urls = BuildListWithUrlInfo();
        
        modelBuilder.Entity<UserDto>().HasData(users);
        modelBuilder.Entity<UrlInfoDto>().HasData(urls);
    }

    private static IEnumerable<UrlInfoDto> BuildListWithUrlInfo() =>
        ShortUrlHelper._sites.Select((t, i) => BuildUrlInfo(i, t)).ToList();

    private static IEnumerable<UserDto> BuildListWithUsersDto(int userCount)
    {
        var users = new List<UserDto>();
        
        for (var i = 0; i < userCount; i++)
        {
            users.Add(BuildUserDto(i, false));
        }
        users.Add(BuildUserDto(userCount, true));
        
        return users;
    }

    private static UrlInfoDto BuildUrlInfo(int id, string array) =>
        new()
        {
            Id = id + 1,
            OriginalString = array,
            ShortedString = ShortUrlHelper.ConcatString(array),
            CreatedBy = $"{AppHelper.RandomizeCharacters(6)} {AppHelper.RandomizeCharacters(6)}"
        };

    private static UserDto BuildUserDto(int id, bool permission) =>
        new()
        {
            Id = id + 1, 
            Name = $"First{AppHelper.RandomizeCharacters(4)} Sur{AppHelper.RandomizeCharacters(4)}",
            Email = $"{AppHelper.RandomizeCharacters(7).ToLower()}@gmail.com",
            Password = $"{AppHelper.RandomizeCharacters(6)}{AppHelper.RandomizeNumber(6)}",
            Role = AppHelper.GetRole(permission)
        };
}