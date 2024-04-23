using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using ngwmapp.Models;

namespace ngwmapp.Controllers;

public class LanguageController : Controller
{

    public LanguageController() { }


    public IActionResult SetLanguage(string culture, string returnUrl)
    {
        if (!string.IsNullOrWhiteSpace(culture))
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
        }
        Console.WriteLine(returnUrl);
        Uri uri = new Uri(returnUrl);
        string path = uri.AbsolutePath.Trim('/');
        string[] segments = path.Split('/');

        string controllerSegment = segments.Length > 0 ? segments[0] : string.Empty;
        string viewSegment = segments.Length > 1 ? segments[1] : string.Empty;

        return RedirectToAction(viewSegment, controllerSegment);

    }

}
