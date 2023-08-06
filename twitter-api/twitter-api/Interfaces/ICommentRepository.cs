using twitter_api.Models;

namespace twitter_api.Interfaces
{
    public interface ICommentRepository
    {
        Task<bool> IncreaseLike(int commentId);
        Task<bool> DecreaseLike(int commentId);
        Task<bool> IncreaseQuote(int commentId);
        Task<bool> DecreaseQuote(int commentId);
        Task<Comment> GetById(int id);
        Task<IEnumerable<Comment>> GetCommentByPost(int postId);
        bool Add(Comment comment);
        bool Delete(Comment comment);
        bool Save();
    }
}
