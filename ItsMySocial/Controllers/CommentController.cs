using Contracts;
using Dtos;
using Infrastructure;
using ItsMySocialDomain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItsMySocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        // POST api/<CommentController>
        [HttpPost]
        public async Task<ActionResult> AddcommentAsync([FromBody] CommentDto commentdto)
        {
            if (commentdto != null)
            {
                try
                {
                    var comment = new Comment { Contenet=commentdto.Content,PostId=commentdto.postId,UserId=commentdto.userId};
                    
                    await _commentRepository.AddCommentAsync(comment);
                    return Ok("comment added successfully");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest();
        
        }
        // PUT api/<CommentController>/5
        [HttpPatch("{id}")]
        public async Task<ActionResult> EditComment(long id, [FromBody] string content)

        {
            if (string.IsNullOrEmpty(content))
            {
                return BadRequest();
            }
            else
            {
                try
                {

                    await _commentRepository.updateCommentAsync(id, content);
                    return Ok("comment edited");

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

        }  

            // DELETE api/<CommentController>/5
            [HttpDelete("{id}")]
            public async Task<ActionResult> Delete(long id)
            {
                try
                {

                    await _commentRepository.DeleteCommentAsync(id);
                    return Ok("Comment deleted");

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);

                }

            }
        
    }
}
