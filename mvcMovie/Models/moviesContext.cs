using Microsoft.EntityFrameworkCore;

namespace mvcMovie
{
    public partial class moviesContext : DbContext
    {
        public moviesContext()
        {
        }

        public moviesContext(DbContextOptions<moviesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }
        public virtual DbSet<UserLikeMovie> UserLikeMovie { get; set; }
        public virtual DbSet<Users> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__categori__72E12F1B0CAB3693")
                    .IsUnique();

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasIndex(e => new { e.Title, e.Release })
                    .HasName("UQ_movie")
                    .IsUnique();

                entity.Property(e => e.Picture).IsUnicode(false);

                entity.Property(e => e.Synopsis).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_category");

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.RatingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rating");

            });

            modelBuilder.Entity<Ratings>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__ratings__72E12F1BD11CA155")
                    .IsUnique();

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<UserLikeMovie>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.MovieId })
                    .HasName("UQ_like")
                    .IsUnique();

                entity.Property(e => e.Comment).IsUnicode(false);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.UserLikeMovie)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movie_like");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLikeMovie)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_like");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => new { e.Firstname, e.Lastname })
                    .HasName("UQ_user")
                    .IsUnique();

                entity.Property(e => e.Firstname).IsUnicode(false);

                entity.Property(e => e.Lastname).IsUnicode(false);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
