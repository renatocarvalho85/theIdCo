using DataAccess.Model;
using DataAccess.Pattern.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Pattern.Repository
{
    //public class UserRepository : IUserInterface
    //{
    //    private Context.Context _context;
    //    public UserRepository(Context.Context context)
    //    {
    //        _context = context;
    //    }
    //    public bool Create(User data)
    //    {
    //        try
    //        {
    //            _context.Users.Add(data);
    //            _context.SaveChanges();
    //            return true;
    //        }
    //        catch 
    //        {

    //            return false;
    //        }
            
    //    }

    //    public bool Delete(int id)
    //    {
    //        try
    //        {
    //            var user = _context.Users.Find(id);
    //            if (user != null)
    //            {
    //                _context.Users.Remove(user);
    //                _context.SaveChanges();
    //                return true;
    //            }else
    //            return false;
    //        }
    //        catch 
    //        {

    //            return false;
    //        }
    //    }

        

    //    public IList<User> Get()
    //    {
    //        return _context.Users.ToList();
    //    }

    //    public User Get(int id)
    //    {
    //        return _context.Users.Find(id);
    //    }

    //    public IList<User> GetByName(string name)
    //    {
    //        return _context.Users.Where(x => x.UserName.Contains(name)).ToList();
    //    }

    //    public User GetUserRoles(int id)
    //    {
    //        return _context.Users.Include(x => x.UserRole).Where(c => c.Id == id).FirstOrDefault();
    //    }
    //    public List<User> GetUserAndRole()
    //    {
    //        return _context.Users.Include(x => x.UserRole).ToList();
    //    }
    //    public bool Update(User data)
    //    {
    //        try
    //        {
    //            _context.Entry<User>(data).State = EntityState.Modified;
    //            _context.SaveChanges();
    //            return true;
    //        }
    //        catch 
    //        {

    //            return false;
    //        }
    //    }
       
    //    public IList<UserRole> GetUserRoles()
    //    {
    //        return _context.UserRoles.Include(x => x.Users).ToList();
    //    }
    //    public bool CreateUserRole(UserRole data)
    //    {
    //        if (data != null)
    //        {
    //            _context.UserRoles.Add(data);
    //            _context.SaveChanges();
    //            return true;
    //        }
    //        else
    //            return false;
    //    }

    //    public void Dispose()
    //    {
    //        _context.Dispose();
    //    }

        
    //}
}
