namespace DAB_2_Solution_grp6.DataAccess.Entities
{
    public class Rating
    {
        public Guid RatingId { get; }
        public decimal Stars { get; }
        public DateTime Created { get; }
        public Guid CanteenId { get; }
        public string? Comment { get; }
        public string? Cpr { get; }

        public Rating(Guid ratingId, decimal stars, DateTime created, string? comment, string? cpr, Guid canteenId)
        {
            RatingId = ratingId;
            Stars = stars;
            Created = created;
            Comment = comment;
            Cpr = cpr;
            CanteenId = canteenId;
        }
    }
}
