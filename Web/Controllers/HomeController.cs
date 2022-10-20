using System.Diagnostics;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

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

     public IActionResult Login()
    {
        return View(new LoginDto());
    }
    [HttpPost]
     public IActionResult Login(LoginDto loginDto)
    {
        if(ModelState.IsValid == false)return View(loginDto);
        if(loginDto.Username=="admin" && loginDto.Password == "123")
        {
            return RedirectToAction("Index","Home",new {area = "Admin"});
        } 
        return View(loginDto);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
