using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using URLShortener.WebApi.Services;

namespace URLShortener.WebApi.Controllers;

public class UserController : Controller
{
    private readonly UserService _userService;
    
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _userService.GetUserById(id));
    }
}