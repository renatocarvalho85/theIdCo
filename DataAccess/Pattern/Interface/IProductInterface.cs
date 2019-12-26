using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Pattern.Interface
{
    public interface IProductInterface : IRepository<ProductDb>
    {
        IList<ProductDb> GetByName(string name);
        IList<ProductCategory> GetProductCategories();
        bool CreateCategory(ProductCategory data);
        IList<ProductDb> GetProductCategory();
        ProductDb GetProductCategory(int id);
    }
}
