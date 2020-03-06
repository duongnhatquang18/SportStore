using Microsoft.EntityFrameworkCore;

namespace SportStore.Models
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLine { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                        .HasKey(p => p.Id);

            modelBuilder.Entity<Category>()
                        .HasKey(c => c.Id);

            modelBuilder.Entity<Product>()
                        .HasOne(p => p.Category)
                        .WithMany(c => c.Products)
                        .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
                        .HasIndex(p => p.Name);
        }
    }
}
