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
    public class OrderMap: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("TbOrder");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OrderCreateDate);
            builder.Property(x => x.OrderPlacedDate);
            builder.Property(x => x.OrderTotal);
            builder.Property(x => x.StatusShip).HasMaxLength(60);
            builder.Property(x => x.StatusOrder).HasMaxLength(60);
            builder.HasOne(x => x.OrderCustomer).WithMany(x => x.Orders);
            builder.HasMany(x => x.Items).WithOne(x => x.OrderItem);
        }
    }
}
