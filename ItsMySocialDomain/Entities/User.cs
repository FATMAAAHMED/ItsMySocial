
using Microsoft.AspNetCore.Identity;

namespace ItsMySocialDomain.Entities
{
    public class User : IdentityUser<long>
    { 
    
      //  public string UserName { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Bio { get; set; }
        public DateTime DateJoined { get; set; } = DateTime.Now;
        public ICollection<Post>? Posts { get; set; }
        //public ICollection<Like>? Likes { get; set; }
        //public ICollection<Comment>? Comments { get; set; }
        //public ICollection<Share>? Shares { get; set; }
        public ICollection<Message>? Messages { get; set; }
        public ICollection<User>? Friends { get; set; }

    }
}
