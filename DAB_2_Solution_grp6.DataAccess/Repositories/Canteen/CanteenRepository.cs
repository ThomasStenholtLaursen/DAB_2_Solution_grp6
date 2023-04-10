using Microsoft.EntityFrameworkCore;

namespace DAB_2_Solution_grp6.DataAccess.Repositories.Canteen
{
    public class CanteenRepository : ICanteenRepository
    {
        private readonly CanteenAppDbContext _dbContext;

        public CanteenRepository(CanteenAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Entities.Menu> GetDailyMenuForCanteen(string canteenName)
        {
            var canteen = await _dbContext.Canteens.FirstOrDefaultAsync(x => x.Name == canteenName);

            if (canteen == null)
            {
                throw new Exception();
            }

            var menu = await _dbContext.Menus.Where(x => x.CanteenId == canteen.CanteenId).FirstOrDefaultAsync(); //TODO: Missing DateTime Compare

            if (menu == null)
            {
                throw new Exception();
            }

            return menu;
        }
    }
}
