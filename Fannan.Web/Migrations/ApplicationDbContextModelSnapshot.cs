﻿// <auto-generated />
using System;
using Fannan.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fannan.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Fannan.Web.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Fannan.Web.Entities.CommentReply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommmentId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CommmentId");

                    b.ToTable("CommentReplies");
                });

            modelBuilder.Entity("Fannan.Web.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Blues"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Country"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Electronic"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Folk"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Hip Hop"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Jazz"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Pop"
                        },
                        new
                        {
                            Id = 8,
                            Name = "R&B & Soul"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Rock"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Metal"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Punk"
                        });
                });

            modelBuilder.Entity("Fannan.Web.Entities.Instrument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Instruments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Guitar"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Piano"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Trumper"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Drum"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Maracas"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Keyboard"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Cymbal"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Bagpipe"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Saxophone"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Violin"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Tambourine"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Banjo"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Gong"
                        },
                        new
                        {
                            Id = 14,
                            Name = "French horn"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Flute"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Bongo-Drum"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Lute"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Harmonica"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Bass guitar"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Viola"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Xylophone"
                        });
                });

            modelBuilder.Entity("Fannan.Web.Entities.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Fannan.Web.Entities.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("Fannan.Web.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Fannan.Web.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("MediaId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MediaId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Fannan.Web.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Joined")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "Just a C# Developer into hiphop and rap",
                            Email = "sulmuk28@gmail.com",
                            FirstName = "Sulaiman",
                            Joined = new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Mukhtar",
                            Password = "Fannan23!",
                            PhoneNumber = "",
                            Username = "Sulaymahn"
                        },
                        new
                        {
                            Id = 2,
                            Bio = "",
                            Email = "yerrouihel@gmail.com",
                            FirstName = "Yassir",
                            Joined = new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "",
                            Password = "Fannan23!",
                            PhoneNumber = "",
                            Username = "Yassir"
                        },
                        new
                        {
                            Id = 3,
                            Bio = "",
                            Email = "medoxal123@gmail.com",
                            FirstName = "Ahmad",
                            Joined = new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "",
                            Password = "Fannan23!",
                            PhoneNumber = "",
                            Username = "Ahmad"
                        });
                });

            modelBuilder.Entity("GenreUser", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("GenreUser");
                });

            modelBuilder.Entity("InstrumentUser", b =>
                {
                    b.Property<int>("InstrumentsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("InstrumentsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("InstrumentUser");
                });

            modelBuilder.Entity("Fannan.Web.Entities.Comment", b =>
                {
                    b.HasOne("Fannan.Web.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Fannan.Web.Entities.CommentReply", b =>
                {
                    b.HasOne("Fannan.Web.Entities.Comment", "Commment")
                        .WithMany()
                        .HasForeignKey("CommmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commment");
                });

            modelBuilder.Entity("Fannan.Web.Entities.Like", b =>
                {
                    b.HasOne("Fannan.Web.Entities.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fannan.Web.Entities.User", null)
                        .WithMany("Likes")
                        .HasForeignKey("UserId");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Fannan.Web.Entities.Message", b =>
                {
                    b.HasOne("Fannan.Web.Entities.User", "Receiver")
                        .WithMany("Messages")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("Fannan.Web.Entities.Post", b =>
                {
                    b.HasOne("Fannan.Web.Entities.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId");

                    b.HasOne("Fannan.Web.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Fannan.Web.Entities.User", b =>
                {
                    b.HasOne("Fannan.Web.Entities.User", null)
                        .WithMany("Friends")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GenreUser", b =>
                {
                    b.HasOne("Fannan.Web.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fannan.Web.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InstrumentUser", b =>
                {
                    b.HasOne("Fannan.Web.Entities.Instrument", null)
                        .WithMany()
                        .HasForeignKey("InstrumentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fannan.Web.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fannan.Web.Entities.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("Fannan.Web.Entities.User", b =>
                {
                    b.Navigation("Friends");

                    b.Navigation("Likes");

                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
