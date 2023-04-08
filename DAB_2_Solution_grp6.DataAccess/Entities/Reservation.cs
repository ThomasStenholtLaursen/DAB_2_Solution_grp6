namespace DAB_2_Solution_grp6.DataAccess.Entities
{
    public class Reservation
    {
        public Guid ReservationId { get; }
        public int? WarmQuantity { get; }
        public int? StreetQuantity { get; }
        public DateTime Created { get; }
        public string Cpr { get; }
        public Guid MenuId { get; }
        public List<Meal>? Meals { get; private set; } = new();

        public Reservation(Guid reservationId, int? warmQuantity, int? streetQuantity, DateTime created, string cpr, Guid menuId)
        {
            ReservationId = reservationId;
            WarmQuantity = warmQuantity;
            StreetQuantity = streetQuantity;
            Created = created;
            Cpr = cpr;
            MenuId = menuId;
        }
    }
}
