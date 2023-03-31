namespace DAB_2_Solution_grp6.DataAccess.Entities
{
    public class Reservation
    {
        public Guid ReservationId { get; }
        public string Cpr { get; }
        public DateTime Created { get; set; }
        public List<Meal> Meals { get; private set; } = new();

        public Reservation(Guid reservationId, string cpr, DateTime created)
        {
            ReservationId = reservationId;
            Cpr = cpr;
            Created = created;
        }
    }
}
