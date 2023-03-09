using Microsoft.EntityFrameworkCore;
using URLShortener.WebApi.Data.Dtos;
using URLShortener.WebApi.Helpers;
using URLShortener.WebApi.Models;

namespace URLShortener.WebApi.Extensions;

public static class ModelBuilderExtensions
{
    public static void Configure(this ModelBuilder modelBuilder)
    {
    }
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var users = BuildListWithUsersDto(10);
        var urls = BuildListWithUrlInfo(10);
        
        modelBuilder.Entity<UserDto>().HasData(users);
        modelBuilder.Entity<UrlInfoDto>().HasData(urls);
    }

    private static IEnumerable<UrlInfoDto> BuildListWithUrlInfo(int urlsCount)
    {
        var urls = new List<UrlInfoDto>();

        for (var i = 1; i < urlsCount; i++)
        {
            urls.Add(BuildUrlInfo(i));
        }
        return urls;
    }

    private static IEnumerable<UserDto> BuildListWithUsersDto(int userCount)
    {
        var users = new List<UserDto>();
        
        for (var i = 0; i < userCount; i++)
        {
            users.Add(BuildUserDto(i, false));
        }
        users.Add(BuildUserDto(userCount + 1, true));
        
        return users;
    }

    private static UrlInfoDto BuildUrlInfo(int id) =>
        new()
        {
            Id = id + 1,
            OriginalString = $"https://{AppHelper.RandomizeCharacters(10).ToLower()}//{AppHelper.RandomizeNumber(4)}",
            ShortedString = $"https://{AppHelper.RandomizeCharacters(4).ToLower()}//{AppHelper.RandomizeNumber(4)}",
            CreatedBy = $"{AppHelper.RandomizeCharacters(6)} {AppHelper.RandomizeCharacters(6)}"
        };

    private static UserDto BuildUserDto(int id, bool permission) =>
        new()
        {
            Id = id + 1, 
            Name = $"First{AppHelper.RandomizeCharacters(4)} Sur{AppHelper.RandomizeCharacters(4)}",
            Email = $"{AppHelper.RandomizeCharacters(6).ToLower()}@gmail.com",
            Password = $"{AppHelper.RandomizeCharacters(6)}{AppHelper.RandomizeNumber(6)}",
            IsAdmin = permission
        };
}