using Azure.Core.Pipeline;
using Contracts;
using ItsMySocialContext;
using ItsMySocialDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ShareRepository :IShareRepository
    {
        private readonly socialDbContext _socialDbContext;
        public ShareRepository( socialDbContext socialDbContext) { 

            _socialDbContext = socialDbContext;
    
        }

        public async Task sharepost(long postId, long userId)
        {
                var share = new Share
                {
                    PostId = postId,
                    UserId = userId,
                };
            await _socialDbContext.Shares.AddAsync(share);
            var originalPost = await _socialDbContext.Posts.FindAsync(postId);
            if (originalPost != null) {
                originalPost.Shares_count++;
                await _socialDbContext.SaveChangesAsync();  
            }



        }
    }
}
