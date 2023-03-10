using Microsoft.AspNetCore.Mvc;
using URLShortener.WebApi.Models;
using URLShortener.WebApi.Services;

namespace URLShortener.WebApi.Controllers;

public class RegisterController : Controller
{
    private readonly UserService _userService;
    private readonly AuthService _authService;
    private readonly IHttpContextAccessor _session;

    public RegisterController(UserService userService, AuthService authService, IHttpContextAccessor contextAccessor)
    {
        _userService = userService;
        _authService = authService;
        _session = contextAccessor;
    }

    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignForm signForm)
    {
        if (ModelState.IsValid)
        {
            var user = await _userService.Create(signForm);

            if (user is null)
            {
                ModelState.AddModelError("", "Account with the same name is already registered");
                return View(signForm);
            }
            
            await _authService.SignInAsync(user);
            return RedirectToAction("Index", "Home");
        }
        return View(signForm);
    }
}