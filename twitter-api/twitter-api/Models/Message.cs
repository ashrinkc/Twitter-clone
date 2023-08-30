using Microsoft.EntityFrameworkCore;

namespace twitter_api.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public string message { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;

        public User? Sender { get; set; }
        public User? Receiver { get; set; }
    }

}
