using BE_Mercadona.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_Mercadona.DataBase.EntityConfiguration
{
    public class PromotionEntityTypeConfiguration : IEntityTypeConfiguration<Promotion>
    {
        #region public methods
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.HasKey(item => item.IdPromotion);
            builder.ToTable("Promotion");
        }
        #endregion
    }
}
