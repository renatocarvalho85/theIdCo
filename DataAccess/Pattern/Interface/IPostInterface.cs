using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Pattern.Interface
{
   public interface IPostInterface : IRepository<Post>
    {
        IList<Post> GetByName(string title);
        IList<PostCategory> GetPostCategories();
        IList<ProductDb> GetProducts();
        ProductDb GetProduct(int id);
        Post GetPostCategory(int id);
        bool CreatePostCategory(PostCategory data);
    }
}
