using System.Diagnostics;
using AutoWebApp.Context;
using Microsoft.AspNetCore.Mvc;
using AutoWebApp.Models;

namespace AutoWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        MyDbContext dbctx = new MyDbContext();
        int AutoAnzahl = dbctx.Autos.Count();
        
        ViewData["TestData"] = AutoAnzahl.ToString();
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}