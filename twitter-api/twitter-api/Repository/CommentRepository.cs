using Microsoft.EntityFrameworkCore;
using twitter_api.Data;
using twitter_api.Interfaces;
using twitter_api.Models;

namespace twitter_api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Comment comment)
        {
            _context.Comments.Add(comment);
            return Save();
        }

        public async Task<bool> DecreaseLike(int commentId)
        {
            var comment = await GetById(commentId);
            if(comment.like == 0)
            {
                return false;
            }
            comment.like -= 1;
            return Save();
        }

        public async Task<bool> DecreaseQuote(int commentId)
        {
            var comment = await GetById(commentId);
            if (comment.quotes == 0)
            {
                return false;
            }
            comment.quotes -= 1;
            return Save();
        }

        public bool Delete(Comment comment)
        {
            _context.Comments.Remove(comment);
            return Save();
        }

        public async Task<Comment> GetById(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Comment>> GetCommentByPost(int postId)
        {
            return await _context.Comments.Where(c => c.postId == postId).ToListAsync();
        }

        public async Task<bool> IncreaseLike(int commentId)
        {
            var comment = await GetById(commentId);
            comment.like += 1;
            return Save();
        }

        public async Task<bool> IncreaseQuote(int commentId)
        {
            var comment = await GetById(commentId);
            comment.quotes += 1;
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
