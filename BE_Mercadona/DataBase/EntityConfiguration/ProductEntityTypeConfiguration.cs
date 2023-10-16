using BE_Mercadona.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_Mercadona.DataBase.EntityConfiguration
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        #region public Methods
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(item => item.IdProduct);
            builder.ToTable("Product");
        }
        #endregion
    }
}
