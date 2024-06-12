using AutoWebApp.Context;
using AutoWebApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AutoWebApp.Controllers;

public class AutoController : Controller
{
    // GET
    public IActionResult Index()
    {
        //Repository ertsellen
        MyDbContext dbctx = new MyDbContext();
        //Alle Burger Items auslesen
        List<Auto> auto = dbctx.Auto.ToList();
        //Der View übergeben
        return View(auto);
    }
}