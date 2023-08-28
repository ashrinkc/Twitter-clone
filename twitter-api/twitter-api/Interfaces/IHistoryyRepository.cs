using twitter_api.Models;

namespace twitter_api.Interfaces
{
    public interface IHistoryyRepository
    {
        Task<History> GetById(int id);
        Task<bool> Add(History post);
        Task<bool> Delete(History post);
        Task<bool> Save();
        Task<IEnumerable<History>> GetUserHistory(int userId);
    }
}
