namespace DAB_2_Solution_grp6.DataAccess.Entities
{
    public class Reservation
    {
        public Guid ReservationId { get; }
        public Guid MealId { get; set; }
        public string Cpr { get; }
        public DateTime Created { get; set; }
        public List<Meal> Meals { get; } = new();

        public Reservation(Guid reservationId, Guid mealId, string cpr, DateTime created)
        {
            ReservationId = reservationId;
            MealId = mealId;
            Cpr = cpr;
            Created = created;
        }
    }
}
