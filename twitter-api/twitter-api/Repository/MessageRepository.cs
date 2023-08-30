using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using twitter_api.Data;
using twitter_api.Interfaces;
using twitter_api.Models;

namespace twitter_api.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Message msg)
        {
            _context.Messages.Add(msg);
            return await Save();
        }

        public async Task<IEnumerable<Message>> GetMsg(int senderId)
        {
            return await _context.Messages.Include(u => u.Receiver)
                .Where(c => c.SenderId == senderId || c.ReceiverId == senderId).OrderByDescending(c=>c.dateTime).ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
