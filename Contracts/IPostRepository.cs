using ItsMySocialDomain.Entities;

namespace Contracts
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>>GetPostsAsync();
        Task<Post> GetPostByIdAsync(long postId);
        Task<Post> AddPostAsync(Post post);
        Task<Post> UpdatePostAsync(long Id ,string post);
        Task DeletePostAsync(long postId);
        Task<IEnumerable<Comment>> GetPostCommentsAsync( long postId);
        Task<IEnumerable<Like>> GetPostLikesAsync(long postId);


    }
}
