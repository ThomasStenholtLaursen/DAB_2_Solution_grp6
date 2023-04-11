namespace DAB_2_Solution_grp6.DataAccess.Repositories.Canteen
{
    public interface ICanteenRepository
    {
        Task<Entities.Canteen> GetCanteenByIdAsync(Guid canteenId);
        Task<List<Entities.Canteen>> GetAllCanteens();
        Task<Entities.Canteen> GetCanteenWithMenusByNameAsync(string canteenName);
        Task<Entities.Canteen> GetCanteenWithMenusAndReservationsByNameAsync(string canteenName);
        Task<Entities.Canteen> GetCanteenWithMealsByNameAsync(string canteenName);
        Task<IReadOnlyList<Entities.Canteen>> GetNearbyCanteenMealsByNameAsync(string canteenName);
        Task<IReadOnlyList<Entities.Canteen>> GetAllCanteensWithRatingsAsync();
        Task<Entities.Canteen> GetAllCanteenWithStaffByNameAsync(string canteenName);
    }
}
