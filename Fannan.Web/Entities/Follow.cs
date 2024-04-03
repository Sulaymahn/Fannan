using Microsoft.EntityFrameworkCore;

namespace Fannan.Web.Entities
{
    [PrimaryKey(nameof(FollowedId), nameof(FollowingUserId))]
    public class Follow
    {
        public int FollowedId { get; set; }
        public int FollowingUserId { get; set; }
        public User? Followed { get; set; }
        public User? FollowingUser { get; set; }
    }
}
