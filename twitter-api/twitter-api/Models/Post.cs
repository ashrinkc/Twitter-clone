namespace twitter_api.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? description { get; set; }
        public string? image { get; set; }
        public int CreatorId { get; set; }
        public int likes { get; set; } = 0;
        public int quotes { get; set; } = 0;
        public int comments { get; set; } = 0;
        public DateTime createdDate { get; set; } = DateTime.Now;

        public User User { get; set; }

    }
}
