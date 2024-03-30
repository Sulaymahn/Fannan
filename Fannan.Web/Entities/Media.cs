namespace Fannan.Web.Entities
{
    public class Media
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[] Data { get; set; } = [];
        public DateTime DateAdded { get; set; }
    }
}
