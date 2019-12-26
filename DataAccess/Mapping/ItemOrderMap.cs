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
    public class ItemOrderMap: IEntityTypeConfiguration<ItemOrder>
    {
        public void Configure(EntityTypeBuilder<ItemOrder> builder)
        {
            builder.ToTable("TbItemOrder");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ItemPrice);
            builder.Property(x => x.ItemProductQuantity).IsRequired();
            builder.HasOne(x => x.OrderItem).WithMany(x => x.Items);
            builder.HasOne(x => x.ItemProduct).WithOne(x => x.ItemOrder);
        }
    }
}
