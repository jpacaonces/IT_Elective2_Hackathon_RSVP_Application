using RSVPApp.Controllers;
using RSVPApp.Models;

namespace RSVPApp.Data
{
    public static class StaticData
    {
        public static List<Event> Events { get; set; } = HomeController.GetEventList();
        public static List<RsvpEntry> RsvpEntries { get; set; } = new List<RsvpEntry>();


        public static List<User> Users { get; set; } = new List<User>
{
    new User
    {
        ID = 1, // Change uppercase 'ID' to 'Id'
        Username = "admin",
        Email = "admin@example.com",
        Password = "password123",
        DisplayName = "Admin User"
    },
    new User
    {
        ID = 2,
        Username = "john_doe",
        Email = "john@example.com",
        Password = "password123",
        DisplayName = "John Doe"
    }
};
    }
}