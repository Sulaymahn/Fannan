using Fannan.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fannan.Web.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt, IWebHostEnvironment env) : DbContext(opt)
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
        public DbSet<Follow> Follows => Set<Follow>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MusicRole>().HasData(
                new MusicRole { Id = 1, Name = "Producer" },
                new MusicRole { Id = 2, Name = "Bassist" },
                new MusicRole { Id = 3, Name = "Rapper" },
                new MusicRole { Id = 4, Name = "Singer/Vocalist" },
                new MusicRole { Id = 5, Name = "Drummer" },
                new MusicRole { Id = 6, Name = "Audio Engineer" },
                new MusicRole { Id = 7, Name = "DJ (Disc Jockey)" },
                new MusicRole { Id = 8, Name = "Backing Vocalist" },
                new MusicRole { Id = 9, Name = "Conductor" },
                new MusicRole { Id = 10, Name = "Arranger" },
                new MusicRole { Id = 11, Name = "Composer" },
                new MusicRole { Id = 12, Name = "Songwriter" },
                new MusicRole { Id = 13, Name = "Songwriter" },
                new MusicRole { Id = 14, Name = "Session Musician" }
                );

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


            modelBuilder.Entity<Media>().HasData(
                new Media
                {
                    Id = 1,
                    FileName = "post_1.jpg",
                    ContentType = "image/jpeg",
                    DateAdded = new DateTime(2024, 3, 31),
                    Data = File.ReadAllBytes(Path.Combine(env.WebRootPath, "images", "post_1.jpg"))
                }, new Media
                {
                    Id = 2,
                    FileName = "post_2.jpg",
                    ContentType = "image/jpeg",
                    DateAdded = new DateTime(2024, 3, 31),
                    Data = File.ReadAllBytes(Path.Combine(env.WebRootPath, "images", "post_2.jpg"))
                }, new Media
                {
                    Id = 3,
                    FileName = "post_3.png",
                    ContentType = "image/png",
                    DateAdded = new DateTime(2024, 3, 31),
                    Data = File.ReadAllBytes(Path.Combine(env.WebRootPath, "images", "post_3.png"))
                }, new Media
                {
                    Id = 4,
                    FileName = "post_4.jpg",
                    ContentType = "image/jpeg",
                    DateAdded = new DateTime(2024, 3, 31),
                    Data = File.ReadAllBytes(Path.Combine(env.WebRootPath, "images", "post_4.jpg"))
                }, new Media
                {
                    Id = 5,
                    FileName = "profile_1.jpg",
                    ContentType = "image/jpeg",
                    DateAdded = new DateTime(2024, 3, 31),
                    Data = File.ReadAllBytes(Path.Combine(env.WebRootPath, "images", "profile_1.jpg"))
                }, new Media
                {
                    Id = 6,
                    FileName = "profile_2.jpg",
                    ContentType = "image/jpeg",
                    DateAdded = new DateTime(2024, 3, 31),
                    Data = File.ReadAllBytes(Path.Combine(env.WebRootPath, "images", "profile_2.jpg"))
                }, new Media
                {
                    Id = 7,
                    FileName = "profile_3.jpg",
                    ContentType = "image/jpeg",
                    DateAdded = new DateTime(2024, 3, 31),
                    Data = File.ReadAllBytes(Path.Combine(env.WebRootPath, "images", "profile_3.jpg"))
                });

            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = 1,
                UserId = 1,
                MediaId = 1,
                Text = "Hello guys, working on the fannan app, almost ready to launchh!!",
                Date = new DateTime(2024, 3, 31)
            }, new Post
            {
                Id = 2,
                UserId = 1,
                MediaId = 2,
                Text = "Just had the most amazing experience at a live concert! 🎶✨ The energy, the passion, the music... it's like being transported to another world. Can't wait for the next one! #LiveMusic #MusicIsLife",
                Date = new DateTime(2024, 3, 31)
            }, new Post
            {
                Id = 3,
                UserId = 2,
                MediaId = 3,
                Text = "Spent the evening discovering new tunes on Spotify and stumbled upon some absolute gems! Music has this magical way of speaking to the soul, don't you think? 🎧💫 #MusicDiscovery #SoulfulSounds",
                Date = new DateTime(2024, 3, 31)
            }, new Post
            {
                Id = 4,
                UserId = 3,
                Text = "Just jammed with some friends in the garage and it was pure musical therapy. Nothing beats making music together and feeling that creative flow! 🎸🥁 #JamSession #MusicalBonding",
                Date = new DateTime(2024, 3, 31)
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                ProfilePictureId = 6,
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
                ProfilePictureId = 5,
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
                ProfilePictureId = 7,
                Email = "medoxal123@gmail.com",
                FirstName = "Ahmad",
                Username = "Ahmad",
                Joined = new DateTime(2024, 3, 30),
                Password = "Fannan23!",
                PhoneNumber = ""
            });

            modelBuilder.Entity<Comment>().HasData(new Comment
            {
                Id = 1,
                UserId = 1,
                PostId = 1,
                Content = "Also, the first to comment, see you next time.",
                Date = new DateTime(2024, 3, 31)
            });

            modelBuilder.Entity<CommentReply>().HasData(new CommentReply
            {
                Id = 1,
                UserId = 2,
                CommentId = 1,
                Content = "Second here!.....",
                Date = new DateTime(2024, 3, 31)
            });

            modelBuilder.Entity<Follow>().HasData(
                new Follow { UserId = 1, FollowingUserId = 2 },
                new Follow { UserId = 2, FollowingUserId = 1 }
                );
        }
    }
}
