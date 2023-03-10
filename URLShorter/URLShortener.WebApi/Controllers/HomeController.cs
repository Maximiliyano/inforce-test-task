using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using URLShortener.WebApi.Models;

namespace URLShortener.WebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About() // TODO admin will be edit this text
        {
            ViewData["Message"] = "An URL shortening algorithm in ASP.NET MVC Core typically involves generating a shorter unique identifier for a given URL and storing it in a database. When a user accesses the shortened URL, the application retrieves the original URL from the database and redirects the user to the original URL.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}