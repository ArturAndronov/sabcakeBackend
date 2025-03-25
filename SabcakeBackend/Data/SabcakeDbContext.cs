using SabcakeBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace SabcakeBackend.Data
{
    public class SabcakeDbContext: DbContext
    {
        public SabcakeDbContext(DbContextOptions<SabcakeDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<GalleryItem> GalleryItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id); //id primary key

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired() //name necessary field
                .HasMaxLength(100); //max length 100 symbols
        }
    }
}
