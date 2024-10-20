using Contracts;
using Infrastructure;
using ItsMySocialDomain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.Eventing.Reader;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItsMySocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            this._postRepository = postRepository;
        }
        // GET: api/<PostController>
        [HttpGet]
        public async Task<ActionResult> GetPosts()
        {
            try
            {
                return Ok(await _postRepository.GetPostsAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPostById(long id)
        {
            try
            {
                return Ok(await _postRepository.GetPostByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<PostController>
        [HttpPost]
        public async Task<ActionResult> CreatePost([FromBody] string postcontent, long userId)
        {
            try
            {
                var post = new Post { Content = postcontent, UserId = userId };
                if (post == null)
                    return BadRequest("post is null");

                var createdPost = await _postRepository.AddPostAsync(post);
                return Ok(createdPost);
            }
            catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PostController>/5
        [HttpPatch("{id}")]
        public async Task<ActionResult<Post>> UpdatePost(long id, [FromBody] string postcontent)
        {
            try
            {
                if (id == null)
                    return BadRequest();


                return await _postRepository.UpdatePostAsync(id, postcontent);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(long id)
        {
            try
            {

                await _postRepository.DeletePostAsync(id);
                return Ok("post deleted");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        //[HttpGet("{postId}")]
        //public async Task<ActionResult> GetPostComments(long postId)
        //{
        //    return Ok( await _postRepository.GetPostCommentsAsync(postId));

        //}
        //[HttpGet("{postId}")]
        //public async Task<ActionResult> GetPostLikes(long postId)
        //{

        //}
    }
}
