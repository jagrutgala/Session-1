using Microsoft.AspNetCore.Mvc;
using BoilerDemo.Services;
using Microsoft.AspNetCore.Http.Extensions;
using BoilerDemo.Enums;
using BoilerDemo.Exceptions;
using ColorPaletteWeb.Models;

namespace BoilerDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IServerNameService _serverNameService;

    public HomeController(
        ILogger<HomeController> logger,
        IServerNameService serverNameService
    )
    {
        _logger = logger;
        _serverNameService = serverNameService;
    }

    public IActionResult Index( int accepted)
    {
        // check if policy was accepted
        if ( (PolicyChoice)accepted == PolicyChoice.Accepted)
        {
            _logger.LogInformation( $"{HttpContext.Request.GetDisplayUrl()} was accessed" );
            ViewBag.ServerName = _serverNameService.GetServerName();
            return View();
        }
        throw new PolicyNotAcceptedError();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Sample()
    {
        Item[] items = new Item[3];
        return View(items);
    }

    [HttpPost]
    public IActionResult Sample(Item[] items)
    {
        return RedirectToAction("Sample");
    }

}
