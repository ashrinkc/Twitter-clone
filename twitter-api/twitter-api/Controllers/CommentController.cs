using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections;
using twitter_api.Dto;
using twitter_api.Interfaces;
using twitter_api.Models;
using twitter_api.Repository;

namespace twitter_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly IQuoteRepository _quoteRepository;

        public CommentController(ICommentRepository commentRepository, IPostRepository postRepository,
            ILikeRepository likeRepository, IQuoteRepository quoteRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _likeRepository = likeRepository;
            _quoteRepository = quoteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Comment comment)
        {
            _commentRepository.Add(comment);
            return Ok("Comment added successfully");
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetComment(int postId, [FromQuery] int? userId)
        {
            var comments = await _commentRepository.GetCommentByPost(postId);
            if (userId == null)
            {
                return Ok(comments);
            }
            else
            {
                var arlist = new ArrayList();
                foreach(var comment in comments)
                {
                    var isLiked = await _likeRepository.FindLikedPosts(comment.Id, (int)userId);
                    arlist.Add(new
                    {
                        Id=comment.Id,
                        commentorId=comment.userId,
                        postId=comment.postId,
                        comment=comment.comment,
                        like=comment.like,
                        quotes=comment.quotes,
                        date=comment.Created,
                        creatorName = comment.User.username,
                        creatorEmail = comment.User.email,
                        isLike =isLiked!=null,
                    });
                }
                return Ok(arlist);
            }
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var comment = await _commentRepository.GetById(commentId);
            _commentRepository.Delete(comment);
            return Ok("Successfully deleted");
        }

        //like/dislike comment
        [HttpPost("/api/like")]
        public async Task<IActionResult> LikeDislikeComment(AddComment data)
        {
            var likeComment = await _likeRepository.FindLikedPosts(data.commentId, data.userId);
            if (likeComment != null)
            {
                await _likeRepository.Remove(likeComment);
                await _commentRepository.DecreaseLike(data.commentId);
            }
            else
            {
                var like = new Like
                {
                    postOrcommentId = data.commentId,
                    userId = data.userId
                };
                await _likeRepository.Add(like);
                await _commentRepository.IncreaseLike(data.commentId);
            }
            return Ok("Successfully updated");
        }

        [HttpPost("/quote/{commentId}")]
        public async Task<IActionResult> CreateQuote(int commentId, [FromQuery] int userId)
        {
            var quote = new Quote
            {
                userId = userId,
                commentId = commentId,
            };
            _quoteRepository.Create(quote);
            await _commentRepository.IncreaseQuote(commentId);
            return Ok("Quote created");
        }
    }
}
