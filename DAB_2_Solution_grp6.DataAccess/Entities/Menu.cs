namespace DAB_2_Solution_grp6.DataAccess.Entities
{
    public class Menu
    {
        public Guid MenuId { get; }
        public string WarmFoodName { get; }
        public string StreetFoodName { get; }
        public DateTime Created { get; set; }
        public Guid CanteenId { get; }
        public List<Reservation> Reservations { get; } = new();


        public Menu(Guid menuId, string warmFoodName, string streetFoodName, DateTime created, Guid canteenId)
        {
            MenuId = menuId;
            WarmFoodName = warmFoodName;
            StreetFoodName = streetFoodName;
            Created = created;
            CanteenId = canteenId;
        }
    }
}
