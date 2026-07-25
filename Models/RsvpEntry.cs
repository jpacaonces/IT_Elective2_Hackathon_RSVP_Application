namespace RSVPApp.Models
{
    public class RsvpEntry
    
    
        {
            public int Id { get; set; }
            public int EventId { get; set; }
            public string GuestName { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public int NumberOfGuests { get; set; }
            public bool IsAttending { get; set; }
            public DateTime SubmittedAt { get; set; }
        }
    }
