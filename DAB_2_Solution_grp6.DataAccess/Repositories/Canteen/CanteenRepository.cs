using System.Xml.Schema;
using DAB_2_Solution_grp6.DataAccess.Exceptions;
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

        public async Task<Entities.Canteen> GetCanteenByIdAsync(Guid canteenId)
        {
            var canteen = await _dbContext.Canteens
                .FirstOrDefaultAsync(x => x.CanteenId == canteenId);

            return canteen ?? throw new CanteenNotFoundException();
        }

        public async Task<Entities.Canteen> GetCanteenWithMenusByNameAsync(string canteenName)
        {
            var canteen = await _dbContext.Canteens
                .Include(x=> x.Menus)
                .FirstOrDefaultAsync(x => x.Name == canteenName);

            return canteen ?? throw new CanteenNotFoundException();
        }

        public async Task<Entities.Canteen> GetCanteenWithMenusAndReservationsByNameAsync(string canteenName)
        {
            var canteen = await _dbContext.Canteens
                .Include(x => x.Menus)!
                .ThenInclude(y => y.Reservations)
                .FirstOrDefaultAsync(x => x.Name == canteenName);

            return canteen ?? throw new CanteenNotFoundException();
        }

        public async Task<Entities.Canteen> GetCanteenWithMealsByNameAsync(string canteenName)
        {
            var canteen = await _dbContext.Canteens
                .Include(x => x.Meals)
                .FirstOrDefaultAsync(x => x.Name == canteenName);

            return canteen ?? throw new CanteenNotFoundException();
        }

        public async Task<IReadOnlyList<Entities.Canteen>> GetNearbyCanteenMealsByNameAsync(string canteenName)
        {
            var canteen = await _dbContext.Canteens.FirstOrDefaultAsync(x => x.Name == canteenName) ?? throw new CanteenNotFoundException();

            var nearbyCanteens = await _dbContext.Canteens
                .Include(x => x.Meals)
                .Where(x => x.PostalCode == canteen.PostalCode)
                .ToListAsync();

            nearbyCanteens.Remove(canteen!);

            return nearbyCanteens;
        }

        public async Task<IReadOnlyList<Entities.Canteen>> GetAllCanteensWithRatings()
        {
            var canteens = await _dbContext.Canteens
                .Include(x => x.Ratings)
                .ToListAsync();

            return canteens;
        }

        public async Task<Entities.Canteen> GetCanteenCompleteByNameAsync(string canteenName)
        {
            var canteen = await _dbContext.Canteens
                .Include(x => x.Menus)!
                .Include(x => x.Ratings)
                .Include(x => x.Meals)
                .FirstOrDefaultAsync(x => x.Name == canteenName);

            return canteen ?? throw new CanteenNotFoundException();
        }
    }
}
