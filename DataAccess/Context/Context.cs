using DataAccess.Mapping;
using DataAccess.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class Context : IdentityDbContext<User,UserRole,int>
    {
      

        public DbSet<ProductDb> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ItemOrder> ItemOrders { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
       // public DbSet<User> Users { get; set; }
       // public DbSet<UserLogin> UserLogins { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductMap());           
            modelBuilder.ApplyConfiguration(new ProductCategoryMap());
            //modelBuilder.ApplyConfiguration(new UserMap());
            //modelBuilder.ApplyConfiguration(new UserLoginMap());
            //modelBuilder.ApplyConfiguration(new UserRoleMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new PostCategoryMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new ItemOrderMap());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MaggieCardConnection"].ConnectionString));
        }
    }
}
