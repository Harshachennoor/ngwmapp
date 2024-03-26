using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ngwmapp.Models;

namespace ngwmapp.Controllers;

public class AccountController : Controller
{
    private CustomerContext _context { get; set; }

    public AccountController(CustomerContext customerContext)
    {
        _context = customerContext;
    }
    [HttpGet]
    public IActionResult LoginForm()
    {
        //Checks for Cookie
        if (Request.Cookies["UserID"] != null)
        {
            var customerID = Request.Cookies["UserID"];
            var customerDetails = _context.Customers.FirstOrDefault(c => c.CustomerId == customerID);
            ViewBag.CustomerName = customerDetails.FirstName;
            return View("SuccessLogin");

        }
        //Checks for Session
        if (HttpContext.Session.GetString("UserId") != null)
        {
            var customerID = HttpContext.Session.GetString("UserId");
            var customerDetails = _context.Customers.FirstOrDefault(c => c.CustomerId == customerID);
            ViewBag.CustomerName = customerDetails.FirstName;
            return View("SuccessLogin");
        }
        else
        {
            return View("LoginForm");
        }
    }

    [HttpGet]
    public IActionResult RegisterForm()
    {
        var numberOfRecords = _context.Customers.ToList().Count;
        ViewBag.CurrentID = numberOfRecords + 1;
        Console.WriteLine(ViewBag.CurrentID);
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult LoginForm(LoginViewModel l)
    {
        var currentLogin = l;
        if (ModelState.IsValid)
        {
            var customer = _context.Customers.FirstOrDefault(e => e.Email == l.Email);
            if (customer != null)
            {
                bool doesPasswordMatch = BCrypt.Net.BCrypt.Verify(l.Password, customer.Password);
                if (doesPasswordMatch)
                {
                    //Creating Cookie if user checks RememberMe
                    if (l.RememberMe)
                    {
                        CookieOptions op = new CookieOptions();
                        op.Expires = DateTime.Now.AddDays(15);
                        Response.Cookies.Append("UserID", customer.CustomerId, op);
                        ViewBag.CustomerName = customer.FirstName;
                        return View("SuccessLogin");
                    }
                    //Creating Session if user does not select RememberMe
                    HttpContext.Session.SetString("UserId", customer.CustomerId);
                    ViewBag.CustomerName = customer.FirstName;
                    return View("SuccessLogin");
                }
                else
                {
                    ModelState.AddModelError(nameof(l.Password), "Invalid password");
                    return View(l);
                }
            }
            else
            {
                ModelState.AddModelError(nameof(l.Email), "Email is not registered");
                return View(l);
            }
        }
        return View(l);
    }

    [HttpPost]
    public IActionResult RegisterForm(Customer c)
    {
        Console.WriteLine(c.CustomerId);
        if (ModelState.IsValid)
        {
            var customer = _context.Customers.FirstOrDefault(e => e.Email == c.Email);
            if (customer == null)
            {
                int saltRounds = 10;
                var hashPassword = BCrypt.Net.BCrypt.HashPassword(c.Password, workFactor: saltRounds);
                c.Password = hashPassword;

                _context.Customers.Add(c);
                _context.SaveChanges();
                return View("SuccessLogin");
            }
            else
            {
                ModelState.AddModelError(nameof(c.Email), "Email already Exists");
            }
        }
        return View("RegisterForm", c);
    }
    [HttpPost]
    public IActionResult LogOut()
    {
        //Clearing Session and Cookies
        HttpContext.Session.Clear();
        Response.Cookies.Delete("UserID");
        return View("Index");
    }

}