using RSVPApp.Models;

namespace RSVPApp.Data
{
    public static class EventRepository
    {
        private static readonly List<Event> _events = new()
        {
            new Event
            {
                Id = 1,
                Name = "Tech Conference",
                Description = "Annual technology conference",
                Date = new DateTime(2026, 8, 15, 9, 0, 0),
                Location = "Manila"
            },
            new Event
            {
                Id = 2,
                Name = "Music Festival",
                Description = "Live performances by local bands",
                Date = new DateTime(2026, 9, 10, 18, 0, 0),
                Location = "Taguig"
            }
        };

        public static List<Event> GetAll()
        {
            return _events;
        }

        public static void Add(Event newEvent)
        {
            newEvent.Id = _events.Max(e => e.Id) + 1;
            _events.Add(newEvent);
        }
    }
}