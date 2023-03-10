using URLShortener.WebApi.Models;

namespace URLShortener.WebApi.Builders;

public static class GlobalBuilders
{
    public static SignForm BuildSignForm() =>
        new()
        {
            Name = "TestUser", 
            Password = "123456", 
            ConfirmPassword = "123456", 
            Email = "test@example.com", 
            IsAdmin = false
        };
}