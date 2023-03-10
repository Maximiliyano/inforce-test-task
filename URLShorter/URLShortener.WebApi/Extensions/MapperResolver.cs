using AutoMapper;
using URLShortener.WebApi.Data.Dtos;
using URLShortener.WebApi.Helpers;
using URLShortener.WebApi.Models;

namespace URLShortener.WebApi.Extensions;

public static class MapperResolver
{
    public static Mapper InitiateMapping()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<SignForm, UserDto>()
                .ForMember(x => x.Role, 
                    o => o.MapFrom(i => AppHelper.GetRole(i.IsAdmin)));
        });

        var mapper = new Mapper(config);
        return mapper;
    }
}