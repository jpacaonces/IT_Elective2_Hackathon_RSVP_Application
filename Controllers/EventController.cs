using Microsoft.AspNetCore.Mvc;
using RSVPApp.Data;

namespace RSVPApp.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            var events = EventRepository.GetAll();
            return View(events);
        }
    }
}