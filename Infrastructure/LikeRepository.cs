using Contracts;
using ItsMySocialContext;
using ItsMySocialDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
   public class LikeRepository : ILikeRepository
    {
        private readonly socialDbContext socialdbcontext;
        public LikeRepository(socialDbContext socialdbcontext)
        {
            this.socialdbcontext = socialdbcontext;
        }
        public async Task AddLikeAsync(Like like)
        {
           var result =await socialdbcontext.Likes.AddAsync(like);
           var post = await socialdbcontext.Posts.FindAsync(like.PostId);
             post.Likes_count++;
            await socialdbcontext.SaveChangesAsync();
            
        }

        public async Task RemoveLikeAsync(long PostId,long UserId)
        {
            var likeToDelet = await socialdbcontext.Likes.FirstOrDefaultAsync(l => l.PostId == PostId && l.UserId == UserId);
            if (likeToDelet != null) 
            {
                socialdbcontext.Likes.Remove(likeToDelet);
                var post = await socialdbcontext.Posts.FindAsync(PostId);
                post.Likes_count--;
                await socialdbcontext.SaveChangesAsync();
            }
        }
    }
}
