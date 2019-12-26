using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalMaggieCard.Models;


namespace PortalMaggieCard.Models
{
    public class Product
    {
       
        public int id { get; set; }
        [Display(Name = "Product ID")]
        [Required(ErrorMessage =" ID must be type!")]
        public string ProductCod { get; set; }
        [Display(Name = "Product Name")]
        [Required(ErrorMessage ="You must type the porduct name!")]
        public string ProductName { get; set; }
        [Display(Name ="Product Price")]
        [Required(ErrorMessage = "You must type the porduct price!")]
        [DataType(DataType.Currency)]
        public string ProductPrice  { get; set; }
        [Display(Name ="Product Details")]        
        public string ProductDetails { get; set; }
        [Display(Name = "Image")]
        public IFormFile ProductImageName { get; set; }
        [Display(Name = "Image")]
        public string ProductImagePath { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public  virtual ProductCategory Category { get; set; }
        public virtual ItemOrder ItemOrderView { get; set; }
        public int ProductItemOrderId { get; set; }
        public SelectList Categories { get; set; }

    }
  

}
