using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Pattern.Interface
{
   public  interface ICustomerInterface : IRepository<Customer>
    {
        IList<Customer> GetByName(string name);
        Customer GetByUserId(int userId);
        Order GetOrder(int id);
    }
}
