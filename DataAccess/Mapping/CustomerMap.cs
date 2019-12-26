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
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("TbCustomer");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CustomerName).HasMaxLength(60).IsRequired();
            builder.Property(x => x.CustomerEmail).HasMaxLength(200).IsRequired();
            builder.Property(x => x.CustomerAddress).HasMaxLength(200);
            builder.Property(x => x.CustomerPassword).HasMaxLength(60);
            builder.Property(x => x.CustomerPhone).HasMaxLength(15);
            builder.HasMany(x => x.Orders).WithOne(x => x.OrderCustomer);
        }
    }
}
