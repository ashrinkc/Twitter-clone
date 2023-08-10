namespace twitter_api.Dto
{
    public class UserLikePostDto
    {
        public int Id { get; set; }
        public int postId { get; set; }
        public int userId { get; set; }
        public string? description { get; set; }
        public string? image { get; set; }
        public int CreatorId { get; set; }
        public int likes { get; set; } 
        public int quotes { get; set; } 
        public int comments { get; set; } 
        public DateTime createdDate { get; set; } 
    }
}
