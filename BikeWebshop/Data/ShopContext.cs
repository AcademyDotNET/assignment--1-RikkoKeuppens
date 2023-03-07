using BikeWebshop.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeWebshop.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingBag> ShoppingBags { get; set; }
        public DbSet<ShoppingItem> ShoppingItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
