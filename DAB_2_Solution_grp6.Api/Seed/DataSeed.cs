using DAB_2_Solution_grp6.DataAccess;
using DAB_2_Solution_grp6.DataAccess.Entities;

namespace DAB_2_Solution_grp6.Api.Seed
{
    public static class DataSeed
    {
        public static void Seed(CurrentDbContext context)
        {
            SeedModels(context);
            
        }

        private static void SeedModels(CurrentDbContext context)
        {
            if (context.Canteens.Any())
            {
                return;
            }

            var canteens = new[]
            {
                new Canteen(Guid.Parse("dcf735c5-09cd-430a-aec0-bc77c5089088"), "Kgl. Bibliotek",
                    "Victor Albecks Vej 1", "8000")
            };

            context.Canteens.AddRange(canteens);
            context.SaveChangesAsync();
        }
    }
}
