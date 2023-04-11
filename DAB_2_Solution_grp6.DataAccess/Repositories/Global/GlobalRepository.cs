namespace DAB_2_Solution_grp6.DataAccess.Repositories.Global
{
    public class GlobalRepository : IGlobalRepository
    {
        private readonly CanteenAppDbContext _dbContext;

        public GlobalRepository(CanteenAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task RemoveAll()
        {
            var meals = _dbContext.Meals.Where(x => true);
            _dbContext.Meals.RemoveRange(meals);

            var reservations = _dbContext.Reservations.Where(x => true);
            _dbContext.Reservations.RemoveRange(reservations);

            var ratings = _dbContext.Ratings.Where(x => true);
            _dbContext.Ratings.RemoveRange(ratings);

            var customers = _dbContext.Customers.Where(x => true);
            _dbContext.Customers.RemoveRange(customers);

            var menus= _dbContext.Menus.Where(x => true);
            _dbContext.Menus.RemoveRange(menus);

            var canteens = _dbContext.Canteens.Where(x => true);
            _dbContext.Canteens.RemoveRange(canteens);

            await _dbContext.SaveChangesAsync();
        }
    }
}
