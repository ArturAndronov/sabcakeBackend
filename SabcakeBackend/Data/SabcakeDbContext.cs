using Microsoft.EntityFrameworkCore;
using SabcakeBackend.Models;

namespace SabcakeBackend.Data
{
    public class SabcakeDbContext : DbContext
    {
        public SabcakeDbContext(DbContextOptions<SabcakeDbContext> options) : base(options)
        {
        }

        public DbSet<Cakes> Cakes { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<Fillings> Fillings { get; set; }
        public DbSet<CakeTypes> CakeTypes { get; set; }
        public DbSet<CakeFillings> CakeFillings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        modelBuilder.Entity<CakeTypes>().HasKey(ct => new { ct.CakeId, ct.TypeId });
        modelBuilder.Entity<CakeFillings>().HasKey(cf => new { cf.CakeId, cf.FillingId });
        // Игнорируем системные типы
        modelBuilder.Ignore<System.Reflection.CustomAttributeData>();

            // Настройка составных ключей для связей many-to-many
            modelBuilder.Entity<CakeTypes>()
                .HasKey(ct => new { ct.CakeId, ct.TypeId });

            modelBuilder.Entity<CakeFillings>()
                .HasKey(cf => new { cf.CakeId, cf.FillingId });

            // Настройка связей
            modelBuilder.Entity<CakeTypes>()
                .HasOne(ct => ct.Cake)
                .WithMany(c => c.CakeTypes)
                .HasForeignKey(ct => ct.CakeId);

            modelBuilder.Entity<CakeTypes>()
                .HasOne(ct => ct.Type)
                .WithMany(t => t.CakeTypes)
                .HasForeignKey(ct => ct.TypeId);

            modelBuilder.Entity<CakeFillings>()
                .HasOne(cf => cf.Cake)
                .WithMany(c => c.CakeFillings)
                .HasForeignKey(cf => cf.CakeId);

            modelBuilder.Entity<CakeFillings>()
                .HasOne(cf => cf.Filling)
                .WithMany(f => f.CakeFillings)
                .HasForeignKey(cf => cf.FillingId);
        }
    }
}