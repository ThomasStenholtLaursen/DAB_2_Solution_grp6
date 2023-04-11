namespace DAB_2_Solution_grp6.Api.Controllers.CanteenApp.Response.Query2
{
    public class ReservationForUserResponse
    {
        public string CanteenName { get; set; } = null!;
        public List<MealReservationDescription>? MealReservations { get; set; } = new();
    }

    public class MealReservationDescription
    {
        public Guid MealId { get; set; }
        public string MealName { get; set; } = null!;
    }
}
