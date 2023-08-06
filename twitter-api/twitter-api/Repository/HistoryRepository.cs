using Microsoft.EntityFrameworkCore.Migrations;
using twitter_api.Data;
using twitter_api.Models;
using twitter_api.Interfaces;

namespace twitter_api.Repository
{
    public class HistoryRepository :IHistoryyRepository
    {
        private readonly ApplicationDbContext _context;

        public HistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(History history)
        {
            _context.Histories.Add(history);
            return Save();
        }

        public bool Delete(History history)
        {
            _context.Histories.Remove(history);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
