namespace Fannan.API.Entities
{
    public class CommentReply
    {
        public int Id { get; set; }
        public int CommmentId { get; set; }
        public string Content {  get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public Comment? Commment { get; set; }
    }
}
