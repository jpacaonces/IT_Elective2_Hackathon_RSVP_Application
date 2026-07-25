using Microsoft.AspNetCore.Mvc;

namespace RSVPApp.Controllers
{
    public class HomeController : Controller
    {
    
            public IActionResult Index()
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
                ViewBag.DisplayName = HttpContext.Session.GetString("DisplayName");

                return View();
            }
        }
    }

