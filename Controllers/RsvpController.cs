using Microsoft.AspNetCore.Mvc;
using RSVPApp.Data;
using RSVPApp.Models;

namespace RSVPApp.Controllers
{
    public class RsvpController : Controller
    {

        // SHOW RSVP FORM
        [HttpGet]
        public IActionResult Create(int eventId)
        {
            // Require login
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                var returnUrl = Url.Action("Create", "Rsvp", new { eventId = eventId });
                return RedirectToAction("Login", "Account", new { returnUrl = returnUrl });
            }

            var selectedEvent = StaticData.Events
                .FirstOrDefault(e => e.Id == eventId);


            if (selectedEvent == null)
            {
                return RedirectToAction("Index", "Events");
            }


            ViewBag.SelectedEvent = selectedEvent;

            return View();
        }




        // SUBMIT RSVP
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            int eventId,
            string guestName,
            string email,
            int numberOfGuests,
            bool isAttending)
        {

            // Ensure user is authenticated
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                var returnUrl = Url.Action("Create", "Rsvp", new { eventId = eventId });
                return RedirectToAction("Login", "Account", new { returnUrl = returnUrl });
            }

            var selectedEvent = StaticData.Events
                .FirstOrDefault(e => e.Id == eventId);



            if (selectedEvent == null)
            {
                return RedirectToAction("Index", "Events");
            }




            if (string.IsNullOrWhiteSpace(guestName) ||
                string.IsNullOrWhiteSpace(email))
            {

                ViewBag.SelectedEvent = selectedEvent;

                ViewBag.Error =
                    "Please enter your name and email.";

                return View();

            }




            var entry = new RsvpEntry
            {

                Id = StaticData.RsvpEntries.Count + 1,

                EventId = eventId,

                GuestName = guestName,

                Email = email,

                NumberOfGuests =
                    numberOfGuests < 1
                    ? 1
                    : numberOfGuests,


                IsAttending = isAttending,


                SubmittedAt = DateTime.Now

            };




            StaticData.RsvpEntries.Add(entry);



            return RedirectToAction(
                "Confirmation",
                new { id = entry.Id }
            );

        }






        // CONFIRMATION PAGE
        [HttpGet]
        public IActionResult Confirmation(int id)
        {

            var entry = StaticData.RsvpEntries
                .FirstOrDefault(r => r.Id == id);



            if (entry == null)
            {
                return RedirectToAction("Index", "Events");
            }




            var relatedEvent = StaticData.Events
                .FirstOrDefault(e => e.Id == entry.EventId);



            ViewBag.Event = relatedEvent;



            return View(entry);

        }

    }
}