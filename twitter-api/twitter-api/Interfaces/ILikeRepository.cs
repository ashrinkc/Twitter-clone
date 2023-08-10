using Microsoft.AspNetCore.Mvc;
using twitter_api.Models;

namespace twitter_api.Interfaces
{
    public interface ILikeRepository
    {
        Task<IEnumerable<User>> GetUserLikedPostsOrComments(int postOrcommentId);
        Task<Like> FindLikedPosts(int postId, int userId);
        Task<bool> Add(Like like);
        Task<bool> Remove(Like like);
        Task<bool> Save();

    }
}
