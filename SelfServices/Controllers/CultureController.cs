using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace SelfServices.Controllers
{
    public class CultureController : Controller
    {
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
            return LocalRedirect(returnUrl);
        }

        [HttpGet]
        public JsonResult SetCulture(string culture)
        {
            var cookie = Request.Cookies["_culture"];
            if (cookie != null)
            {
                Response.Cookies.Delete("_culture");
                var cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Append("_culture", culture, cookieOptions);
            }
            else
            {
                var cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Append("_culture", culture, cookieOptions);
            }

            if (culture == "ar-JO")
                ViewData["lang"] = 2;
            else
                ViewData["lang"] = 1;

            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            List<string> li = new List<string>();
            li.Add(culture);
            return new JsonResult(li);

        }

    }
}
