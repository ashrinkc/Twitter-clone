namespace twitter_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string? image { get; set; }
        public DateTime joinDate { get; set; } = DateTime.Now;
    }
}
