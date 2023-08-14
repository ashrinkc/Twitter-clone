namespace twitter_api.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public int? userId { get; set; }
        public int? postOrcommentId { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public bool IsQuote { get; set; } = true;

        public User User { get; set; }
        public Post Post { get; set; }
        public Comment Comment { get; set; }
    }
}
