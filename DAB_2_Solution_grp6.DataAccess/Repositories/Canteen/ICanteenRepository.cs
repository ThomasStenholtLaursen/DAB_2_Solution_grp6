namespace DAB_2_Solution_grp6.DataAccess.Repositories.Canteen
{
    public interface ICanteenRepository
    {
        Task<Entities.Canteen> GetCanteenByIdAsync(Guid canteenId);
        Task<Entities.Canteen> GetCanteenWithMenusByNameAsync(string canteenName);
        Task<Entities.Canteen> GetCanteenWithMenusAndReservationsByNameAsync(string canteenName);
        Task<Entities.Canteen> GetCanteenWithMealsAndJitMealsByNameAsync(string canteenName);
        Task<IReadOnlyList<Entities.Canteen>> GetNearbyCanteenMealsByNameAsync(string canteenName);
        Task<IReadOnlyList<Entities.Canteen>> GetAllCanteensWithRatings();
        Task<Entities.Canteen> GetCanteenCompleteByNameAsync(string canteenName);
    }
}
