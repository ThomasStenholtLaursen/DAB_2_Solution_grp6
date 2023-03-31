using DAB_2_Solution_grp6.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DAB_2_Solution_grp6.DataAccess.EntityConfigurations
{
    public class CanteenConfiguration : IEntityTypeConfiguration<Canteen>
    {
        public void Configure(EntityTypeBuilder<Canteen> builder)
        {
            builder.HasKey(c => c.CanteenId);

            builder.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(c => c.PostalCode)
                .IsRequired()
                .HasMaxLength(4);

            builder.HasMany(c => c.Ratings)
                .WithOne()
                .HasForeignKey(r => r.CanteenId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Meals)
                .WithOne()
                .HasForeignKey(m => m.CanteenId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Menus)
                .WithOne()
                .HasForeignKey(x => x.CanteenId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.JitMeals)
                .WithOne()
                .HasForeignKey(jm => jm.CanteenId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
