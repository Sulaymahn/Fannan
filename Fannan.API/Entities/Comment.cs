namespace Fannan.API.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public Post? Post { get; set; }
    }
}
