using DAB_2_Solution_grp6.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAB_2_Solution_grp6.DataAccess.EntityConfigurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(x => x.RatingId);

            builder.Property(x => x.Created)
                .IsRequired();

            builder.Property(x => x.Stars)
                .IsRequired();

            builder.Property(x => x.Comment)
                .IsRequired(false);
        }
    }
}
