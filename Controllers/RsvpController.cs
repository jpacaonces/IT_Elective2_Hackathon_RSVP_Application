using Microsoft.AspNetCore.Mvc;
using RSVPApp.Data;
using RSVPApp.Models;

namespace RSVPApp.Controllers
{
    public class RsvpController : Controller
    {
        // ==========================================
        // SHOW RSVP FORM
        // ==========================================
        [HttpGet]
        public IActionResult Create(int eventId)
        {
            // Ensure user is logged in
            if (!IsUserAuthenticated(out var returnUrl, eventId))
            {
                return RedirectToAction("Login", "Account", new { returnUrl });
            }

            // Find requested event (fallback to first event if default/invalid ID provided)
            var selectedEvent = StaticData.Events.FirstOrDefault(e => e.Id == eventId)
                                ?? StaticData.Events.FirstOrDefault();

            if (selectedEvent == null)
            {
                TempData["Error"] = "No events available to RSVP for.";
                return RedirectToAction("Index", "Events");
            }

            ViewBag.SelectedEvent = selectedEvent;

            // Pre-fill user details from session if available
            ViewBag.UserDisplayName = HttpContext.Session.GetString("DisplayName");

            return View();
        }

        // ==========================================
        // SUBMIT RSVP
        // ==========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            int eventId,
            string guestName,
            string email,
            int numberOfGuests,
            bool isAttending)
        {
            // Ensure user is logged in
            if (!IsUserAuthenticated(out var returnUrl, eventId))
            {
                return RedirectToAction("Login", "Account", new { returnUrl });
            }

            var selectedEvent = StaticData.Events.FirstOrDefault(e => e.Id == eventId);

            if (selectedEvent == null)
            {
                TempData["Error"] = "Invalid event selected.";
                return RedirectToAction("Index", "Events");
            }

            // Basic validation
            if (string.IsNullOrWhiteSpace(guestName) || string.IsNullOrWhiteSpace(email))
            {
                ViewBag.SelectedEvent = selectedEvent;
                ViewBag.Error = "Please enter your name and email address.";
                return View();
            }

            // Create new RSVP entry
            var entry = new RsvpEntry
            {
                Id = StaticData.RsvpEntries.Count > 0 ? StaticData.RsvpEntries.Max(r => r.Id) + 1 : 1,
                EventId = eventId,
                GuestName = guestName,
                Email = email,
                NumberOfGuests = numberOfGuests < 1 ? 1 : numberOfGuests,
                IsAttending = isAttending,
                SubmittedAt = DateTime.Now
            };

            StaticData.RsvpEntries.Add(entry);

            TempData["Success"] = "Your RSVP has been submitted successfully!";
            return RedirectToAction("Confirmation", new { id = entry.Id });
        }

        // ==========================================
        // CONFIRMATION PAGE
        // ==========================================
        [HttpGet]
        public IActionResult Confirmation(int id)
        {
            var entry = StaticData.RsvpEntries.FirstOrDefault(r => r.Id == id);

            if (entry == null)
            {
                TempData["Error"] = "RSVP record not found.";
                return RedirectToAction("Index", "Events");
            }

            var relatedEvent = StaticData.Events.FirstOrDefault(e => e.Id == entry.EventId);
            ViewBag.Event = relatedEvent;

            return View(entry);
        }

        // ==========================================
        // HELPER METHODS
        // ==========================================
        private bool IsUserAuthenticated(out string returnUrl, int eventId)
        {
            var username = HttpContext.Session.GetString("Username");
            returnUrl = Url.Action("Create", "Rsvp", new { eventId }) ?? "/";
            return !string.IsNullOrEmpty(username);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            // Fetch event details by 'id' from database/service here
            ViewData["EventId"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Confirm(int id)
        {
            // Process RSVP logic here (save to DB, send confirmation email)
            TempData["SuccessMessage"] = "Your spot has been reserved!";
            return RedirectToAction("Details", new { id });
        }
    }
}