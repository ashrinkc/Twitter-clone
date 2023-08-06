using twitter_api.Models;

namespace twitter_api.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<IEnumerable<User>> GetAll();
        bool FollowUser(); //Reminder: make dto as  you need to retrieve both user and follower id. use params to get one id
        bool Create(User user);
        bool Update(User user);
        bool Delete(User user);
        bool Save();
    }
}
