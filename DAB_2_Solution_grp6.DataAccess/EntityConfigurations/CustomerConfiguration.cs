using DAB_2_Solution_grp6.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAB_2_Solution_grp6.DataAccess.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Cpr);

            builder.Property(x => x.Cpr)
                .HasMaxLength(10);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(c => c.Ratings)
                .WithOne()
                .HasForeignKey(r => r.Cpr)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(c => c.Reservations)
                .WithOne()
                .HasForeignKey(r => r.Cpr)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
