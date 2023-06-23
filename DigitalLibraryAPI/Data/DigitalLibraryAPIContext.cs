using Microsoft.EntityFrameworkCore;
using DigitalLibraryAPI.Models;

namespace DigitalLibraryAPI.Data
{
    public class DigitalLibraryAPIContext : DbContext
    {
        public DigitalLibraryAPIContext(DbContextOptions<DigitalLibraryAPIContext> options)
            : base(options)
        {
        }

        public DbSet<DigitalLibraryAPI.Models.Author> Author { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PublicationAuthor>()
                .HasKey(pa => new { pa.IdPublication, pa.IdAuthor });
            modelBuilder.Entity<PublicationAuthor>()
                .HasOne(pa => pa.Publication)
                .WithMany(p => p.PublicationAuthors)
                .HasForeignKey(pa => pa.IdPublication);
            modelBuilder.Entity<PublicationAuthor>()
                .HasOne(pa => pa.Author)
                .WithMany(a => a.PublicationAuthors)
                .HasForeignKey(pa => pa.IdAuthor);
        }

        public DbSet<DigitalLibraryAPI.Models.Borrower>? Borrower { get; set; }

        public DbSet<DigitalLibraryAPI.Models.Category>? Category { get; set; }

        public DbSet<DigitalLibraryAPI.Models.Format>? Format { get; set; }

        public DbSet<DigitalLibraryAPI.Models.Lector>? Lector { get; set; }

        public DbSet<DigitalLibraryAPI.Models.Publication>? Publication { get; set; }

        public DbSet<DigitalLibraryAPI.Models.PublicationAuthor>? PublicationAuthor { get; set; }

        public DbSet<DigitalLibraryAPI.Models.PublishingHouse>? PublishingHouse { get; set; }

        public DbSet<DigitalLibraryAPI.Models.PublicationType>? Type { get; set; }
    }
}
