using DAB_2_Solution_grp6.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAB_2_Solution_grp6.DataAccess.EntityConfigurations
{
    public class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.HasKey(x => x.MealId);

            builder.Property(x => x.MealName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.CanteenId)
                .IsRequired();

            builder.Property(x => x.ReservationId)
                .IsRequired(false);
        }
    }
}
