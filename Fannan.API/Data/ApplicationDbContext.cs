using Fannan.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fannan.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<CommentReply> CommentReplies => Set<CommentReply>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Instrument> Instruments => Set<Instrument>();
        public DbSet<Like> Likes => Set<Like>();
        public DbSet<Media> Medias => Set<Media>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<Post> Posts => Set<Post>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {
        
        }
    }
}
