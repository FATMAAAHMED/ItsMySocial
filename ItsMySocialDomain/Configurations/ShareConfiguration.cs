
using ItsMySocialDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsMySocialDomain.Configurations
{ 
    public class ShareConfiguration : IEntityTypeConfiguration<Share>
    {
        public void Configure(EntityTypeBuilder<Share> builder)
        {
           builder.HasKey(x => new {x.PostId,x.UserId});
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.PostId).IsRequired();

        }
    }
}
