namespace DAB_2_Solution_grp6.DataAccess.Entities
{
    public class Canteen
    {
        public Guid CanteenId { get; }
        public string Name { get; }
        public string Address { get; }
        public string PostalCode { get; }
        public List<Rating> Ratings { get; } = new();


        public Canteen(Guid canteenId, string name, string address, string postalCode)
        {
            CanteenId = canteenId;
            Name = name;
            Address = address;
            PostalCode = postalCode;
        }
    }
}
