using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
   public  class ProductTb
    {
        public int id { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public double productPrice { get; set; }
        public string productDetails { get; set; }
    }
}
