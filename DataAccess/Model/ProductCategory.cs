using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{ 
    public class ProductCategory
    {
        public ProductCategory()
        {
            this.Products = new List<ProductDb>();
        }
        public int Id { get; set; }
        public string ProductCategoryName { get; set; }
        public virtual ICollection<ProductDb> Products { get; set; }
    }
}
