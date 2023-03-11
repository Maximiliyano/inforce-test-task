using Microsoft.EntityFrameworkCore;
using URLShortener.WebApi.Data;
using URLShortener.WebApi.Data.Dtos;
using URLShortener.WebApi.Enums;
using URLShortener.WebApi.Helpers;
using URLShortener.WebApi.Models;

namespace URLShortener.WebApi.Extensions;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var users = BuildListWithUsersDto();
        var urls = BuildListWithUrlInfo();
        var about = new List<AboutDto>
        {
            new()
            {
                Id = 1,
                Text = AppHelper.DefaultAboutText()
            }
        };
        
        modelBuilder.Entity<UserDto>().HasData(users);
        modelBuilder.Entity<UrlInfoDto>().HasData(urls);
        modelBuilder.Entity<AboutDto>().HasData(about);
    }

    private static IEnumerable<UrlInfoDto> BuildListWithUrlInfo() =>
        ShortUrlHelper._sites.Select((t, i) => BuildUrlInfo(i, t)).ToList();

    private static IEnumerable<UserDto> BuildListWithUsersDto() =>
        new List<UserDto>
        {
            BuildUserDto(0, UserRoles.User),
            BuildUserDto(1, UserRoles.Admin)
        };

    private static UrlInfoDto BuildUrlInfo(int id, string array) =>
        new()
        {
            Id = id + 1,
            OriginalString = array,
            ShortedString = ShortUrlHelper.ConcatString(array),
            CreatedBy = $"{AppHelper.RandomizeCharacters(6)} {AppHelper.RandomizeCharacters(6)}"
        };

    private static UserDto BuildUserDto(int id, UserRoles roles) =>
        new()
        {
            Id = id + 1, 
            Name = $"First{AppHelper.RandomizeCharacters(4)} Sur{AppHelper.RandomizeCharacters(4)}",
            Email = $"{AppHelper.RandomizeCharacters(7).ToLower()}@gmail.com",
            Password = $"{AppHelper.RandomizeCharacters(6)}{AppHelper.RandomizeNumber(6)}",
            Role = roles
        };
}