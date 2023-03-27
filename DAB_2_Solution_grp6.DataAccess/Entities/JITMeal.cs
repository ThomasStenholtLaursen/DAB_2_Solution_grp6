namespace DAB_2_Solution_grp6.DataAccess.Entities
{
    public class JITMeal
    {
        public Guid JITMealId { get; }
        public string JITName { get; }
        public Guid CanteenId { get; }

        public JITMeal(Guid jitMealId, string jitName, Guid canteenId)
        {
            JITMealId = jitMealId;
            JITName = jitName;
            CanteenId = canteenId;
        }
    }
}
