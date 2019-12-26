using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Pattern.Interface
{
    public interface IUserInterface : IRepository<User>
    {
        IList<User> GetByName(string name);
        IList<UserRole> GetUserRoles();
        User GetUserRoles(int id);
        bool CreateUserRole(UserRole data);
        List<User> GetUserAndRole();
    }
}
