using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMaggieCard.Areas.MaggiemCard.Models
{
    public class ItemOrderView
    {
        public int Id { get; set; }
        public int ItemProductId { get; set; }
        public virtual ProductDb ItemProduct { get; set; }
        public virtual Order OrderItem { get; set; }
        public int ItemOrderId { get; set; }
        public int ItemProductQuantity { get; set; }
        public int OrderItemId { get; set; }
        public string ItemPrice { get; set; }
        
    }
}
