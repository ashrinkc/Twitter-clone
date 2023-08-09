using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
        public async Task<bool> Create(User user)
        {
            _context.Users.Add(user);
            return await Save();
        }

        public async Task<bool> Delete(User user)
        {
            _context.Users.Remove(user);
            return await Save();
        }

        public async Task<bool> FollowUnfollowUser(int userId, int followId)
        {
            var ifExists = _context.Followers.FirstOrDefault(c => c.UserId == followId  && c.FollowersId == userId);
 
            if (ifExists != null)
            {
                _context.Followers.Remove(ifExists);
                //Remove following as well
                var following = _context.Followings.FirstOrDefault(c=>c.UserId==userId && c.FollowingId == followId);
                if(following != null)
                {
                    _context.Followings.Remove(following);

                }
            }
            else
            {
                _context.Followers.Add(new Follower { UserId=followId,FollowersId=userId});
                _context.Followings.Add(new Following { UserId=userId, FollowingId=followId});

            }
            return await Save();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<int> getFollowCount(int userId)
        {
            return await _context.Followers
                 .Where(c => c.UserId == userId)
                 .CountAsync();
        }

        public async Task<IEnumerable<User>> GetFollowers(int userId)
        {
            return await _context.Followers
                .Include(f => f.User)
                .Where(c=>c.UserId==userId)
                .Select(c=>c.User)
                .ToListAsync();
        }

        public async Task<int> getFollowingCount(int userId)
        {
            return await _context.Followings
                 .Where(c => c.UserId == userId)
                 .CountAsync();
        }

        public async Task<IEnumerable<User>> GetFollowings(int userId)
        {
            return await _context.Followings
                .Include(f => f.User)
                .Where(c => c.UserId == userId)
                .Select(c => c.User)
                .ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> Update(User user)
        {
            _context.Users.Update(user);
            return await Save();
        }
    }
}
