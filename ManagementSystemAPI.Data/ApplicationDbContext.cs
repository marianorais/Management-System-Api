using Microsoft.EntityFrameworkCore;
using ManagementSystemAPI.Core.Models.Domain;
using ManagementSystemAPI.Core.Models;

namespace ManagementSystemAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // USER
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasIndex(u => u.Email)
                    .IsUnique(); 
            });

            // BOOK
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(b => b.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(b => b.Author)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(b => b.Isbn)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasIndex(b => b.Isbn)
                    .IsUnique(); 
            });

            // PRODUCT
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(p => p.Description)
                    .HasMaxLength(500);

                entity.Property(p => p.Stock)
                    .IsRequired();
            });

            // ORDER
            modelBuilder.Entity<Order>(entity =>
            {

                entity.Property(o => o.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(o => o.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

    }
}