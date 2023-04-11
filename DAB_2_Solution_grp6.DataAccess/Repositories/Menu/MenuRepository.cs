using DAB_2_Solution_grp6.DataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DAB_2_Solution_grp6.DataAccess.Repositories.Menu
{
    public class MenuRepository : IMenuRepository
    {
        private readonly CanteenAppDbContext _dbContext;

        public MenuRepository(CanteenAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> GetCanteenIdForMenuAsync(Guid id)
        {
            var menu = await _dbContext.Menus.FirstOrDefaultAsync(x => x.MenuId == id);

            if (menu == null)
            {
                throw new MenuNotFoundException();
            }

            return menu.CanteenId;
        }
    }
}
