using Microsoft.AspNetCore.Mvc;
using URLShortener.WebApi.Models;
using URLShortener.WebApi.Services;

namespace URLShortener.WebApi.Controllers;

public class AuthController : Controller
{
    private readonly AuthService _authService;
    
    public AuthController(AuthService authService)
    {
        _authService = authService;
    }
    
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LogForm model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        var result = await _authService.SignInAsync(model);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Invalid login attempt.");
        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await _authService.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}