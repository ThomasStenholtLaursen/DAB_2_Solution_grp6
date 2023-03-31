namespace DAB_2_Solution_grp6.DataAccess.Entities
{
    public class JitMeal
    {
        public Guid JitMealId { get; }
        public string JitName { get; }
        public Guid CanteenId { get; }

        public JitMeal(Guid jitMealId, string jitName, Guid canteenId)
        {
            JitMealId = jitMealId;
            JitName = jitName;
            CanteenId = canteenId;
        }
    }
}
