using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using twitter_api.Dto;
using twitter_api.Interfaces;
using twitter_api.Models;

namespace twitter_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("/api/register")]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var emailExists = await _userRepository.GetByEmail(user.email);
            var usernameExists = await _userRepository.GetByUsername(user.username);
            if(emailExists != null || usernameExists != null)
            {
                return BadRequest("Username or email already exists");
            }
            var create = await _userRepository.Create(user);
            if (!create)
            {
                return BadRequest("User create fail");
            }
            return Ok("User created successfully");
        }

        [HttpPost("/api/login")]
        public async Task<IActionResult> Login(LoginDto data)
        {
            var user = await _userRepository.GetByUsername(data.username);
            if(user == null)
            {
                return NotFound();
            }
            if (user.password != data.password)
            {
                return BadRequest("Incorrect passsword");
            }
            return Ok(user);
        }
    }
}
