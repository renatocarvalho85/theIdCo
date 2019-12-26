using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class ItemOrder
    {
        public int Id { get; set; }
        public int ItemProductId { get; set; }
        public virtual ProductDb ItemProduct { get; set; }
        public virtual Order OrderItem { get; set; }
        public int OrderItemId { get; set; }
        public string ItemPrice { get; set; }
        public int ItemProductQuantity { get; set; }
    }
}
