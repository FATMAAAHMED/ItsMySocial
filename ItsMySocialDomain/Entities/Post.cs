using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsMySocialDomain.Entities
{
    public class Post
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public DateTime timeStamp { get; set; } = DateTime.Now;
        public int Likes_count { get; set; }
        public int Comments_count { get; set; }
        public int Shares_count { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public ICollection<Like>? Likes { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Share>? Shares { get; set; }


    }
}
