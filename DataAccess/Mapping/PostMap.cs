using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("TbPost");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PostTitle).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PostSubTitle).HasMaxLength(60).IsRequired();
            builder.Property(x => x.PostDetails).HasMaxLength(200);
            builder.Property(x => x.PostDate);
            builder.HasOne(x => x.PostCategories).WithMany(x => x.Posts);
            builder.HasOne(x => x.Products);
        }
    }
}
