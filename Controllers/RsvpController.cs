using Microsoft.AspNetCore.Mvc;
using RSVPApp.Data;
using RSVPApp.Models;

namespace RSVPApp.Controllers
{
    // MEMBER 3'S BRANCH: feature/rsvp-form
    // Replaces the stub RsvpController from main with the real RSVP form.
    // Submitted RSVPs are appended to the static RsvpEntries list.
    public class RsvpController : Controller
    {
        [HttpGet]
        public IActionResult Create(int eventId)
        {
            var selectedEvent = StaticData.Events.FirstOrDefault(e => e.Id == eventId);
            if (selectedEvent is null)
            {
                return RedirectToAction("Index", "Event");
            }

            ViewBag.SelectedEvent = selectedEvent;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int eventId, string guestName, string email, int numberOfGuests, bool isAttending)
        {
            var selectedEvent = StaticData.Events.FirstOrDefault(e => e.Id == eventId);
            if (selectedEvent is null)
            {
                return RedirectToAction("Index", "Event");
            }

            if (string.IsNullOrWhiteSpace(guestName) || string.IsNullOrWhiteSpace(email))
            {
                ViewBag.SelectedEvent = selectedEvent;
                ViewBag.Error = "Please fill in your name and email.";
                return View();
            }

            var entry = new RsvpEntry
            {
                Id = StaticData.RsvpEntries.Count + 1,
                EventId = eventId,
                GuestName = guestName,
                Email = email,
                NumberOfGuests = numberOfGuests < 1 ? 1 : numberOfGuests,
                IsAttending = isAttending,
                SubmittedAt = DateTime.Now
            };

            StaticData.RsvpEntries.Add(entry);

            return RedirectToAction("Confirmation", new { id = entry.Id });
        }

        [HttpGet]
        public IActionResult Confirmation(int id)
        {
            var entry = StaticData.RsvpEntries.FirstOrDefault(r => r.Id == id);
            if (entry is null)
            {
                return RedirectToAction("Index", "Event");
            }

            var relatedEvent = StaticData.Events.FirstOrDefault(e => e.Id == entry.EventId);
            ViewBag.Event = relatedEvent;
            return View(entry);
        }
    }
}
