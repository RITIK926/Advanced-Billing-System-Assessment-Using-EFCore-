using Microsoft.EntityFrameworkCore;
using AdvancedBillingSystem.Entities;

namespace AdvancedBillingSystem.Data
{
    public class BillingDbContext : DbContext
    {
        public BillingDbContext(DbContextOptions<BillingDbContext> options) : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>().ToTable("Tenants");
            modelBuilder.Entity<Invoice>().ToTable("Invoices");
            modelBuilder.Entity<LineItem>().ToTable("LineItems");
            modelBuilder.Entity<Discount>().ToTable("Discounts");

            // Additional configurations can be added here
        }
    }
}