namespace DAB_2_Solution_grp6.DataAccess.Entities
{
    public class Rating
    {
        public Guid RatingId { get; }
        public decimal Stars { get; }
        public DateTime Created { get; }
        public string CanteenId { get; }
        public string? Comment { get; }
        public string? Cpr { get; }

        public Rating(Guid ratingId, decimal stars, DateTime created, string canteenId, string? comment, string? cpr)
        {
            RatingId = ratingId;
            Stars = stars;
            Created = created;
            CanteenId = canteenId;
            Comment = comment;
            Cpr = cpr;
        }
    }
}
