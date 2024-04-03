using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ngwmapp.Models;

namespace ngwmapp.Controllers;

public class ContactformController : Controller
{

    public ContactformController() { }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SubmitForm()
    {
        return View("FormSubmitted");
    }

}
