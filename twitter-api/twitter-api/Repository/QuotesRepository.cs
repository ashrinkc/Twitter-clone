﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using twitter_api.Data;
using twitter_api.Interfaces;
using twitter_api.Models;

namespace twitter_api.Repository
{
    public class QuotesRepository : IQuoteRepository
    {
        private readonly ApplicationDbContext _context;

        public QuotesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(Quote quote)
        {
            _context.Quotes.Add(quote);
            return Save();
        }

        public bool Delete(Quote quote)
        {
            _context.Quotes.Remove(quote);
            return Save();
        }

        public async Task<IEnumerable<Quote>> GetUserQuote(int id)
        {
            return await _context.Quotes.Where(q => q.userId == id).ToListAsync();
        }

        public async Task<IEnumerable<Quote>> GetQuotes(int userId)
        {
            var quotesPost = await _context.Quotes
                .Include(p => p.Post)
                .Include(c => c.Post.User)
                .Include(c => c.Comment)
                .Where(q => q.userId == userId)
                .ToListAsync();
            return quotesPost;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
