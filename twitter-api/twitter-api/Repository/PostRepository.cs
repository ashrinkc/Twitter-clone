using Microsoft.EntityFrameworkCore;
using twitter_api.Data;
using twitter_api.Interfaces;
using twitter_api.Models;

namespace twitter_api.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        } 
        public async Task<bool> Create(Post post)
        {
            _context.Posts.Add(post);
            return await Save();
        }


        public async Task<bool> DecreaseComment(int postId)
        {
            var post = await GetById(postId);
            if(post.comments == 0)
            {
                return false;
            }
            post.comments -= 1; 
            return await Save();
        }


        public async Task<bool> DecreaseLike(int postId)
        {
            var post = await GetById(postId);
            if (post.likes == 0)
            {
                return false;
            }
            post.likes -= 1;
            return await Save();
        }

        public async Task<bool> DecreaseQuote(int postId)
        {
            var post = await GetById(postId);
            if (post.quotes == 0)
            {
                return false;
            }
            post.quotes -= 1;
            return await Save();
        }

        public async Task<bool> Delete(Post post)
        {
            _context.Posts.Remove(post);
            return await Save();
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _context.Posts.Include(p=>p.User).ToListAsync();
        }

        public async Task<IEnumerable<int>> GetAllFollingUserId(int userId)
        {
            var Ids = await _context.Followings.Where(c => c.UserId == userId)
                .Select(c => c.FollowingId).ToListAsync();
            return Ids;
        }

        public async Task<Post> GetById(int id)
        {
            return await _context.Posts.Include(c=>c.User).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Post>> GetByUsers(int userId)
        {
            return await _context.Posts.Include(c=>c.User).Where(c => c.userId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsAndQuotesByUser(int userId)
        {
            var posts = await _context.Posts
                .Include(p => p.User)
                .Where(p => p.userId == userId)
                .ToListAsync();
            var quotesPost = await _context.Quotes
                .Include(p => p.Post)
                .Include(c => c.Post.User)
                .Include(c => c.Comment)
                .Where(q => q.userId == userId)
                .Select(q => q.Post)
                .ToListAsync();
           // var allPosts = posts.Concat(quotesPost).OrderByDescending(p => p.createdDate);
            var allPosts = posts.Concat(quotesPost);
            return posts;
        }

        public async Task<bool> IncreaseComment(int postId)
        {
            var post = await GetById(postId);
            post.comments += 1;
            return await Save();
        }


        public async Task<bool> IncreaseLike(int postId)
        {
            var post = await GetById(postId);
            post.likes += 1;
            return await Save();
        }

        public async Task<bool> IncreaseQuote(int postId)
        {
            var post = await GetById(postId);
            post.quotes += 1;
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
