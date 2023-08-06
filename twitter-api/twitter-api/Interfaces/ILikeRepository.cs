using twitter_api.Models;

namespace twitter_api.Interfaces
{
    public interface ILikeRepository
    {
        Task<IEnumerable<User>> GetUserLikedPostsOrComments(int postOrcommentId);
        bool Add(Like like);
        bool Remove(Like like);
        bool Save();

    }
}
