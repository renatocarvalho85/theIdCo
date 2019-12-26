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
    public class CustomerRepository : ICustomerInterface
    {
        private Context.Context  _context;
        public CustomerRepository(Context.Context context)
        {
            _context = context;
        }
        public bool Create(Customer data)
        {
            try
            {
                _context.Customers.Add(data);
                _context.SaveChanges();
                return true;
            }
            catch 
            {

                return false;
            }
            
        }

        public bool Delete(int id)
        {
            try
            {
               var customer = _context.Customers.Find(id);
                if (customer != null)
                {
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();
                    return true;
                }else
                return false;
            }
            catch
            {

                return false;
            }
        }

        public IList<Customer> Get()
        {
            return _context.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return _context.Customers.Find(id);
        }

        public Order GetOrder(int id)
        {
            return _context.Orders.Include(x => x.OrderCustomer).Include(i => i.Items).
                                  Where(c => c.OrderCustomerId == id).
                                  OrderBy(x => x.StatusOrder == "Waiting").
                                  FirstOrDefault();
        }


        public IList<Customer> GetByName(string name)
        {
            return _context.Customers.Where(x => x.CustomerName.Contains(name)).ToList();
        }

        public bool Update(Customer data)
        {
            try
            {
                _context.Entry<Customer>(data).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch 
            {

                return false;
            }
           
        }
        public Customer GetByUserId(int userId)
        {
            return _context.Customers.Where(x => x.UserId == userId).FirstOrDefault();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
       
    }
}
