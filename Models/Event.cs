namespace RSVPApp.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string StatusBadge { get; set; } = string.Empty;
        public string StatusClass { get; set; } = string.Empty;
        public string BannerColor { get; set; } = string.Empty;
        public string DaysLeft { get; set; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Deadline { get; set; } = string.Empty;
        public string[] Tags { get; set; } = Array.Empty<string>();
        public int SeatsLeft { get; set; }
        public int BookedSeats { get; set; }
        public int TotalSeats { get; set; }
        public string Price { get; set; } = string.Empty;
        public bool IsFull { get; set; }
    }
}