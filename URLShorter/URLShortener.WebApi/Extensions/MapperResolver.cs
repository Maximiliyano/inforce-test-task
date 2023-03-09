using AutoMapper;
using URLShortener.WebApi.Data.Dtos;
using URLShortener.WebApi.Models;

namespace URLShortener.WebApi.Extensions;

public static class MapperResolver
{
    public static Mapper InitiateMapping()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<SignForm, UserDto>();
        });

        var mapper = new Mapper(config);
        return mapper;
    }
}