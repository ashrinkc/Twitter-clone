using twitter_api.Models;

namespace twitter_api.Interfaces
{
    public interface IMessageRepository
    {
        Task<bool> Add(Message msg);
        Task<IEnumerable<Message>> GetMsg(int senderId);
        Task<bool> Save();
    }
}
