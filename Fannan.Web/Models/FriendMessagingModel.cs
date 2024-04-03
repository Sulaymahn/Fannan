using Fannan.Web.Entities;

namespace Fannan.Web.Models
{
    public class FriendMessagingModel
    {
        public List<Message> Messages { get; set; } = [];
        public List<User> Friends { get; set; } = [];
    }
}
