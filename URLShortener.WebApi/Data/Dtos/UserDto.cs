using URLShortener.WebApi.Enums;

namespace URLShortener.WebApi.Data.Dtos;

public class UserDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public UserRoles Role { get; set; }
}