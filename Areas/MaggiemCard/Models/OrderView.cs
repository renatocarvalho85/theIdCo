using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMaggieCard.Areas.MaggiemCard.Models
{
    public class OrderView
    {
        public OrderView()
        {
            this.Items = new List<ItemOrder>();
        }
        public int Id { get; set; }
        public string StatusOrder { get; set; }
        public string StatusShip { get; set; }
        [Display(Name ="Order Total")]
        public string OrderTotal { get; set; }
        public DateTime OrderCreateDate { get; set; }
        public DateTime OrderPlacedDate { get; set; }
        public int OrderCustomerId { get; set; }
        public virtual Customer OrderCustomer { get; set; }
        public virtual IList<ItemOrder> Items { get; set; }
    }
}
