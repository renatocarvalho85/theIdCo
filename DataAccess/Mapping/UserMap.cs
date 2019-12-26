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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("TbUser");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).HasMaxLength(60).IsRequired();
            //builder.Property(x => x.UserFullName).HasMaxLength(100).IsRequired();
            //builder.Property(x => x.UserEmail).HasMaxLength(200).IsRequired();
            //builder.Property(x => x.UserPassword).HasMaxLength(60).IsRequired();
            //builder.HasOne(x => x.UserRole).WithMany(x => x.Users);
        }
    }
}
