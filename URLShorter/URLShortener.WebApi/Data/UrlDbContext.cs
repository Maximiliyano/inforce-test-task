using Microsoft.EntityFrameworkCore;
using URLShortener.WebApi.Data.Dtos;
using URLShortener.WebApi.Models;
using URLShortener.WebApi.Extensions;

namespace URLShortener.WebApi.Data;

public class UrlDbContext : DbContext
{
    public UrlDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<UserDto> Users { get; set; }
    
    public DbSet<UrlInfoDto> UrlInfo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Configure();
        modelBuilder.Seed();
    }
}