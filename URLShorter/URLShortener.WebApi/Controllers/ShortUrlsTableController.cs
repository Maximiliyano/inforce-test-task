using Microsoft.AspNetCore.Mvc;
using URLShortener.WebApi.Models;
using URLShortener.WebApi.Services;

namespace URLShortener.WebApi.Controllers;

public class ShortUrlsTableController : Controller
{
    private readonly ShortUrlsTableService _shortUrlsTableService;
    
    public ShortUrlsTableController(ShortUrlsTableService shortUrlsTableService)
    {
        _shortUrlsTableService = shortUrlsTableService;
    }
    
    public async Task<IActionResult> ViewTable()
    {
        return View(await _shortUrlsTableService.ViewTableWithShortUrls()); // TODO implement this page in angular
    }

    public IActionResult Edit() // TODO edit
    {
        return View();
    }

    public IActionResult Details()
    {
        return View();
    }

    public IActionResult Delete()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(UrlInfoDto urlInfoDto)
    {
        var url = await _shortUrlsTableService.CreateShortedUrl(urlInfoDto);

        if (url is null)
        {
            ModelState.AddModelError("", "This url is exist in system!");
            return View();
        }
        
        return Index();
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        await _shortUrlsTableService.Delete(int.Parse(id));
        return Index();
    }

    [HttpPost]
    public async Task<IActionResult> Details(int id) // TODO get correct id
    {
        var urlInfoDto = await _shortUrlsTableService.GetById(id);
        return View(urlInfoDto);
    }

    public IActionResult Index()
    {
        return RedirectToAction("ViewTable", "ShortUrlsTable");
    }
}