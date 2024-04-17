using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Opticron.Data;
using Opticron.Models;

namespace Opticron.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly OpticronContext _context;

    public HomeController(ILogger<HomeController> logger, OpticronContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var homeData = new HomeData();
        homeData.NavigationCards = _context.NavigationCards.ToList();
        homeData.SpecialOffers = _context.SpecialOffers.ToList();
        homeData.ProductCategories = _context.ProductCategories.ToList();
        return View(homeData);
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
