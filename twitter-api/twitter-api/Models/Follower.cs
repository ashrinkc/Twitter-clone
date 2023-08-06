namespace twitter_api.Models
{
    public class Follower
    {
        public int UserId { get; set; }
        public int FollowersId { get; set; }

        public User User { get; set; }
    }
}
