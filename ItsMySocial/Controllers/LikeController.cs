using Contracts;
using Infrastructure;
using ItsMySocialDomain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItsMySocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeRepository _likeRepository;
        public LikeController( ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }
       
        // POST api/<LikeController>
        [HttpPost]
        public async Task<ActionResult> AddLikeAsync (long postId, long userId)
        {
            var like = new Like { PostId = postId, UserId = userId };
            if (like != null)
            {
                try
                {
                    await _likeRepository.AddLikeAsync(like);
                    return Ok();
                }
                catch (Exception ex) {
                    return BadRequest(ex.Message);
                        }
            }
        return BadRequest();
        }


        // DELETE api/<LikeController>/5
        [HttpDelete]
        public async Task<ActionResult> RemoveLikeAsync(long PostId, long UserId)
        {
            try
            {

                await _likeRepository.RemoveLikeAsync(PostId, UserId);
                return Ok("Like deleted");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
