using Microsoft.EntityFrameworkCore;
using URLShortener.WebApi.Data.Dtos;
using URLShortener.WebApi.Extensions;
using URLShortener.WebApi.Models;

namespace URLShortener.WebApi.Data;

public class UrlDbContext : DbContext
{
    public UrlDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<UserDto> Users { get; set; }
    public DbSet<UrlInfoDto> UrlInfo { get; set; }
    public DbSet<AboutDto> Abouts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
    }
}