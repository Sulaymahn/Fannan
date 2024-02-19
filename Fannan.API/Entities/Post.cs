namespace Fannan.API.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
        public List<Comment> Comments { get; set; } = [];
        public List<Like> Likes { get; set; } = [];
        public DateTime Date { get; set; }
        public User? User { get; set; }
    }
}
