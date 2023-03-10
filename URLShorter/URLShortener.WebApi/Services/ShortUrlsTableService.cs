using Microsoft.EntityFrameworkCore;
using URLShortener.WebApi.Data;
using URLShortener.WebApi.Data.Dtos;
using URLShortener.WebApi.Helpers;

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
        var name = userName ?? urlInfoDto.CreatedBy;

        var urlInfoEntity = await _context.UrlInfo.FirstOrDefaultAsync(u => u.OriginalString == urlInfoDto.OriginalString);

        if (urlInfoEntity is not null)
        {
            return null;
        }

        var shortedString = ShortUrlHelper.ConcatString(urlInfoDto.OriginalString);

        var urlInfo = BuildUrlInfoDto(urlInfoDto.OriginalString, shortedString, name);

        await _context.UrlInfo.AddAsync(urlInfo);
        await _context.SaveChangesAsync();

        urlInfo.Id = _context.UrlInfo.FirstAsync(u => u.CreatedBy == name).Id;
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

    public async Task<UrlInfoDto?> Update(UrlInfoDto urlInfoDto)
    {
        var entity = await _context.UrlInfo.FirstOrDefaultAsync(u => u.Id == urlInfoDto.Id);
        var entity1 = await _context.UrlInfo.FirstOrDefaultAsync(u => u.OriginalString == urlInfoDto.OriginalString);

        if (entity is null || entity1 is not null)
            return null;

        entity.UpdatedAt = DateTime.Now;
        entity.OriginalString = urlInfoDto.OriginalString;
        entity.ShortedString = ShortUrlHelper.ConcatString(urlInfoDto.OriginalString);

        await _context.SaveChangesAsync();

        return entity;
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