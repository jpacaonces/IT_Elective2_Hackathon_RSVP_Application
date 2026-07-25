using Microsoft.AspNetCore.Mvc;
using RSVPApp.Data;

namespace RSVPApp.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            var events = StaticData.Events
                .OrderBy(e => e.Date)
                .ToList();

            return View(events);
        }
    }
}
