using Microsoft.AspNetCore.Mvc;

namespace AutoWebApp.Controllers;

public class AutoController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}