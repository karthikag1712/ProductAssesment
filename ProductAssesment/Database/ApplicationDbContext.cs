using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductAssesment.Models;
using ProductAssesment.ClientModel;

namespace ProductAssesment.Database
{
    public  class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        
        /// <summary>
        /// DB Connection from Appsetting json
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlite(connectionString);
            }
        }
        /// <summary>
        /// Database Tables
        /// </summary>
        public DbSet<Product> Products { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<StockAllocation> StockAllocations { get; set; }

        /// <summary>
        /// Table Relationships
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockAllocation>()
            .HasOne(b => b.Location)          // Each StockAllocation has one Location
            .WithMany(a => a.StockAllocations)         // Each Location can have many StockAllocation
            .HasForeignKey(b => b.LocationId); // Define the LocationId foreign key

            modelBuilder.Entity<StockAllocation>()
                .HasOne(b => b.Product)       // Each StockAllocation has one Product
                .WithMany(p => p.StockAllocations)         // Each Product can have many StockAllocation
                .HasForeignKey(b => b.ProductId); // Define the ProductId foreign key
        }
    }
    
}
