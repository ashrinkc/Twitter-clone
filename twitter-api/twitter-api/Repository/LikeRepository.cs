using Microsoft.EntityFrameworkCore;
using twitter_api.Data;
using twitter_api.Interfaces;
using twitter_api.Models;

namespace twitter_api.Repository
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationDbContext _context;

        public LikeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Like like)
        {
            _context.Likes.Add(like);
            return Save();
        }

        public async Task<IEnumerable<User>> GetUserLikedPostsOrComments(int postOrcommentId)
        {
            return await _context.Likes.
                Include(c => c.User)
                .Where(c => c.postOrcommentId == postOrcommentId)
                .Select(c => c.User)
                .ToListAsync();
        }

        public bool Remove(Like like)
        {
            _context.Likes.Remove(like);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
