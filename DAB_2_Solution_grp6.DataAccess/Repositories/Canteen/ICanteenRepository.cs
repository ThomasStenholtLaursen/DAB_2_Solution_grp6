namespace DAB_2_Solution_grp6.DataAccess.Repositories.Canteen
{
    public interface ICanteenRepository
    {
        Task<Entities.Canteen> GetCanteenByNameAsync(string canteenName);
    }
}
