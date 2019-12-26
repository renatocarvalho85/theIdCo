using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Customer
    {
        public Customer()
        {
            this.Orders = new List<Order>();
        }
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public  string CustomerPassword { get; set; }
        public int UserId { get; set; }
        public virtual User CustomerUser { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
