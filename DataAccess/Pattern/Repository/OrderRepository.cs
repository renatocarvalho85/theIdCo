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
    public class OrderRepository : IOrderInterface
    {
        private readonly Context.Context _context;
        public OrderRepository(Context.Context context)
        {
            _context = context;
        }
        public bool Create(Order data)
        {
            _context.Orders.Add(data);
            _context.SaveChanges();
            return true;

        }

        public bool CreateItemOrder(ItemOrder data)
        {
            _context.ItemOrders.Add(data);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var order =_context.Orders.Find(id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteItem(int id)
        {
            var ItemOrder = _context.ItemOrders.Find(id);
            _context.ItemOrders.Remove(ItemOrder);
            _context.SaveChanges();
            return true;
        }

        public IList<Order> GetOrders(int id)
        {
            return _context.Orders.Include(x => x.Items).Where(x => x.OrderCustomerId == id).ToList();
        }
        public IList<Order> Get()
        {
            return _context.Orders.ToList();
        }

        public Order Get(int id)
        {
            return _context.Orders.Find(id);
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.Find(id);
        }

        public IList<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public ItemOrder GetItemOrder(int id)
        {
            return _context.ItemOrders.Include(p => p.ItemProduct).Where(x => x.Id == id).FirstOrDefault();
        }

        public IList<ItemOrder> GetItemOrders(int id)
        {
            return _context.ItemOrders.Include(p => p.ItemProduct).Where(x => x.OrderItemId == id).ToList();
        }

        public bool Update(Order data)
        {
            _context.Entry<Order>(data).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public bool UpdateItem(ItemOrder data)
        {
            _context.Entry<ItemOrder>(data).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
