namespace Fannan.Web.Entities
{
    public class CommentReply
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public Comment? Comment { get; set; }
        public User? User { get; set; }
    }
}
