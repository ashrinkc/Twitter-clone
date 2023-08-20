using Microsoft.AspNetCore.Mvc;
using twitter_api.Dto;
using twitter_api.Interfaces;
using twitter_api.Models;

namespace twitter_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

       

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userRepository.GetById(id);
            if(user == null)
            {
                return NotFound();
            }
            var delete = await _userRepository.Delete(user);
            if (!delete)
            {
                return BadRequest("User delete fail");
            }
            return Ok("User deleted successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetById(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("/api/followUnfollow")]
        public async Task<IActionResult> FollowUnfollowUser(FollowUnfollowDto data)
        {
            var flo = await _userRepository.FollowUnfollowUser(data.userId,data.followId);
            if (!flo)
            {
                return BadRequest();
            }
            return Ok("Successfully updated");
        }

        [HttpPost("/api/isFollowed")]
        public async Task<IActionResult> IsFollowed(FollowUnfollowDto data)
        {
            var flo = await _userRepository.GetIsFollowedOrNot(data.userId,data.followId);
            return Ok(flo);
        }

        [HttpGet("/followCount/{userId}")]
        public async Task<IActionResult> GetFollowCount(int userId)
        {
            var followersCount = await _userRepository.getFollowCount(userId);
            return Ok(followersCount);
        }

        [HttpGet("/followers/{userId}")]
        public async Task<IActionResult> GetFollowers(int userId)
        {
            var followers = await _userRepository.GetFollowers(userId);
            return Ok(followers);
        }

        [HttpGet("/followingCount/{userId}")]
        public async Task<IActionResult> GetFollowingsCount(int userId)
        {
            var followingsCount = await _userRepository.getFollowingCount(userId);
            return Ok(followingsCount);
        }

        [HttpGet("/followings/{userId}")]
        public async Task<IActionResult> GetFollowings(int userId)
        {
            var followings = await _userRepository.GetFollowings(userId);
            return Ok(followings);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User user)
        {
            var updatedUser = await _userRepository.Update(user);
            return Ok(updatedUser);
        }
    }
}
