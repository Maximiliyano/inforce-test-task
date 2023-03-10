using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using URLShortener.WebApi.Models;

namespace URLShortener.WebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About() // TODO admin will be edit this text
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Save(About about)
        {
            _contextAccessor.HttpContext.Session.SetString("AboutMessage", about.Text);
            return RedirectToAction("About");
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}