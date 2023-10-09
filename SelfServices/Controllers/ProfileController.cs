using Microsoft.AspNetCore.Mvc;

namespace SelfServices.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
