using DAB_2_Solution_grp6.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAB_2_Solution_grp6.DataAccess.EntityConfigurations
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(x => x.StaffId);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Salary)
                .IsRequired();
        }
    }
}
