using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using twitter_api.Interfaces;
using twitter_api.Models;

namespace twitter_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddMessage(Message msg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var message = await _messageRepository.Add(msg);
            if (!message)
            {
                return BadRequest("Message not sent");
            }
            return Ok(message);
        }

        [HttpGet("{senderId}")]
        public async Task<IActionResult> GetMessage(int senderId)
        {
            var message = await _messageRepository.GetMsg(senderId);
            return Ok(message);
        } 
    }
}
