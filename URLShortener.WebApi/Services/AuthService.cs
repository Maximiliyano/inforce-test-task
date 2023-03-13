using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using URLShortener.WebApi.Data;
using URLShortener.WebApi.Data.Dtos;
using URLShortener.WebApi.Models;

namespace URLShortener.WebApi.Services;

public class AuthService : BaseService
{
    private readonly IHttpContextAccessor _session;

    public AuthService(
        UrlDbContext context, IHttpContextAccessor contextAccessor) : base(context)
    {
        _session = contextAccessor;
    }

    public async Task SignInAsync(UserDto userDto)
    {
        _session.HttpContext.Session.SetInt32("Id", userDto.Id);
        _session.HttpContext.Session.SetString("Name", userDto.Name);
        _session.HttpContext.Session.SetString("Role", userDto.Role.ToString());
    }

    public async Task SignOutAsync()
    {
        _session.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        _session.HttpContext.Session.Clear();
    }

    public async Task<UserDto?> ValidateUserCredentials(LogForm logForm)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == logForm.Email && u.Password == logForm.Password);
        return user;
    }
}