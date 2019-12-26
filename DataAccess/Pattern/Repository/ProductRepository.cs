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
    public class ProductRepository: IProductInterface
         
    {
        private Context.Context _context;
        public ProductRepository(Context.Context context)
        {
            
            _context = context;
        }

        public bool Create(ProductDb data)
        {
            try
            {
                _context.Products.Add(data);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
        public bool CreateCategory(ProductCategory data)
        {
            try
            {
                _context.Categories.Add(data);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
        public bool Delete(int id)
        {

            try
            {
                var product = _context.Products.Find(id);
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public IList<ProductDb> Get()
        {
            return _context.Products.ToList();
        }

        public ProductDb Get(int id)
        {
            return _context.Products.Find(id);
        }
        public IList<ProductDb> GetProductCategory()
        {
            return _context.Products.Include(P => P.Category).ToList();
        }

        public IList<ProductDb> GetByName(string name)
        {
            return _context.Products.Where(x => x.ProductName.Contains(name)).ToList();
        }

        public bool Update(ProductDb data)
        {
            try
            {
                _context.Entry<ProductDb>(data).State = EntityState.Modified;
                _context.SaveChanges();

                return true;

            }
            catch
            {

                return false;
            }
        }
        public IList<ProductCategory> GetProductCategories()
        {


            return _context.Categories.ToList<ProductCategory>();
        }
        public ProductDb GetProductCategory(int id)
        {
            return _context.Products.Include(x => x.Category).Where(p => p.Id == id).FirstOrDefault();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

      
    }
}
