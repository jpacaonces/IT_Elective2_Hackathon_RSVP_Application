using Microsoft.AspNetCore.Mvc;
using RSVPApp.Models;

namespace RSVPApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.DisplayName = HttpContext.Session.GetString("DisplayName");

            return View();
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var events = GetEventList();
            return Json(events);
        }

        // Shared data source (Mock data or Database query)
        public static List<Event> GetEventList()
        {
            return new List<Event>
            {
                new Event
                {
                    Id = 1,
                    Title = "Future of AI in Product Design",
                    Category = "Technology",
                    StatusBadge = "Closing Soon",
                    StatusClass = "status-closing",
                    BannerColor = "#7c3aed",
                    DaysLeft = "in 18 days",
                    Host = "Priya Nair",
                    Date = "Aug 12, 2026 · 10:00 AM - 2:00 PM",
                    Location = "San Francisco, CA — Moscone Center West, H...",
                    Deadline = "RSVP by Aug 10, 2026",
                    Tags = new[] { "AI", "Product Design", "Workshop" },
                    SeatsLeft = 22,
                    BookedSeats = 98,
                    TotalSeats = 120,
                    Price = "Free",
                    IsFull = false
                },
                new Event
                {
                    Id = 2,
                    Title = "Startup Pitch Night — Summer Edition",
                    Category = "Business",
                    StatusBadge = "Full",
                    StatusClass = "status-full",
                    BannerColor = "#f59e0b",
                    DaysLeft = "in 24 days",
                    Host = "Marcus Webb",
                    Date = "Aug 18, 2026 · 6:30 PM - 9:30 PM",
                    Location = "New York, NY — General Assembly, Flatiron",
                    Deadline = "RSVP by Aug 16, 2026",
                    Tags = new[] { "Startups", "Pitch", "Networking" },
                    SeatsLeft = 0,
                    BookedSeats = 80,
                    TotalSeats = 80,
                    Price = "Free",
                    IsFull = true
                },
                new Event
                {
                    Id = 3,
                    Title = "Brand Identity Masterclass",
                    Category = "Design",
                    StatusBadge = "Open",
                    StatusClass = "status-open",
                    BannerColor = "#f43f5e",
                    DaysLeft = "in 28 days",
                    Host = "Camille Rousseau",
                    Date = "Aug 22, 2026 · 9:00 AM - 5:00 PM",
                    Location = "Austin, TX — The Long Center, Studio 2",
                    Deadline = "RSVP by Aug 20, 2026",
                    Tags = new[] { "Branding", "Design", "Full Day" },
                    SeatsLeft = 16,
                    BookedSeats = 24,
                    TotalSeats = 40,
                    Price = "$49",
                    IsFull = false
                },
                new Event
                {
                    Id = 4,
                    Title = "Growth Marketing Summit 2026",
                    Category = "Marketing",
                    StatusBadge = "Open",
                    StatusClass = "status-open",
                    BannerColor = "#0d9488",
                    DaysLeft = "in 42 days",
                    Host = "Jordan Kim",
                    Date = "Sep 5, 2026 · 8:00 AM - 6:00 PM",
                    Location = "Chicago, IL — McCormick Place, Lakeside",
                    Deadline = "RSVP by Sep 2, 2026",
                    Tags = new[] { "Growth", "Marketing", "Summit" },
                    SeatsLeft = 113,
                    BookedSeats = 187,
                    TotalSeats = 300,
                    Price = "$99",
                    IsFull = false
                },
                new Event
                {
                    Id = 5,
                    Title = "Mindful Leadership in Tech",
                    Category = "Health",
                    StatusBadge = "Open",
                    StatusClass = "status-open",
                    BannerColor = "#059669",
                    DaysLeft = "in 47 days",
                    Host = "Aisha Fontaine",
                    Date = "Sep 10, 2026 · 9:00 AM - 1:00 PM",
                    Location = "Seattle, WA — Chihuly Garden and Glass",
                    Deadline = "RSVP by Sep 8, 2026",
                    Tags = new[] { "Leadership", "Wellness", "Workshop" },
                    SeatsLeft = 17,
                    BookedSeats = 33,
                    TotalSeats = 50,
                    Price = "$29",
                    IsFull = false
                },
                new Event
                {
                    Id = 6,
                    Title = "Next.js & Edge Computing Deep Dive",
                    Category = "Technology",
                    StatusBadge = "Open",
                    StatusClass = "status-open",
                    BannerColor = "#4f46e5",
                    DaysLeft = "in 52 days",
                    Host = "Tobias Engel",
                    Date = "Sep 15, 2026 · 10:00 AM - 5:00 PM",
                    Location = "Remote / Online — Zoom Webinar",
                    Deadline = "RSVP by Sep 14, 2026",
                    Tags = new[] { "Next.js", "Edge", "Technical" },
                    SeatsLeft = 139,
                    BookedSeats = 61,
                    TotalSeats = 200,
                    Price = "Free",
                    IsFull = false
                },
                new Event
                {
                    Id = 7,
                    Title = "Women in Tech — Fall Networking Mixer",
                    Category = "Networking",
                    StatusBadge = "Closing Soon",
                    StatusClass = "status-closing",
                    BannerColor = "#e11d48",
                    DaysLeft = "in 57 days",
                    Host = "Lena Vasquez",
                    Date = "Sep 20, 2026 · 5:00 PM - 8:00 PM",
                    Location = "Boston, MA — Seaport Hotel, Harborview Room",
                    Deadline = "RSVP by Sep 18, 2026",
                    Tags = new[] { "Networking", "Diversity", "Evening" },
                    SeatsLeft = 6,
                    BookedSeats = 144,
                    TotalSeats = 150,
                    Price = "Free",
                    IsFull = false
                },
                new Event
                {
                    Id = 8,
                    Title = "Digital Illustration Bootcamp",
                    Category = "Arts",
                    StatusBadge = "Open",
                    StatusClass = "status-open",
                    BannerColor = "#d97706",
                    DaysLeft = "in 62 days",
                    Host = "Riku Tanaka",
                    Date = "Sep 25, 2026 · 9:00 AM - 5:00 PM",
                    Location = "Portland, OR — PNCA, Arlene Schnitzer Hall",
                    Deadline = "RSVP by Sep 23, 2026",
                    Tags = new[] { "Illustration", "Art", "Bootcamp" },
                    SeatsLeft = 18,
                    BookedSeats = 12,
                    TotalSeats = 30,
                    Price = "$149",
                    IsFull = false
                }
            };
        }
    }
}