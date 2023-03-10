using Microsoft.EntityFrameworkCore;
using URLShortener.WebApi.Data;
using URLShortener.WebApi.Data.Dtos;
using URLShortener.WebApi.Models;

namespace URLShortener.WebApi.Services;

public class UserService : BaseService
{
    public UserService(UrlDbContext dbContext) : base(dbContext) { }

    public async Task<UserDto?> Create(SignForm signForm)
    {
        var entity = await _context.Users.FirstOrDefaultAsync(u => u.Email == signForm.Email);

        if (entity is not null)
            return null;

        var user = _mapper.Map<UserDto>(signForm);

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        user.Id = _context.Users.FirstAsync(u => u.Name == signForm.Name).Id;
        return user;
    }

    public async Task<UserDto> GetUserById(int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (user is null)
            throw new ArgumentException($"Entity with ID: {userId} - not found!");
        
        return user;
    }

    public async Task<UserDto> GetUserByEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (user is null)
            throw new ArgumentException($"Entity with email: {email} - not found!");
        
        return user;
    }
}