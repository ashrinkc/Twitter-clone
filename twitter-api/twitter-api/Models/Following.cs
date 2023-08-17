namespace twitter_api.Models
{
    public class Following
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FollowingId { get; set; }

        public User? User { get; set; }  
    }
}
