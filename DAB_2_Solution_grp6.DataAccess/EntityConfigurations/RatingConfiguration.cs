using DAB_2_Solution_grp6.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAB_2_Solution_grp6.DataAccess.EntityConfigurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(r => r.RatingId);

            builder.Property(r => r.Created)
                .IsRequired();

            builder.Property(r => r.Stars)
                .HasPrecision(2, 1)
                .IsRequired();

            builder.Property(r => r.Comment)
                .IsRequired(false);
        }
    }
}
