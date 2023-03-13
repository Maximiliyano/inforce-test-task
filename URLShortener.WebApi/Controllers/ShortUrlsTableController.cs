using Microsoft.AspNetCore.Mvc;
using URLShortener.WebApi.Data.Dtos;
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
        return View(await _shortUrlsTableService.ViewTableWithShortUrls()); // TODO rewrite this page in angular
    }

    public IActionResult Edit()
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
    
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var urlInfoDto = await _shortUrlsTableService.GetById(id);
        return View(urlInfoDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UrlInfoDto urlInfoDto)
    {
        var updatedEntity = await _shortUrlsTableService.Update(urlInfoDto);

        if (updatedEntity is null)
        {
            ModelState.AddModelError("", "This url is exist in system!");
            return View();
        }
        
        return Index();
    }

    public IActionResult Index()
    {
        return RedirectToAction("ViewTable", "ShortUrlsTable");
    }
}