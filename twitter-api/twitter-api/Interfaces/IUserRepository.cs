using twitter_api.Models;

namespace twitter_api.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<IEnumerable<User>> GetAll();
        bool FollowUnfollowUser(int userId, int followId); //Reminder: make dto as  you need to retrieve both user and follower id. use params to get one id
        Task<int> getFollowCount(int userId);
        Task<int> getFollowingCount(int userId);
        Task<IEnumerable<User>> GetFollowers(int userId);
        Task<IEnumerable<User>> GetFollowings(int userId);
        bool Create(User user);
        bool Update(User user);
        bool Delete(User user);
        bool Save();
    }
}
