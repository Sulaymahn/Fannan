namespace Fannan.Web.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public DateTime Joined { get; set; }
        public List<User> Friends { get; set; } = [];
        public List<Message> Messages { get; set; } = [];
        public List<Instrument> Instruments { get; set; } = [];
        public List<Genre> Genres { get; set; } = [];
        public List<Like> Likes { get; set; } = [];
    }
}
