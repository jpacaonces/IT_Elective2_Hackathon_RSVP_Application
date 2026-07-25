using Microsoft.AspNetCore.Mvc;
using RSVPApp.Data;

namespace RSVPApp.Controllers
{
    // MEMBER 2'S BRANCH: feature/event-list
    // Replaces the stub EventController from main with the real events page,
    // reading straight from the static Events list (no database).
    public class EventController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var events = StaticData.Events.OrderBy(e => e.Date).ToList();
            return View(events);
        }
    }
}
