using System.Security.Policy;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using URLShortener.WebApi.Data;
using URLShortener.WebApi.Helpers;
using URLShortener.WebApi.Models;

namespace URLShortener.WebApi.Services;

public class ShortUrlsTableService : BaseService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public ShortUrlsTableService(UrlDbContext context, IHttpContextAccessor contextAccessor) : base(context)
    {
        _contextAccessor = contextAccessor;
    }

    public async Task<IEnumerable<UrlInfoDto>> ViewTableWithShortUrls() =>
        await _context.UrlInfo.ToListAsync();

    public async Task<UrlInfoDto?> CreateShortedUrl(UrlInfoDto urlInfoDto)
    {
        var userName = _contextAccessor.HttpContext.Session.GetString("Name");

        var urlInfoEntity = await _context.UrlInfo.FirstOrDefaultAsync(u => u.OriginalString == urlInfoDto.OriginalString);

        if (urlInfoEntity is not null)
        {
            return null;
        }

        var shortedString = ShortUrlHelper.ConcatString(urlInfoDto.OriginalString);

        var urlInfo = BuildUrlInfoDto(urlInfoDto.OriginalString, shortedString, userName);

        await _context.UrlInfo.AddAsync(urlInfo);
        await _context.SaveChangesAsync();
        
        return urlInfo;
    }

    public async Task<bool> Delete(int id)
    {
        var urlInfoDto = await GetById(id);

        if (urlInfoDto is null)
        {
            return false;
        }
        
        _context.UrlInfo.Remove(urlInfoDto);
        await _context.SaveChangesAsync();
        
        return true;
    }
    
    public async Task<UrlInfoDto?> GetById(int id) =>
        await _context.UrlInfo.FirstOrDefaultAsync(u => u.Id == id);
    
    private static UrlInfoDto BuildUrlInfoDto(string originalString, string shortedString, string createdBy) =>
        new()
        {
            OriginalString = originalString,
            ShortedString = shortedString,
            CreatedBy = createdBy
        };
}