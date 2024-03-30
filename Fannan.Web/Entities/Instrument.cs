namespace Fannan.Web.Entities
{
    public class Instrument
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<User> Users { get; set; } = [];
    }
}
