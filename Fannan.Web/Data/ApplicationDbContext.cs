using Fannan.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fannan.Web.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : DbContext(opt)
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Instrument>().HasData(
                new Instrument { Id = 1, Name = "Guitar" },
                new Instrument { Id = 2, Name = "Piano" },
                new Instrument { Id = 3, Name = "Trumper" },
                new Instrument { Id = 4, Name = "Drum" },
                new Instrument { Id = 5, Name = "Maracas" },
                new Instrument { Id = 6, Name = "Keyboard" },
                new Instrument { Id = 7, Name = "Cymbal" },
                new Instrument { Id = 8, Name = "Bagpipe" },
                new Instrument { Id = 9, Name = "Saxophone" },
                new Instrument { Id = 10, Name = "Violin" },
                new Instrument { Id = 11, Name = "Tambourine" },
                new Instrument { Id = 12, Name = "Banjo" },
                new Instrument { Id = 13, Name = "Gong" },
                new Instrument { Id = 14, Name = "French horn" },
                new Instrument { Id = 15, Name = "Flute" },
                new Instrument { Id = 16, Name = "Bongo-Drum" },
                new Instrument { Id = 17, Name = "Lute" },
                new Instrument { Id = 18, Name = "Harmonica" },
                new Instrument { Id = 19, Name = "Bass guitar" },
                new Instrument { Id = 20, Name = "Viola" },
                new Instrument { Id = 21, Name = "Xylophone" }
                );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Blues" },
                new Genre { Id = 2, Name = "Country" },
                new Genre { Id = 3, Name = "Electronic" },
                new Genre { Id = 4, Name = "Folk" },
                new Genre { Id = 5, Name = "Hip Hop" },
                new Genre { Id = 6, Name = "Jazz" },
                new Genre { Id = 7, Name = "Pop" },
                new Genre { Id = 8, Name = "R&B & Soul" },
                new Genre { Id = 9, Name = "Rock" },
                new Genre { Id = 10, Name = "Metal" },
                new Genre { Id = 11, Name = "Punk" }
                );

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Email = "sulmuk28@gmail.com",
                FirstName = "Sulaiman",
                LastName = "Mukhtar",
                Bio = "Just a C# Developer into hiphop and rap",
                Username = "Sulaymahn",
                Joined = new DateTime(2024, 3, 30),
                Password = "Fannan23!",
                PhoneNumber = ""
            },
            new User
            {
                Id = 2,
                Email = "yerrouihel@gmail.com",
                FirstName = "Yassir",
                Username = "Yassir",
                Joined = new DateTime(2024, 3, 30),
                Password = "Fannan23!",
                PhoneNumber = ""
            },
            new User
            {
                Id = 3,
                Email = "medoxal123@gmail.com",
                FirstName = "Ahmad",
                Username = "Ahmad",
                Joined = new DateTime(2024, 3, 30),
                Password = "Fannan23!",
                PhoneNumber = ""
            });
        }
    }
}
