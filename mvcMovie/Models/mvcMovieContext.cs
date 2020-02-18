using Microsoft.EntityFrameworkCore;
using SimpleHashing.Net;
using System;

namespace mvcMovie.Models
{
    public class mvcMovieContext : DbContext
    {
        public ISimpleHash simpleHash = new SimpleHash();

        public mvcMovieContext(DbContextOptions<mvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FilmUser> FilmUser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Film>().ToTable("Film");
            builder.Entity<Status>().ToTable("Status");
            builder.Entity<Category>().ToTable("Category");
            builder.Entity<User>().ToTable("User");
            builder.Entity<FilmUser>().ToTable("FilmUser");


            builder.Entity<FilmUser>()
                .HasKey(bc => new { bc.Film_id, bc.Status_id, bc.User_id });

            builder.Entity<FilmUser>()
                .HasOne(bc => bc.Film)
                .WithMany(b => b.FilmUsers)
                .HasForeignKey(bc => bc.Film_id);
            builder.Entity<FilmUser>()
                .HasOne(bc => bc.Status)
                .WithMany(b => b.FilmUsers)
                .HasForeignKey(bc => bc.Status_id);
            builder.Entity<FilmUser>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.FilmUsers)
                .HasForeignKey(bc => bc.User_id);

            builder.Entity<Film>()
                .HasOne(s => s.Category)
                .WithMany(g => g.Films)
                .HasForeignKey(s => s.category_id);

            builder.Entity<Category>()
                .HasData(
                    new Category { ID=1, Name = "Drame" },
                    new Category { ID = 2, Name = "Comédie" },
                    new Category { ID = 3, Name = "Thriller" },
                    new Category { ID = 4, Name = "Action" },
                    new Category { ID = 5, Name = "Fantastique" },
                    new Category { ID = 6, Name = "Horreur" },
                    new Category { ID = 7, Name = "Fiction" }
                );

            builder.Entity<Film>()
                .HasData(
                    new Film { ID = 1, Name = "Indiana Jones and the Last Crusade", Year = DateTime.Parse("1989-05-24"), Image = "https://m.media-amazon.com/images/M/MV5BMjNkMzc2N2QtNjVlNS00ZTk5LTg0MTgtODY2MDAwNTMwZjBjXkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_SX300.jpg", Description = "In 1938, after his father Professor Henry Jones, Sr.goes missing while pursuing the Holy Grail, Professor Henry \"Indiana\" Jones, Jr. finds himself up against Adolf Hitler's Nazis again to stop them from obtaining its powers.", category_id = 4 },
                    new Film { ID = 2, Name = "Ghostbusters", Year = DateTime.Parse("1984-03-13"), Image = "https://m.media-amazon.com/images/M/MV5BMTkxMjYyNzgwMl5BMl5BanBnXkFtZTgwMTE3MjYyMTE@._V1_SX300.jpg", Description = "Three former parapsychology professors set up shop as a unique ghost removal service.", category_id = 2 },
                    new Film { ID = 3, Name = "Star Wars: Episode IV - A New Hope", Year = DateTime.Parse("1977-05-25"), Image = "https://m.media-amazon.com/images/M/MV5BNzVlY2MwMjktM2E4OS00Y2Y3LWE3ZjctYzhkZGM3YzA1ZWM2XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", Description = "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.", category_id = 4 },
                    new Film { ID = 4, Name = "Rio Bravo", Year = DateTime.Parse("1959-04-15"), Image = "https://m.media-amazon.com/images/M/MV5BZDVhMTk1NjUtYjc0OS00OTE1LTk1NTYtYWMzMDI5OTlmYzU2XkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_SX300.jpg", Description = "A small-town sheriff in the American West enlists the help of a cripple, a drunk, and a young gunfighter in his efforts to hold in jail the brother of the local bad guy.", category_id = 3 }
                );

            builder.Entity<Status>()
                .HasData(
                    new Status { ID = 1, Name = "A voir" },
                    new Status { ID = 2, Name = "Vu" },
                    new Status { ID = 3, Name = "Pas intéressé" },
                    new Status { ID = 4, Name = "Favoris / coup de coeur" }
                );

            builder.Entity<User>()
                .HasData(
                    new User { ID = 1, Firstname = "Pierre", Lastname = "André", Pseudo = "Pierre03", Email = "pierre.andre@gmail.com", Password = simpleHash.Compute("secret") },
                    new User { ID = 2, Firstname = "Jean", Lastname = "Marc", Pseudo = "jeanJean", Email = "jean.marc@gmail.com", Password = simpleHash.Compute("pass") }
                );

            builder.Entity<FilmUser>()
                .HasData(
                    new FilmUser { ID = 1, User_id = 1, Film_id = 1, Status_id = 2, Rating = 7 },
                    new FilmUser { ID = 2, User_id = 1, Film_id = 4, Status_id = 3, Rating = 5 }
                );
        }       
    }
}
