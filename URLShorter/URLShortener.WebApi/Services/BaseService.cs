using AutoMapper;
using URLShortener.WebApi.Data;
using URLShortener.WebApi.Extensions;

namespace URLShortener.WebApi.Services;

public abstract class BaseService
{
    private protected readonly UrlDbContext _context;
    private protected readonly IMapper _mapper;

    public BaseService(UrlDbContext context)
    {
        _context = context;
        _mapper = MapperResolver.InitiateMapping();
    }
}