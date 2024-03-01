
using ItsMySocialDomain.Configurations;
using ItsMySocialDomain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ItsMySocialContext
{
    public class socialDbContext:IdentityDbContext<User,IdentityRole<long>, long>
    {
        public socialDbContext(DbContextOptions<socialDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new PostConfiguration().Configure(modelBuilder.Entity<Post>());
            new LikeConfiguration().Configure(modelBuilder.Entity<Like>());
            new CommentConfiguration().Configure(modelBuilder.Entity<Comment>());
            new ShareConfiguration().Configure(modelBuilder.Entity<Share>());
            new MessageConfiguration().Configure(modelBuilder.Entity<Message>());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Share> Shares { get; set; }
        public DbSet<Message> Messages { get; set; }



    }
}
