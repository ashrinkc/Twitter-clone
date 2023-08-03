namespace twitter_api.Models
{
    public class History
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Search { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public User User { get; set; }
    }
}
