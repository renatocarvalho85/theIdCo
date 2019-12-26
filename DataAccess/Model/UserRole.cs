using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class UserRole : IdentityRole<int>
    {
        //public UserRole()
        //{
        //    this.Users = new List<User>();
        //}
        ////public int Id { get; set; }
        //public string UserRoleName { get; set; }
        //public virtual ICollection<User> Users{ get; set; }
    }
}
