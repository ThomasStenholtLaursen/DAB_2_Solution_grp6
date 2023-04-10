using DAB_2_Solution_grp6.DataAccess.Entities;

namespace DAB_2_Solution_grp6.Api.Controllers.CanteenApp.Response
{
    public class AvailableMealsResponse
    {
        public IReadOnlyList<JitMeal> JitMeals { get; set; } = new List<JitMeal>();
        public IReadOnlyList<Meal> CanceledMeals { get; set; } = new List<Meal>();
    }
}
