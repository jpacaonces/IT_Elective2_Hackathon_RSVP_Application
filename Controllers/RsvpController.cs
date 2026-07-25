using Microsoft.AspNetCore.Mvc;

namespace RSVPApp.Controllers
{
    // STUB — this is the skeleton that lives on main.
    // Member 3's branch (branch-member3-rsvp-form) replaces this with the
    // real RSVP submission form and merges it back via pull request.
    public class RsvpController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return Content("RSVP form coming soon — built on member 3's branch.");
        }
    }
}
