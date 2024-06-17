using AutoWebApp.Context;
using AutoWebApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpPost]
    public IActionResult SaveAuto(Auto auto)
    {
        MyDbContext dbctx = new MyDbContext();
        dbctx.Auto.Add(auto);
        dbctx.SaveChanges();
        return RedirectToAction("Index");
    }
    
    public IActionResult UpdateAuto(Auto auto)
    {
        MyDbContext dbctx = new MyDbContext();
        dbctx.Auto.Update(auto);
        dbctx.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult New()
    {
        return View();
    }

    public IActionResult Edit(Guid id)
    {
        MyDbContext dbctx = new MyDbContext();
        Auto auto = dbctx.Auto.FirstOrDefault(a => a.Autoid == id);
        return View(auto);
    }
    
    public IActionResult Delete(Guid id)
    {
        MyDbContext dbctx = new MyDbContext();
        Auto autoToDelete = dbctx.Auto.FirstOrDefault(a => a.Autoid == id);
        dbctx.Auto.Remove(autoToDelete);
        dbctx.SaveChanges();
        return RedirectToAction("Index");
    }
}