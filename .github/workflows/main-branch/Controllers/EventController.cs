using Microsoft.AspNetCore.Mvc;

namespace RSVPApp.Controllers
{
    // STUB — this is the skeleton that lives on main.
    // Member 2's branch (branch-member2-event-list) replaces this with the
    // real events listing page and merges it back via pull request.
    public class EventController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Content("Events page coming soon — built on member 2's branch.");
        }
    }
}
