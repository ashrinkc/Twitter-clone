﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections;
using System.Linq.Expressions;
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

        //like/dislike post
        [HttpPost("/like/{postId}")]
        public async Task<IActionResult> LikeDislikePost(int postId,int userId)
        {
            var likePosts = await _likeRepository.FindLikedPosts(postId, userId);
            if(likePosts != null)
            {
                await _likeRepository.Remove(likePosts);
                await _postRepository.DecreaseLike(postId);
            }
            else
            {
                var like = new Like
                {
                    postOrcommentId = postId,
                    userId = userId
                };
                await _likeRepository.Add(like);
                await _postRepository.IncreaseLike(postId);
            }
            return Ok("Successfully updated");
        }

        [HttpPost("/quote/{postId}")]
        public async Task<IActionResult> CreateQuote(int postId, [FromQuery] int userId)
        {
            var quote = new Quote
            {
                userId = userId,
                postOrcommentId = postId,
            };
            _quoteRepository.Create(quote);
            await _postRepository.IncreaseQuote(postId);
            return Ok("Quote created");
        }

        
    }
}
