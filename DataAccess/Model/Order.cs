using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
  public  class Order
    {
        public Order()
        {
            this.Items = new List<ItemOrder>();
        }
        public int Id { get; set; }
        public string StatusOrder { get; set; }
        public string StatusShip { get; set; }
        public string OrderTotal { get; set; }
        public DateTime OrderCreateDate { get; set; }
        public DateTime OrderPlacedDate { get; set; }
        public int OrderCustomerId { get; set; }
        public virtual Customer OrderCustomer { get; set; }
        public virtual IList<ItemOrder> Items { get; set; }
    }
}
