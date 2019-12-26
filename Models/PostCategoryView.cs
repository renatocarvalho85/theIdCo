using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMaggieCard.Models
{
    public class PostCategoryView
    {
        public int Id { get; set; }
        [Display(Name ="Post Category Name")]
        [Required(ErrorMessage ="The post category name is required")]
        public string PostCategoryName { get; set; }
        public SelectList OptionPosts { get; set; }
    }
}
