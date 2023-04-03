﻿using DAB_2_Solution_grp6.DataAccess;
using DAB_2_Solution_grp6.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAB_2_Solution_grp6.Api.Seed
{
    public static class DataSeed
    {
        public static async Task Seed(CurrentDbContext context)
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

            var canteenIds = GenerateIdentifiers(10);
            var socialSecurityNumbers = GenerateSocialSecurityNumbers(10);
            var menuIds = GenerateIdentifiers(10);

            await SeedCanteens(context, canteenIds);
            await SeedCustomers(context, socialSecurityNumbers);
            await SeedRatings(context, canteenIds);
            await SeedMenus(context, canteenIds, menuIds);
            await SeedReservations(context, canteenIds, menuIds);
            await SeedMeals(context, canteenIds);
            await SeedJustInTimeMeals(context, canteenIds);
        }

        private static async Task SeedCanteens(CurrentDbContext context, IReadOnlyList<Guid> ids)
        {
            var canteens = new[]
            {
                new Canteen(ids[0], "Kgl. Bibliotek","Victor Albecks Vej 1", "8000")
            };

            context.Canteens.AddRange(canteens);
            await context.SaveChangesAsync();
        }

        private static async Task SeedCustomers(CurrentDbContext context, IReadOnlyList<string> cprs)
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

        private static async Task SeedRatings(CurrentDbContext context, IReadOnlyList<Guid> ids)
        {
            var ratings = new[]
            {
                new Rating(Guid.NewGuid(), 5, new DateTime(2023, 01, 03, 10, 30, 00), "It was the best!", "1234567890",
                    ids[0])
            };

            context.Ratings.AddRange(ratings);
            await context.SaveChangesAsync();
        }

        private static async Task SeedMenus(CurrentDbContext context, IReadOnlyList<Guid> canteenIds, IReadOnlyList<Guid> menuIds)
        {
            var menus = new[]
            {
                new Menu(menuIds[0], "Soup", "Pizza", new DateTime(2023, 04, 03, 09, 10, 00), canteenIds[0])
            };

            context.Menus.AddRange(menus);
            await context.SaveChangesAsync();
        }

        private static async Task SeedReservations(CurrentDbContext context, IReadOnlyList<Guid> canteenIds, IReadOnlyList<Guid> menuIds)
        {

        }

        private static async Task SeedMeals(CurrentDbContext context, IReadOnlyList<Guid> guids)
        {

        }

        private static async Task SeedJustInTimeMeals(CurrentDbContext context, IReadOnlyList<Guid> guids)
        {

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
