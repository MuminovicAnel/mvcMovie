﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mvcMovie.Models;

namespace mvcMovie.Migrations
{
    [DbContext(typeof(mvcMovieContext))]
    [Migration("20200217233001_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("mvcMovie.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Drame"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Comédie"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Thriller"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Action"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Fantastique"
                        },
                        new
                        {
                            ID = 6,
                            Name = "Horreur"
                        },
                        new
                        {
                            ID = 7,
                            Name = "Fiction"
                        });
                });

            modelBuilder.Entity("mvcMovie.Models.Film", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Year")
                        .HasColumnType("datetime2");

                    b.Property<int>("category_id")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("category_id");

                    b.ToTable("Film");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "In 1938, after his father Professor Henry Jones, Sr.goes missing while pursuing the Holy Grail, Professor Henry \"Indiana\" Jones, Jr. finds himself up against Adolf Hitler's Nazis again to stop them from obtaining its powers.",
                            Image = "https://m.media-amazon.com/images/M/MV5BMjNkMzc2N2QtNjVlNS00ZTk5LTg0MTgtODY2MDAwNTMwZjBjXkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_SX300.jpg",
                            Name = "Indiana Jones and the Last Crusade",
                            Year = new DateTime(1989, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            category_id = 4
                        },
                        new
                        {
                            ID = 2,
                            Description = "Three former parapsychology professors set up shop as a unique ghost removal service.",
                            Image = "https://m.media-amazon.com/images/M/MV5BMTkxMjYyNzgwMl5BMl5BanBnXkFtZTgwMTE3MjYyMTE@._V1_SX300.jpg",
                            Name = "Ghostbusters",
                            Year = new DateTime(1984, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            category_id = 2
                        },
                        new
                        {
                            ID = 3,
                            Description = "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.",
                            Image = "https://m.media-amazon.com/images/M/MV5BNzVlY2MwMjktM2E4OS00Y2Y3LWE3ZjctYzhkZGM3YzA1ZWM2XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg",
                            Name = "Star Wars: Episode IV - A New Hope",
                            Year = new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            category_id = 4
                        },
                        new
                        {
                            ID = 4,
                            Description = "A small-town sheriff in the American West enlists the help of a cripple, a drunk, and a young gunfighter in his efforts to hold in jail the brother of the local bad guy.",
                            Image = "https://m.media-amazon.com/images/M/MV5BZDVhMTk1NjUtYjc0OS00OTE1LTk1NTYtYWMzMDI5OTlmYzU2XkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_SX300.jpg",
                            Name = "Rio Bravo",
                            Year = new DateTime(1959, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            category_id = 3
                        });
                });

            modelBuilder.Entity("mvcMovie.Models.FilmUser", b =>
                {
                    b.Property<int>("Film_id")
                        .HasColumnType("int");

                    b.Property<int>("Status_id")
                        .HasColumnType("int");

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Film_id", "Status_id", "User_id");

                    b.HasIndex("Status_id");

                    b.HasIndex("User_id");

                    b.ToTable("FilmUser");

                    b.HasData(
                        new
                        {
                            Film_id = 1,
                            Status_id = 2,
                            User_id = 1,
                            ID = 1,
                            Rating = 7
                        },
                        new
                        {
                            Film_id = 4,
                            Status_id = 3,
                            User_id = 1,
                            ID = 2,
                            Rating = 5
                        });
                });

            modelBuilder.Entity("mvcMovie.Models.Status", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "A voir"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Vu"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Pas intéressé"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Favoris / coup de coeur"
                        });
                });

            modelBuilder.Entity("mvcMovie.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pseudo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Email = "pierre.andre@gmail.com",
                            Firstname = "Pierre",
                            Lastname = "André",
                            Password = "Rfc2898DeriveBytes$50000$+Cy3mW/JYCc+Eq/UkZeMRQ==$ITkpD61uH1atv1Ff41qPEfa9MYoyKXqGCrVDuiNXsBg=",
                            Pseudo = "Pierre03"
                        },
                        new
                        {
                            ID = 2,
                            Email = "jean.marc@gmail.com",
                            Firstname = "Jean",
                            Lastname = "Marc",
                            Password = "Rfc2898DeriveBytes$50000$AMhllGXPBqDcSy7fV+hKVQ==$1ICFSALWHrvWrJRHluQxDtBgbW4ZCBPWrpiJM4+T1R8=",
                            Pseudo = "jeanJean"
                        });
                });

            modelBuilder.Entity("mvcMovie.Models.Film", b =>
                {
                    b.HasOne("mvcMovie.Models.Category", "Category")
                        .WithMany("Films")
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("mvcMovie.Models.FilmUser", b =>
                {
                    b.HasOne("mvcMovie.Models.Film", "Film")
                        .WithMany("FilmUsers")
                        .HasForeignKey("Film_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mvcMovie.Models.Status", "Status")
                        .WithMany("FilmUsers")
                        .HasForeignKey("Status_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mvcMovie.Models.User", "User")
                        .WithMany("FilmUsers")
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
