using CoreApp102.Core.Models;
using CoreApp102.Data.Configuration;
using CoreApp102.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace CoreApp102.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));
        }
    }
}
