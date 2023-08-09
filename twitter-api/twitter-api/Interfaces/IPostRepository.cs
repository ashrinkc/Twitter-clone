using twitter_api.Models;

namespace twitter_api.Interfaces
{
    public interface IPostRepository
    {
        Task<Post> GetById(int id);
        Task<IEnumerable<Post>> GetAll();
        Task<IEnumerable<Post>> GetByUsers(int userId);
        Task<IEnumerable<Post>> GetPostsAndQuotesByUser(int userId);
        Task<bool> IncreaseLike(int postId);
        Task<bool> DecreaseLike(int postId);
        Task<bool> IncreaseQuote(int postId);
        Task<bool> DecreaseQuote(int postId);
        Task<bool> IncreaseComment(int postId);
        Task<bool> DecreaseComment(int postId);
        Task<bool> Create(Post post);
        Task<bool> Delete(Post post);
        Task<bool> Save();
    }
}
