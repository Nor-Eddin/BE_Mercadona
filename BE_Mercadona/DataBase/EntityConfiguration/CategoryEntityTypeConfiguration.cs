using BE_Mercadona.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_Mercadona.DataBase.EntityConfiguration
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        #region public methods
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(item => item.CatId);
            builder.ToTable("Category");
        }
        #endregion
    }
}
