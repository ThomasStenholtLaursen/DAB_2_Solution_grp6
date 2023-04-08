using DAB_2_Solution_grp6.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAB_2_Solution_grp6.DataAccess
{
#pragma warning disable CS1591
    public class CanteenAppDbContext : DbContext
    {
        public DbSet<Canteen> Canteens { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Rating> Ratings { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;
        public DbSet<Meal> Meals { get; set; } = null!;
        public DbSet<Menu> Menus { get; set; } = null!;
        public DbSet<JitMeal> JitMeals { get; set; } = null!;

        public CanteenAppDbContext(DbContextOptions<CanteenAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CanteenAppDbContext).Assembly);

            //modelBuilder.Entity<Canteen>().HasData(new Canteen(Guid.NewGuid(), "blabla", "dsadas", "8000"));
        }
    }
#pragma warning restore CS1591
}
