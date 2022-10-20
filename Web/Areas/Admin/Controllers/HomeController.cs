using System.Diagnostics;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Areas.Admin.Controllers;
[Area("Admin")]
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
   

    
    public IActionResult Privacy()
    {
        return View();
    }

   
}
