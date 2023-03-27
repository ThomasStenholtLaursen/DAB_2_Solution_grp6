namespace DAB_2_Solution_grp6.DataAccess.Entities
{
    public class Customer
    {
        public string Cpr { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public List<Rating> Ratings { get; } = new();

        public Customer(string cpr, string firstName, string lastName)
        {
            Cpr = cpr;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
