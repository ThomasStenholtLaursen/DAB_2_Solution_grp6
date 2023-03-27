using DAB_2_Solution_grp6.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAB_2_Solution_grp6.DataAccess.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Cpr);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(x => x.Ratings)
                .WithOne()
                .HasForeignKey(x => x.Cpr)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.Reservations)
                .WithOne()
                .HasForeignKey(x => x.Cpr)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
