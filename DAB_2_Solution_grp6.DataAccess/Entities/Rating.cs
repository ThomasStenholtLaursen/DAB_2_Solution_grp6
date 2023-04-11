namespace DAB_2_Solution_grp6.DataAccess.Entities
{
    public class Rating
    {
        public Guid RatingId { get; }
        public decimal Stars { get; }
        public DateTime Created { get; }
        public Guid CanteenId { get; }
        public string? Comment { get; }
        public string? AuId { get; }

        public Rating(Guid ratingId, decimal stars, DateTime created, string? comment, string? auId, Guid canteenId)
        {
            RatingId = ratingId;
            Stars = stars;
            Created = created;
            Comment = comment;
            AuId = auId;
            CanteenId = canteenId;
        }
    }
}
