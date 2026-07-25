using RSVPApp.Models;

namespace RSVPApp.Data
{
    public static class EventRepository
    {
        private static readonly List<Event> _events = new List<Event>
        {
         
        };

        public static IEnumerable<Event> GetAll()
        {
            return _events;
        }

        public static Event? GetById(int id)
        {
            return _events.FirstOrDefault(e => e.Id == id);
        }

        public static IEnumerable<Event> GetByCategory(string category)
        {
            return _events.Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }
    }
}