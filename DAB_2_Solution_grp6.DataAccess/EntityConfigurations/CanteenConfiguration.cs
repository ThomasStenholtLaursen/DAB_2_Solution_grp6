using DAB_2_Solution_grp6.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DAB_2_Solution_grp6.DataAccess.EntityConfigurations
{
    public class CanteenConfiguration : IEntityTypeConfiguration<Canteen>
    {
        public void Configure(EntityTypeBuilder<Canteen> builder)
        {
            builder.HasKey(x => x.CanteenId);

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.PostalCode)
                .IsRequired()
                .HasMaxLength(4);

            builder.HasMany(x => x.Ratings)
                .WithOne()
                .HasForeignKey(x => x.CanteenId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
