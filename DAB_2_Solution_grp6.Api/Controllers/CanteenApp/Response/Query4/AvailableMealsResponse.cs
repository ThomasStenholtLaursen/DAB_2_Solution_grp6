namespace DAB_2_Solution_grp6.Api.Controllers.CanteenApp.Response.Query4
{
    public class AvailableMealsResponse
    {
        public List<SimpleJitMeal> JitMeals { get; set; } = new();
        public List<SimpleMeal> CanceledMeals { get; set; } = new();
    }
    public class SimpleMeal
    {
        public string Name { get; set; } = null!;
    }

    public class SimpleJitMeal
    {
        public string Name { get; set; } = null!;
    }
}
