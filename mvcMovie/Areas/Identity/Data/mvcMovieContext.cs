using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvcMovie.Models;

namespace mvcMovie.Areas.Identity.Data
{
    public class mvcMovieContext : DbContext
    {
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
            base.OnModelCreating(builder);
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
        }       
    }
}
