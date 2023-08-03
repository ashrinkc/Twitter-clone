using Microsoft.EntityFrameworkCore;
using twitter_api.Models;

namespace twitter_api.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
