using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ngwmapp.Models;

namespace ngwmapp.Controllers;

public class HomeController : Controller
{
    private CustomerContext _context { get; set; }

    public HomeController(CustomerContext customerContext)
    {
        _context = customerContext;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

}
