using Microsoft.EntityFrameworkCore;
using URLShortener.WebApi.Data;
using URLShortener.WebApi.Data.Dtos;

namespace URLShortener.WebApi.Services;

public class HomeService : BaseService
{
    public HomeService(UrlDbContext context) : base(context)
    {
    }

    public async Task<AboutDto> GetAbout() =>
        await _context.Abouts.FirstAsync();

    public async Task<AboutDto?> UpdateAbout(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return null;
        }
        
        var about = await _context.Abouts.FirstAsync();

        about.Text = text;
        about.UpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();
        return about;
    }
}