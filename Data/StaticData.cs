using RSVPApp.Models;

namespace RSVPApp.Data
{
    // Per the instructor's requirement: no database, just static in-memory
    // lists that live for as long as the app is running.
    //
    // - Users: checked by the login page (leader's branch)
    // - Events: shown on the events page (member 2's branch)
    // - RsvpEntries: filled in by the RSVP form (member 3's branch)
    public static class StaticData
    {
        public static List<User> Users = new()
        {
            new User { Username = "admin",  Password = "admin123",  DisplayName = "Group Leader" },
            new User { Username = "member2", Password = "member2pw", DisplayName = "Member Two" },
            new User { Username = "member3", Password = "member3pw", DisplayName = "Member Three" }
        };

        public static List<Event> Events = new()
        {
            new Event
            {
                Id = 1,
                Name = "Freshmen Welcome Night",
                Description = "Kickoff mixer for new students with games and free food.",
                Date = new DateTime(2026, 8, 15, 18, 0, 0),
                Location = "Main Campus Gymnasium"
            },
            new Event
            {
                Id = 2,
                Name = "Capstone Project Showcase",
                Description = "Final year students present their capstone projects to the public.",
                Date = new DateTime(2026, 9, 5, 13, 0, 0),
                Location = "Engineering Building Atrium"
            },
            new Event
            {
                Id = 3,
                Name = "Alumni Homecoming",
                Description = "Annual homecoming celebration for alumni and current students.",
                Date = new DateTime(2026, 10, 20, 17, 30, 0),
                Location = "University Grounds"
            }
        };

        public static List<RsvpEntry> RsvpEntries = new();
    }
}
