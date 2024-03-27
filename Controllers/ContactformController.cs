using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ngwmapp.Models;

namespace ngwmapp.Controllers;

public class ContactformController : Controller
{
    private CustomerContext _context { get; set; }

    public ContactformController(CustomerContext customerContext)
    {
        _context = customerContext;
    }
    public IActionResult Index()
    {
        return View();
    }

}
