using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections;
using System.Linq.Expressions;
using twitter_api.Dto;
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
        private readonly IQuoteRepository _quoteRepository;

        public PostController(IPostRepository postRepository, ILikeRepository likeRepository,
            IQuoteRepository quoteRepository)
        {
            _postRepository = postRepository;
            _likeRepository = likeRepository;
            _quoteRepository = quoteRepository;
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
        public async Task<IActionResult> GetAllPosts([FromQuery] int? userId)
        {
            var posts = await _postRepository.GetAll();

            if (userId == null)
            {
                return Ok(posts);

            }
            else
            {
                var arlist = new ArrayList();
                foreach (var post in posts)
                {
                    var likePosts = await _likeRepository.FindLikedPosts(post.Id,(int)userId);
                    if (likePosts == null)
                    {
                      
                        arlist.Add(new {
                            id=post.Id,
                            creatorId=post.userId,
                            likes=post.likes,
                            comments=post.comments,
                            quotes=post.quotes,
                            description=post.description,
                            createdDate=post.createdDate,
                            creatorName=post.User.username,
                            creatorEmail=post.User.email,
                            IsLike=false
                        });
                    }
                    else
                    {
                        arlist.Add(new
                        {
                            id = post.Id,
                            creatorId = post.userId,
                            likes = post.likes,
                            comments = post.comments,
                            quotes = post.quotes,
                            description = post.description,
                            createdDate = post.createdDate,
                            creatorName = post.User?.username,
                            creatorEmail = post.User?.email,
                            IsLike = true
                        });
                    }
                }
                return Ok(arlist);
            }
            
        }

        [HttpGet("/api/getFollowingsPost/{userId}")]
        public async Task<IActionResult> getFollowingsPost(int userId)
        {
            var userIds = await _postRepository.GetAllFollingUserId(userId);
            var arlist = new ArrayList();
            foreach (var id in userIds) {
                var posts = await _postRepository.GetByUsers(id);
                foreach (var post in posts)
                {
                    var likePosts = await _likeRepository.FindLikedPosts(post.Id, userId);
                    arlist.Add(new
                    {
                        id = post.Id,
                        creatorId = post.userId,
                        likes = post.likes,
                        comments = post.comments,
                        quotes = post.quotes,
                        description = post.description,
                        createdDate = post.createdDate,
                        creatorName = post.User.username,
                        creatorEmail = post.User.email,
                        isLike = likePosts != null,
                    });
                }
            }
            return Ok(arlist);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetById(id);
            return Ok(post);
        }

        [HttpGet("/api/userPosts/{userId}")]
        public async Task<IActionResult> GetUserPosts(int userId)
        {
            var posts = await _postRepository.GetByUsers(userId);
            return Ok(posts);
        }

        [HttpGet("/api/userQuotes/{userId}")]
        public async Task<IActionResult> GetUserQuotes(int userId)
        {
            var quotes = await _quoteRepository.GetQuotes(userId);
            return Ok(quotes);
        }

        [HttpGet("/api/userPostsQuotes/{userId}")]
        public async Task<IActionResult> GetUserPostsQuotes(int userId)
        {
            var postsAndQuotes = await _postRepository.GetPostsAndQuotesByUser(userId);

            var arlist = new ArrayList();
            foreach (var post in postsAndQuotes)
            {
                var likePosts = await _likeRepository.FindLikedPosts(post.Id, userId);
                arlist.Add(new
                {
                    id = post.Id,
                    creatorId = post.userId,
                    likes = post.likes,
                    comments = post.comments,
                    quotes = post.quotes,
                    description = post.description,
                    createdDate = post.createdDate,
                    creatorName = post.User.username,
                    creatorEmail = post.User.email,
                    isLike = likePosts != null,
                });
            }
            //var quotes = await _quoteRepository.GetQuotes(userId);
           // arlist.Add(quotes);
            return Ok(arlist);
        }

        //like/dislike post
        [HttpPost("/api/likeUnlike")]
        public async Task<IActionResult> LikeDislikePost(LikeDto data)
        {
            var likePosts = await _likeRepository.FindLikedPosts(data.postId, data.userId);
            if(likePosts != null)
            {
                await _likeRepository.Remove(likePosts);
                await _postRepository.DecreaseLike(data.postId);
            }
            else
            {
                var like = new Like
                {
                    postOrcommentId = data.postId,
                    userId = data.userId
                };
                await _likeRepository.Add(like);
                await _postRepository.IncreaseLike(data.postId);
            }
            return Ok("Successfully updated");
        }

        [HttpPost("/api/quote/{postId}")]
        public async Task<IActionResult> CreateQuote(int postId, [FromQuery] int userId)
        {
            var quote = new Quote
            {
                userId = userId,
                postId = postId,
            };
            _quoteRepository.Create(quote);
            await _postRepository.IncreaseQuote(postId);
            return Ok("Quote created");
        }

        
    }
}
