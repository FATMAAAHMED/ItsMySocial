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
    public class commentRepository : ICommentRepository
    {
        private readonly socialDbContext socialDbContext;
        public commentRepository( socialDbContext socialDbContext)
        {
            this.socialDbContext = socialDbContext;
        }
        public async Task AddCommentAsync(Comment comment)
        {
            await socialDbContext.Comments.AddAsync(comment);
            var post = await socialDbContext.Posts.FindAsync(comment.PostId);
            post.Comments_count++;
            await socialDbContext.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(long Id)
        {
            var CommentToDelet =await socialDbContext.Comments.FirstOrDefaultAsync(c => c.Id == Id);
            if (CommentToDelet != null)
            {
                socialDbContext.Comments.Remove(CommentToDelet);
                var post = await socialDbContext.Posts.FindAsync(CommentToDelet.PostId);
                post.Comments_count--;
                await socialDbContext.SaveChangesAsync();
            }
        }

   

        public async Task updateCommentAsync(long Id, string content)
        {
            var commentToUpdate = await  socialDbContext.Comments.FirstOrDefaultAsync(c=>c.Id==Id);
            if (commentToUpdate != null) 
            {
                commentToUpdate.Contenet=content;
                await socialDbContext.SaveChangesAsync();

            }
        }
    }
}
