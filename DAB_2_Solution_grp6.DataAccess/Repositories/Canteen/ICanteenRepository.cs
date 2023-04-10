using DAB_2_Solution_grp6.DataAccess.Entities;

namespace DAB_2_Solution_grp6.DataAccess.Repositories.Canteen
{
    public interface ICanteenRepository
    {
        Task<Entities.Menu> GetDailyMenuForCanteen(string canteenName);
    }
}
