using Microsoft.AspNetCore.Mvc;
using URLShortener.WebApi.Data.Dtos;
using URLShortener.WebApi.Helpers;
using URLShortener.WebApi.Services;

namespace URLShortener.WebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService _homeService;

        public HomeController(HomeService homeService)
        {
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(AboutDto aboutDto)
        {
            var updatedEntity = await _homeService.UpdateAbout(aboutDto.Text);

            if (updatedEntity is null)
            {
                ModelState.AddModelError("", "String couldn't to be empty!");
                return RedirectToAction("Edit");
            }

            return RedirectToAction("About");
        }

        public IActionResult Edit()
        {
            return View();
        }

        public async Task<IActionResult> Reset()
        {
            var entity = await _homeService.UpdateAbout(AppHelper.DefaultAboutText());

            if (entity is not null)
            {
                return RedirectToAction("About");
            }
            
            ModelState.AddModelError("", "String couldn't to be reset!");
            return RedirectToAction("Edit");
        }
    }
}