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
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("TbUserRole");
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.UserRoleName).HasMaxLength(60).IsRequired();
            //builder.HasMany(x => x.Users).WithOne(x => x.UserRole);
        }
    }
}
