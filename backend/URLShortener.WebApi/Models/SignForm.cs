using System.ComponentModel.DataAnnotations;

namespace URLShortener.WebApi.Models;

public sealed class SignForm
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    [RegularExpression("^[A-Za-z0-9\\._\\-]+@([a-zA-Z0-9\\-]+\\.{1})+[a-zA-Z0-9\\-]{2,}$", ErrorMessage = "The email field must be for example: test@gmail.com")]
    public string Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required]
    [Compare("Password", ErrorMessage = "Confirm your password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
    
    public bool IsAdmin { get; set; }
}