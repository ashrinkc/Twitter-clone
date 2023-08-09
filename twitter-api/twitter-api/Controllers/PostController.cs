using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using twitter_api.Interfaces;
using twitter_api.Models;

namespace twitter_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly ILikeRepository _likeRepository;

        public PostController(IPostRepository postRepository, ILikeRepository likeRepository)
        {
            _postRepository = postRepository;
            _likeRepository = likeRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var create = await _postRepository.Create(post);
            if (!create)
            {
                return BadRequest("Post create failed");
            }
            return Ok(create);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _postRepository.GetById(id);
            if(post == null)
            {
                return NotFound();
            }
            var delete = await _postRepository.Delete(post);
            if (!delete)
            {
                return BadRequest("Delete fail");
            }
            return Ok("Post successfully deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts([FromQuery] int userId)
        {
            var posts = await _postRepository.GetAll();
            var likePosts = await _likeRepository.GetUserLikedPostsOrComments();
            for(int i = 0; i < posts.Count(); i++)
            {
                
            }
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetById(id);
            return Ok(post);
        }

        [HttpGet("/userPosts/{userId}")]
        public async Task<IActionResult> GetUserPosts(int userId)
        {
            var posts = await _postRepository.GetByUsers(userId);
            return Ok(posts);
        }

        [HttpGet("/userPostsQuotes/{userId}")]
        public async Task<IActionResult> GetUserPostsQuotes(int userId)
        {
            var postsAndQuotes = await _postRepository.GetPostsAndQuotesByUser(userId);
            return Ok(postsAndQuotes);
        }

        //like post
        [HttpPost("/like/{postId}")]
        public async Task<IActionResult> LikePost(int postId)
        {
            //in likerepo check if like is already presnt by the user before creating new like
            //if like is already present call remove function to remove the like
            //send like added or removed as return type so you can u can increase or decrease
            //the like 
            // Also while sending post check if the user has already liked th post
            return Ok();
        }
    }
}
