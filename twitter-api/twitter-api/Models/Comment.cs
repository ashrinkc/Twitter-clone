

using System.ComponentModel.DataAnnotations.Schema;

namespace twitter_api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int? userId { get; set; } 
        public int? postId { get; set; }  
        public string comment { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public int like { get; set; } = 0;
        public int quotes { get; set; } = 0;

        public User? User { get; set; }
        public Post? Post { get; set; }
    }
}
