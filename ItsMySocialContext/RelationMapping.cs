using ItsMySocialDomain.Entities ;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsMySocialContext
{
    public static class RelationMapping
    {
        public static void MapRelations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.Posts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            

            modelBuilder.Entity<User>()
              .HasMany(x => x.Messages)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.User_Id)
               .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<User>()
            //  .HasMany(x => x.Friends)
            //   .WithMany()
            //   .UsingEntity(j => j.ToTable("UserFriends"));




            modelBuilder.Entity<Post>()
                .HasMany(x => x.Likes)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
                .HasMany(x => x.Shares)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.NoAction);






        }
    }
}
