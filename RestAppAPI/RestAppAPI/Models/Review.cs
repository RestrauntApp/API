namespace RestAppAPI.Models
{
    public class Review
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int restId { get; set; }
        public int reviewNum { get; set; }
        public DateOnly reviewDate { get; set; }

        public Review() { }
    }
}
