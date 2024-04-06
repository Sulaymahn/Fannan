using Fannan.Web.Entities;

namespace Fannan.Web.Models
{
    public class ProfileModel
    {
        public User User { get; set; } = null!;
        public List<Post> Posts { get; set; } = [];
        public bool CanFollow { get; set; }
    }
}
