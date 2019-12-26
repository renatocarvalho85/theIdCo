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
    public class ProductCategoryMap : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("TbProductCategory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductCategoryName).HasMaxLength(50).IsRequired();
            builder.HasMany(x => x.Products).WithOne(x => x.Category);
        }
    }
}
