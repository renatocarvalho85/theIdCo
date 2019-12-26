using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Pattern.Interface
{
    public interface IOrderInterface : IRepository<Order>
    {
        ItemOrder GetItemOrder(int id);
        bool DeleteItem(int id);
        bool UpdateItem(ItemOrder data);
        IList<Order> GetOrders(int id);
        IList<ItemOrder> GetItemOrders(int id);
        bool CreateItemOrder(ItemOrder data);
        Customer GetCustomer(int id);
        IList<Customer> GetCustomers();

    }
}
