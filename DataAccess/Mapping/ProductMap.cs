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
    public class ProductMap : IEntityTypeConfiguration<ProductDb>
    {

        public void Configure(EntityTypeBuilder<ProductDb> builder)
        {
            builder.ToTable("TbProduct");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductCod).HasMaxLength(10);
            builder.Property(x => x.ProductDetails).HasMaxLength(500).IsRequired();
            builder.Property(x => x.ProductName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ProductPrice).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ProductImageName).HasMaxLength(50);
            builder.Property(x => x.ProductImagePath).HasMaxLength(300);
            builder.HasOne(x => x.Category).WithMany(x => x.Products);
            builder.HasOne(x => x.ItemOrder).WithOne(x => x.ItemProduct);
            
        }
    }
}
