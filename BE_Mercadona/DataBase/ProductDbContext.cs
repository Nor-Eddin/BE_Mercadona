using BE_Mercadona.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BE_Mercadona.DataBase
{
    public class ProductDbContext : IdentityDbContext
    {
        #region Constructor
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }
        #endregion
        #region Public Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntityConfiguration.ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EntityConfiguration.CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EntityConfiguration.PromotionEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        #endregion
        #region Properties
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        #endregion
    }
}
