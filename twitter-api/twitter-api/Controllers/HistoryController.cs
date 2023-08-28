using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using twitter_api.Interfaces;
using twitter_api.Models;

namespace twitter_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryyRepository _historyRepository;

        public HistoryController(IHistoryyRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddHistory(History history)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var added = await _historyRepository.Add(history);
            if (!added)
            {
                return BadRequest("History not added");
            }
            return Ok("Histpry added successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getUserHistory(int id)
        {
            var history = await _historyRepository.GetUserHistory(id);
            return Ok(history);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteHistory(int id)
        {
            var history = await _historyRepository.GetById(id);
            await _historyRepository.Delete(history);
            return Ok("History deleted");
        }
    }
}
