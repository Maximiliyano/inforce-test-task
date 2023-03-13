using AutoMapper;
using Microsoft.EntityFrameworkCore;
using URLShortener.WebApi.Data;
using URLShortener.WebApi.Extensions;

namespace URLShortener.Tests.Apis;

public abstract class AppBaseApi
{
    private protected readonly IMapper _mapper;
    private protected readonly UrlDbContext _dbContext;
    
    protected AppBaseApi()
    {
        var dbContextOptions = new DbContextOptionsBuilder<UrlDbContext>()
            .UseInMemoryDatabase(databaseName: "URLShorterDB")
            .Options;
        
        _dbContext = new UrlDbContext(dbContextOptions);
        _mapper = MapperResolver.InitiateMapping();
    }
}