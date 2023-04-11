using DAB_2_Solution_grp6.DataAccess;
using DAB_2_Solution_grp6.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAB_2_Solution_grp6.Api.Seed
{
    public static class DataSeed
    {
        public static async Task Seed(CanteenAppDbContext context)
        {
            var dataExists =
                await context.Canteens.AnyAsync() ||
                await context.Reservations.AnyAsync() ||
                await context.Ratings.AnyAsync() ||
                await context.Menus.AnyAsync() ||
                await context.Reservations.AnyAsync() ||
                await context.Meals.AnyAsync() ||
                await context.JitMeals.AnyAsync();

            if (dataExists) return;

            var socialSecurityNumbers = GenerateSocialSecurityNumbers(10);
            var canteenIds = GenerateIdentifiers(10);
            var menuIds = GenerateIdentifiers(10);
            var reservationIds = GenerateIdentifiers(10);

            await SeedCanteens(context, canteenIds);
            await SeedCustomers(context, socialSecurityNumbers);
            await SeedRatings(context, canteenIds, socialSecurityNumbers);
            await SeedMenus(context, canteenIds, menuIds);
            await SeedReservations(context, menuIds, socialSecurityNumbers, reservationIds);
            await SeedMeals(context, canteenIds, reservationIds);
            await SeedJustInTimeMeals(context, canteenIds);
        }

        private static async Task SeedCanteens(CanteenAppDbContext context, IReadOnlyList<Guid> canteenIds)
        {
            var canteens = new[]
            {
                new Canteen(canteenIds[0], "Kgl. Bibliotek","Victor Albecks Vej 1", "8000"),
                new Canteen(canteenIds[1], "Mathematical Canteen","Ny Munkegade 116", "8000"),
                new Canteen(canteenIds[2], "INCUBA Katrinebjerg","Åbogade 15", "8200"),
                new Canteen(canteenIds[3], "Chemical Canteen","Langelandsgade 140", "8000"),
                new Canteen(canteenIds[4], "MoCa MaD","Moesgård Allé 20", "8270")
            };

            context.Canteens.AddRange(canteens);
            await context.SaveChangesAsync();
        }

        private static async Task SeedCustomers(CanteenAppDbContext context, IReadOnlyList<string> cprs)
        {
            var customers = new[]
            {
                new Customer(cprs[0], "Jens", "Henriksen"),
                new Customer(cprs[1], "Gitte", "Frederiksen"),
                new Customer(cprs[2], "Claus", "Nielsen"),
                new Customer(cprs[3], "Hanne", "Sørensen"),
                new Customer(cprs[4], "Hans", "Larsen")
            };

            context.Customers.AddRange(customers);
            await context.SaveChangesAsync();
        }

        private static async Task SeedRatings(CanteenAppDbContext context, IReadOnlyList<Guid> canteenIds,
            IReadOnlyList<string> cprs)
        {
            var ratings = new[]
            {
                new Rating(Guid.NewGuid(),
                    5,
                    new DateTime(2023, 01, 03, 10, 30, 00),
                    "It was the best!",
                    cprs[0],
                    canteenIds[0]),
                new Rating(Guid.NewGuid(),
                    3, new DateTime(2023, 01, 05, 10, 45, 45),
                    "Too expensive",
                    cprs[1],
                    canteenIds[1]),
                new Rating(Guid.NewGuid(),
                    3,
                    new DateTime(2023, 01, 05, 10, 45, 45),
                    "Prices are a bit high",
                    cprs[2],
                    canteenIds[2]),
                new Rating(Guid.NewGuid(),
                    4,
                    new DateTime(2023, 01, 06, 11, 15, 45),
                    "Good meal",
                    cprs[3],
                    canteenIds[3]),
            };

            context.Ratings.AddRange(ratings);
            await context.SaveChangesAsync();
        }

        private static async Task SeedMenus(CanteenAppDbContext context, IReadOnlyList<Guid> canteenIds, IReadOnlyList<Guid> menuIds)
        {
            var menus = new[]
            {
                new Menu(menuIds[0], "Soup", "Pizza", DateTime.Now, canteenIds[0]),
                new Menu(menuIds[1], "Lasagne", "Hot Dog", DateTime.Now, canteenIds[1]),
                new Menu(menuIds[2], "Meatballs", "Taco", DateTime.Now, canteenIds[2]),
                new Menu(menuIds[3], "Wok", "Kebab", DateTime.Now, canteenIds[3]),
                new Menu(menuIds[4], "Cod with peas", "Burger", DateTime.Now, canteenIds[4]),
            };

            context.Menus.AddRange(menus);
            await context.SaveChangesAsync();
        }

        private static async Task SeedReservations(CanteenAppDbContext context, IReadOnlyList<Guid> menuIds, IReadOnlyList<string> cprs, IReadOnlyList<Guid> reservationIds)
        {
            var reservations = new[]
            {
                new Reservation(reservationIds[0], 1, 2, DateTime.Now, cprs[0], menuIds[0]),
                new Reservation(reservationIds[1], 0, 2, DateTime.Now, cprs[1], menuIds[0]),
                new Reservation(reservationIds[2], 4, 2, DateTime.Now, cprs[2], menuIds[1]),

            };

            context.Reservations.AddRange(reservations);
            await context.SaveChangesAsync();
        }

        private static async Task SeedMeals(CanteenAppDbContext context, IReadOnlyList<Guid> canteenIds, IReadOnlyList<Guid> reservationIds)
        {
            var meals = new[]
            {
                new Meal(Guid.NewGuid(), "Soup", canteenIds[0], reservationIds[0]),
                new Meal(Guid.NewGuid(), "Pizza", canteenIds[0], reservationIds[0]),
                new Meal(Guid.NewGuid(), "Pizza", canteenIds[0], reservationIds[0]),
                new Meal(Guid.NewGuid(), "Pizza", canteenIds[0], null),
                new Meal(Guid.NewGuid(), "Pizza", canteenIds[0], null),
                new Meal(Guid.NewGuid(), "Pizza", canteenIds[0], null),
                new Meal(Guid.NewGuid(), "Pizza", canteenIds[0], null),
                new Meal(Guid.NewGuid(), "Lasagne", canteenIds[1], reservationIds[2]),
                new Meal(Guid.NewGuid(), "Lasagne", canteenIds[1], reservationIds[2]),
                new Meal(Guid.NewGuid(), "Lasagne", canteenIds[1], reservationIds[2]),
                new Meal(Guid.NewGuid(), "Lasagne", canteenIds[1], reservationIds[2]),
                new Meal(Guid.NewGuid(), "Hot Dog", canteenIds[1], reservationIds[2]),
                new Meal(Guid.NewGuid(), "Hot Dog", canteenIds[1], reservationIds[2]),
                new Meal(Guid.NewGuid(), "Hot Dog", canteenIds[1], null),
                new Meal(Guid.NewGuid(), "Hot Dog", canteenIds[1], null),
                new Meal(Guid.NewGuid(), "Hot Dog", canteenIds[1], null),
            };

            context.Meals.AddRange(meals);
            await context.SaveChangesAsync();
        }

        private static async Task SeedJustInTimeMeals(CanteenAppDbContext context, IReadOnlyList<Guid> canteenIds)
        {
            var jitMeals = new[]
            {
                new JitMeal(Guid.NewGuid(), "Sandwich", canteenIds[0]),
                new JitMeal(Guid.NewGuid(), "Sandwich", canteenIds[0]),
                new JitMeal(Guid.NewGuid(), "Sandwich", canteenIds[0]),
                new JitMeal(Guid.NewGuid(), "Sandwich", canteenIds[0]),
                new JitMeal(Guid.NewGuid(), "Sandwich", canteenIds[0]),
                new JitMeal(Guid.NewGuid(), "Sandwich", canteenIds[0]),
                new JitMeal(Guid.NewGuid(), "Sandwich", canteenIds[1]),
                new JitMeal(Guid.NewGuid(), "Sandwich", canteenIds[1]),
                new JitMeal(Guid.NewGuid(), "Chocolate cake", canteenIds[1]),
                new JitMeal(Guid.NewGuid(), "Chocolate cake", canteenIds[1]),
                new JitMeal(Guid.NewGuid(), "Chocolate cake", canteenIds[1]),
                new JitMeal(Guid.NewGuid(), "Chocolate cake", canteenIds[1]),
                new JitMeal(Guid.NewGuid(), "Panini with ham", canteenIds[2]),
                new JitMeal(Guid.NewGuid(), "Panini with ham", canteenIds[2]),
                new JitMeal(Guid.NewGuid(), "Panini with ham", canteenIds[2]),
                new JitMeal(Guid.NewGuid(), "Panini with ham", canteenIds[2]),
                new JitMeal(Guid.NewGuid(), "Vegan salad", canteenIds[3]),
                new JitMeal(Guid.NewGuid(), "Vegan salad", canteenIds[3]),
                new JitMeal(Guid.NewGuid(), "Vegan salad", canteenIds[3]),
                new JitMeal(Guid.NewGuid(), "Vegan salad", canteenIds[3]),
                new JitMeal(Guid.NewGuid(), "Homemade snickers", canteenIds[4]),
                new JitMeal(Guid.NewGuid(), "Homemade snickers", canteenIds[4]),
                new JitMeal(Guid.NewGuid(), "Homemade snickers", canteenIds[4]),
                new JitMeal(Guid.NewGuid(), "Homemade snickers", canteenIds[4]),
                new JitMeal(Guid.NewGuid(), "Homemade snickers", canteenIds[4]),
            };

            context.JitMeals.AddRange(jitMeals);
            await context.SaveChangesAsync();
        }

        private static List<Guid> GenerateIdentifiers(int count)
        {
            var ids = new List<Guid>();

            for (var i = 0; i < count; i++)
            {
                ids.Add(Guid.NewGuid());
            }

            return ids;
        }

        private static List<string> GenerateSocialSecurityNumbers(int count)
        {
            var resultList = new List<string>();

            var random = new Random();

            const string numbers = "0123456789";

            for (var j = 0; j < count; j++)
            {
                var result = new char[10];

                for (var i = 0; i < result.Length; i++)
                {
                    result[i] = numbers[random.Next(numbers.Length)];
                }

                resultList.Add(new string(result));
            }
            return resultList;
        }
    }
}
