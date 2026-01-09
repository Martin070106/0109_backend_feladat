using Microsoft.EntityFrameworkCore;

namespace kamecz_martin_backend.Models
{
    public class librarydbContext : DbContext
    {
        public librarydbContext(DbContextOptions<librarydbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.HasMany(a => a.Books)
                      .WithOne(b => b.Author)
                      .HasForeignKey(b => b.AuthorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

     
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.HasMany(c => c.Books)
                      .WithOne(b => b.Category)
                      .HasForeignKey(b => b.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(500);
            });
        }
    }
}
