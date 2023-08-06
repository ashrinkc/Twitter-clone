using twitter_api.Models;

namespace twitter_api.Interfaces
{
    public interface IHistoryyRepository
    {
        bool Add(History history);
        bool Delete(History history);
        bool Save();
    }
}
