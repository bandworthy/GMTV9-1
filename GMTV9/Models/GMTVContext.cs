using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GMTV9.Models
{
    public partial class GMTVContext : DbContext
    {
        public GMTVContext()
        {
        }

        public GMTVContext(DbContextOptions<GMTVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Episodes> Episodes { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Tvshows> Tvshows { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                ////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=YIPSTER5GHZ;Initial Catalog=GMTV;Integrated Security=True;");
            }
}

protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Episodes>(entity =>
            {
                entity.HasKey(e => e.EpisodeId);

                entity.Property(e => e.EpisodeId).HasColumnName("EpisodeID");

                entity.Property(e => e.EpisodeNum).HasColumnName("Episode_Num");

                entity.Property(e => e.ShowId).HasColumnName("ShowID");

                entity.Property(e => e.Title).HasMaxLength(25);

                entity.HasOne(d => d.Show)
                    .WithMany(p => p.Episodes)
                    .HasForeignKey(d => d.ShowId)
                    .HasConstraintName("FK__Episodes__ShowID__15502E78");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllDone).HasColumnName("All_Done");

                entity.Property(e => e.BarCodeNum)
                    .HasColumnName("Bar_Code_Num")
                    .HasMaxLength(13);

                entity.Property(e => e.HasPlatinum).HasColumnName("has_Platinum");

                entity.Property(e => e.HasTrophies).HasColumnName("has_Trophies");

                entity.Property(e => e.IsSeries).HasColumnName("isSeries");

                entity.Property(e => e.Platform)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.SeriesNumber).HasColumnName("Series_Number");

                entity.Property(e => e.Subtitle).HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.MovieId).HasColumnName("movieID");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.SubTitle).HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tvshows>(entity =>
            {
                entity.ToTable("TVShows");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Subtitle).HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
