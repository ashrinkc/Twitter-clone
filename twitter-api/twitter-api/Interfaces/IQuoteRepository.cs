using twitter_api.Models;

namespace twitter_api.Interfaces
{
    public interface IQuoteRepository
    {
        Task<IEnumerable<Quote>> GetUserQuote(int id);
        Task<IEnumerable<Quote>> GetQuotes(int userId);
        bool Create(Quote quote);
        bool Delete(Quote quote);
        bool Save();

    }
}
