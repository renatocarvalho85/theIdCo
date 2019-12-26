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
    public class PostRepository :IPostInterface
    {
        private readonly Context.Context _context;
        public PostRepository(Context.Context context)
        {
            _context = context;
        }

        public ProductDb GetProduct(int id)
        {
            return _context.Products.Find(id);
                /*_context.Products.Include(c => c.Category).Where(x => x.Id == id).AsNoTracking().FirstOrDefault();*/
        }
        public bool Create(Post data)
        {
            try
            {
                _context.Posts.Add(data);
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
            var post = _context.Posts.Find(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public IList<Post> Get()
        {
            return _context.Posts.Include(x => x.Products).Include(c => c.PostCategories).ToList();
        }

        public Post Get(int id)
        {
            return _context.Posts.Include(p => p.Products)
                .Include(c => c.PostCategories)
                .Where(x => x.Id == id).FirstOrDefault();
        }

        public IList<Post> GetByName(string title)
        {
            return _context.Posts.Where(x => x.PostTitle.Contains(title)).ToList();

        }

        public IList<PostCategory> GetPostCategories()
        {
            return _context.PostCategories.ToList();
        }

        public Post GetPostCategory(int id)
        {
            return _context.Posts.Include(x => x.PostCategories).Where(p => p.Id == id).FirstOrDefault();
        }

        public bool Update(Post data)
        {
            try
            {
                _context.Entry<Post>(data).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
           
        }
        public bool CreatePostCategory(PostCategory data)
        {
            try
            {
                _context.PostCategories.Add(data);
                _context.SaveChanges();
                return true;

            }
            catch 
            {

                return false;
            }
            
        }
        public IList<ProductDb> GetProducts()
        {
            return _context.Products.ToList();
        }
        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
