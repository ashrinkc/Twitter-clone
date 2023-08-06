using Microsoft.EntityFrameworkCore;
using twitter_api.Data;
using twitter_api.Interfaces;
using twitter_api.Models;

namespace twitter_api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(User user)
        {
            _context.Users.Add(user);
            return Save();
        }

        public bool Delete(User user)
        {
            _context.Users.Remove(user);
            return Save();
        }

        public bool FollowUser(Follower user)
        {
            var ifExists = _context.Followers.Where(c => c.UserId ==  && c.FollowersId == userId);
            if (ifExists.Any())
            {
                _context.Followers.Remove();
                return Save();
            }
            _context.Followers.Add();
            return Save();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(User user)
        {
            _context.Users.Update(user);
            return Save();
        }
    }
}
