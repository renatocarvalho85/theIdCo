using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMaggieCard.Models
{
    public class ProductCategoryView
    {
       
        public int Id { get; set; }
        [Display(Name ="Category Name")]
        [Required(ErrorMessage ="Inform the Category Name")]
        public string ProductCategoryName { get; set; }
        public SelectList Products { get; set; }
    }
}
