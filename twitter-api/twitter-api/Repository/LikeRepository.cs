using Microsoft.AspNetCore.Mvc;
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
        public async Task<bool> Add(Like like)
        {
            _context.Likes.Add(like);
            return await Save();
        }

        public async Task<IEnumerable<User>> GetUserLikedPostsOrComments(int postOrcommentId)
        {
            return await _context.Likes.
                Include(c => c.User)
                .Where(c => c.postOrcommentId == postOrcommentId)
                .Select(c => c.User)
                .ToListAsync();
        }

        public async Task<Like> FindLikedPosts(int postId,int userId)
        {
            return await _context.Likes
            .FirstOrDefaultAsync(c => c.postOrcommentId == postId && c.userId == userId)
        ;
        }

        public async Task<bool> Remove(Like like)
        {
            _context.Likes.Remove(like);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
