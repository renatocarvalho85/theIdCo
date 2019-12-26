using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class PostCategory
    {
        public PostCategory()
        {
            this.Posts = new List<Post>();
        }
        public int Id { get; set; }
        public string PostCategoryName { get; set; }
        public virtual ICollection<Post> Posts{ get; set; }
    }
}
