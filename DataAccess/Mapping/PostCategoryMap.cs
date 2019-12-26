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
    public class PostCategoryMap : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            builder.ToTable("TbPostCategory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PostCategoryName).HasMaxLength(60).IsRequired();
            builder.HasMany(x => x.Posts).WithOne(x => x.PostCategories);
        }
    }
}
