﻿namespace DAB_2_Solution_grp6.Api.Controllers.CanteenApp.Response.Query5
{
    public class AvailableNearbyMealsResponse
    {
        public List<NearbyMeal> NearbyMeals { get; set; } = new();
    }

    public class NearbyMeal
    {
        public string CanteenName { get; set; } = null!;
        public string MealName { get; set; } = null!;
    }
}
