using DAB_2_Solution_grp6.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAB_2_Solution_grp6.DataAccess.EntityConfigurations
{
    public class JitMealConfiguration : IEntityTypeConfiguration<JitMeal>
    {
        public void Configure(EntityTypeBuilder<JitMeal> builder)
        {
            builder.HasKey(x => x.JitMealId);

            builder.Property(x => x.JitName).HasMaxLength(50);

            builder.Property(x => x.CanteenId).IsRequired();
        }
    }
}
