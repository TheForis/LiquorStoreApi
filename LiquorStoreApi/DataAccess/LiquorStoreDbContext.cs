using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class LiquorStoreDbContext : DbContext
    {
        public LiquorStoreDbContext(DbContextOptions<LiquorStoreDbContext> options) : base(options) { }
        
        public virtual DbSet<Beverage> Beverages { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PopulateDb.Seed(modelBuilder);
        }

    }
}
