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

        public async Task<Entities.Canteen> GetCanteenByNameAsync(string canteenName)
        {
            var canteen = await _dbContext.Canteens.FirstOrDefaultAsync(x => x.Name == canteenName);

            return canteen ?? throw new CanteenNotFoundException();
        }
    }
}
