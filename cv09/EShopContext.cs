using cv09.Models;
using Microsoft.EntityFrameworkCore;

namespace cv09
{
    public class EShopContext : DbContext
    {
        public EShopContext(DbContextOptions<EShopContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<PriceHistory> PriceHistories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SaleHistory> SaleHistory { get; set; }
    }
}
