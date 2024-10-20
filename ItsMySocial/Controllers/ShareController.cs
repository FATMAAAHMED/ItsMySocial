using Contracts;
using Dtos;
using ItsMySocialDomain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItsMySocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShareController : ControllerBase
    {
        private readonly IShareRepository shareRepository;
        public ShareController( IShareRepository shareRepository)
        {
            this.shareRepository = shareRepository;
            
        }
        
     
    
        // POST api/<ShareController>
        [HttpPost]
        public async Task<ActionResult>SharePost(long postId,[FromBody] long userId)
        {
                await shareRepository.sharepost(postId,userId);
             return Ok();

        }

    }
}
