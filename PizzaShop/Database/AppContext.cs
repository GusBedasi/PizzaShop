using Microsoft.EntityFrameworkCore;
using PizzaShop.Domain;

namespace PizzaShop.Database
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> contextOptions)
        : base(contextOptions) { }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
        }
    }
}