using BE_Mercadona.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Mercadona.DataBase
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
    }
}
