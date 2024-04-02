using Microsoft.EntityFrameworkCore;

namespace Fannan.Web.Entities
{
    [PrimaryKey(nameof(UserId), nameof(FollowingUserId))]
    public class Follow
    {
        public int UserId { get; set; }
        public int FollowingUserId { get; set; }
        public User? User { get; set; }
        public User? FollowingUser { get; set; }
    }
}
