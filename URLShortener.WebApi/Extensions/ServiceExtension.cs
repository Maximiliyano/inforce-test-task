using Microsoft.AspNetCore.Authentication.Cookies;
using URLShortener.WebApi.Services;

namespace URLShortener.WebApi.Extensions;

public static class ServiceExtension
{
    public static void RegisterCustomServices(this IServiceCollection services)
    {
        services.AddScoped<AuthService>();
        services.AddScoped<UserService>();
        services.AddScoped<ShortUrlsTableService>();
    }
    
    public static void RegisterCustomSingletons(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }

    public static void RegisterAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);

        services.AddHttpContextAccessor();
    }
}