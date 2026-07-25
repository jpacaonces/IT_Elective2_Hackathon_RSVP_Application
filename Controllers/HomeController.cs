using Microsoft.AspNetCore.Mvc;

namespace RSVPApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
