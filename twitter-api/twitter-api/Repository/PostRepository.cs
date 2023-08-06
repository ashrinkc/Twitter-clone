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
        public bool Create(Post post)
        {
            _context.Posts.Add(post);
            return Save();
        }


        public async Task<bool> DecreaseComment(int postId)
        {
            var post = await GetById(postId);
            if(post.comments == 0)
            {
                return false;
            }
            post.comments -= 1;
            return Save();
        }


        public async Task<bool> DecreaseLike(int postId)
        {
            var post = await GetById(postId);
            if (post.likes == 0)
            {
                return false;
            }
            post.likes -= 1;
            return Save();
        }

        public async Task<bool> DecreaseQuote(int postId)
        {
            var post = await GetById(postId);
            if (post.quotes == 0)
            {
                return false;
            }
            post.quotes -= 1;
            return Save();
        }

        public bool Delete(Post post)
        {
            _context.Posts.Remove(post);
            return Save();
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetById(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Post>> GetByUsers(int userId)
        {
            return await _context.Posts.Where(c => c.CreatorId == userId).ToListAsync();
        }

        public async Task<bool> IncreaseComment(int postId)
        {
            var post = await GetById(postId);
            post.comments += 1;
            return Save();
        }


        public async Task<bool> IncreaseLike(int postId)
        {
            var post = await GetById(postId);
            post.likes += 1;
            return Save();
        }

        public async Task<bool> IncreaseQuote(int postId)
        {
            var post = await GetById(postId);
            post.quotes += 1;
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
