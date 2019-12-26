using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string PostTitle { get; set; }
        public string PostSubTitle { get; set; }
        public string PostDetails { get; set; }
        public DateTime PostDate { get; set; }
        public int PostCategoryId { get; set; }
        public virtual PostCategory PostCategories { get; set; }
        public int productDbId { get; set; }
        public virtual  ProductDb Products { get; set; }
    }
}
