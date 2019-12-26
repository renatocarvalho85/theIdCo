using DataAccess.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMaggieCard.Models
{
    public class PostView
    {
        public int Id { get; set; }
        [Display(Name ="Post Title")]
        [Required(ErrorMessage ="The Post title is required")]
        public string PostTitle { get; set; }
        [Display(Name = "Post Sub-title")]
        public string PostSubTitle { get; set; }
        [Display(Name = "Post Details")]
        public string PostDetails { get; set; }
        [Display(Name = "Post Date")]
        [DataType(DataType.DateTime)]
        public DateTime PostDate { get; set; }
        public int PostCategoryId { get; set; }
        public virtual PostCategory PostCategoriesView { get; set; }
        public SelectList OptionPostCategories { get; set; }
        public int productDbId { get; set; }
        public SelectList OptionPoducts { get; set; }
        public virtual ProductDb ProductsView { get; set; }
    }
}
