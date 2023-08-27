using Microsoft.EntityFrameworkCore.Migrations;
using twitter_api.Data;
using twitter_api.Models;
using twitter_api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace twitter_api.Repository
{
    public class HistoryRepository :IHistoryyRepository
    {
        private readonly ApplicationDbContext _context;

        public HistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<bool> Add(History history)
        {
            _context.Histories.Add(history);
            return await Save();
        }


        public async Task<bool> Delete(History history)
        {
            _context.Histories.Remove(history);
            return await Save();
        }

        public async Task<IEnumerable<History>> GetUserHistory(int userId)
        {
            return await _context.Histories.Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

    }
}
