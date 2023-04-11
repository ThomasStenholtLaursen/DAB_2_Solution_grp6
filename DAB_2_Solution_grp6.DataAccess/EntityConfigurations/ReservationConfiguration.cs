using DAB_2_Solution_grp6.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAB_2_Solution_grp6.DataAccess.EntityConfigurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(x => x.ReservationId);

            builder.Property(x => x.WarmQuantity).IsRequired(false);

            builder.Property(x => x.StreetQuantity).IsRequired(false);

            builder.Property(x => x.Created)
                .IsRequired();

            builder.Property(x => x.AuId)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasMany(x => x.Meals)
                .WithOne()
                .HasForeignKey(x => x.ReservationId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
