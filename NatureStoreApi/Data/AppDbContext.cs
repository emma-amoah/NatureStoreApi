using Microsoft.EntityFrameworkCore;
using NatureStoreApi.Models;

namespace NatureStoreApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Vegetable> Vegetables { get; set; }

        // Configure the decimal precision for SQL Server for Price property in Vegetable entity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
