using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using URLShortener.WebApi.Data;
using URLShortener.WebApi.Models;

namespace URLShortener.WebApi.Services;

public class AuthService : BaseService
{
    private readonly IHttpContextAccessor _session;

    public AuthService(UrlDbContext context, IHttpContextAccessor contextAccessor) : base(context)
    {
        _session = contextAccessor;
    }

    public async Task<IdentityResult> SignInAsync(LogForm dto)
    {
        var userDto = await _context.Users.FirstOrDefaultAsync(u => 
            u.Email == dto.Email && 
            u.Password == dto.Password);

        if (userDto is null)
        {
            return IdentityResult.Failed();
        }

        _session.HttpContext.Session.SetInt32("Id", userDto.Id);
        _session.HttpContext.Session.SetString("Name", userDto.Name);
        _session.HttpContext.Session.Set("IsAdmin", BitConverter.GetBytes(userDto.IsAdmin));

        return IdentityResult.Success;
    }

    public async Task SignOutAsync()
    {
        // TODO sign out account
    }
}