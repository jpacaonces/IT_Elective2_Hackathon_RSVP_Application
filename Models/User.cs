namespace RSVPApp.Models
{
    public class User
    {

        public int ID { get; set; } = 0;
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string DisplayName { get; set; } = "";
        public string Email { get; set; } = "";
    }
}