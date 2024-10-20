using ItsMySocialContext;
using ItsMySocialDomain.Entities;
using Contracts;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure
{
    public class PostRepository:IPostRepository
    {
        private readonly socialDbContext socialdbcontext;
        public PostRepository(socialDbContext socialdbcontext)
        {
            this.socialdbcontext = socialdbcontext;
        }

        public async Task<Post> AddPostAsync(Post post)
        {
            var p= await socialdbcontext.Posts.AddAsync(post);
            await socialdbcontext.SaveChangesAsync();
            return p.Entity;
        }

        public async Task DeletePostAsync(long postId)
        {
            var post=socialdbcontext.Posts.FirstOrDefault(p => p.Id == postId);
            if (post != null)
            {
                socialdbcontext.Posts.Remove(post);
                await socialdbcontext.SaveChangesAsync();
            }
        }

        public async Task<Post> GetPostByIdAsync(long postId)
        {
             var post = await  socialdbcontext.Posts.Include(p=>p.Comments)
                .Include(p=>p.Likes)
                .Include(p=>p.Shares)
                .FirstOrDefaultAsync(p=>p.Id== postId);
             
             return post;
        }

        public async Task<IEnumerable<Comment>> GetPostCommentsAsync(long postId)
        {
            var post = socialdbcontext.Posts.Include(p=>p.Comments).FirstOrDefault(p=>p.Id==postId);
            //Post post = socialdbcontext.Posts.Include(p => p.Comments);
            var comments = post.Comments.ToList();
            return comments;
        }

        public Task<IEnumerable<Like>> GetPostLikesAsync(long postId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await socialdbcontext.Posts.ToListAsync();
        }
        
        public async Task<Post> UpdatePostAsync(long Id ,string post)
        {
            var P = await socialdbcontext.Posts.FirstOrDefaultAsync(p => p.Id ==Id);
            if (P != null) { 
            
                P.Content = post;

                await socialdbcontext.SaveChangesAsync();
            }
            return null;
        }
       
    }
}
