using DataAccess.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMaggieCard.Models
{
    public class UserView
    {
        public int Id { get; set; }
        [Display(Name ="User Name")]
        //[Required(ErrorMessage ="User Name is required")]
        public string UserName { get; set; }

        [Display(Name = "User Full Name")]
        //[Required(ErrorMessage = "User Full name is required")]
        public string UserFullName { get; set; }

        [Display(Name = "User Email Address")]
        [Required(ErrorMessage = "User Email is required")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Display(Name = "User Password")]
        [Required(ErrorMessage = "User Password is required")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("UserPassword", ErrorMessage ="Passwords must match")]
        public string ConfirmPassword { get; set; }
        public int UserRoleId { get; set; }
        public virtual UserRole UserRole { get; set; }
        public SelectList UserRoles { get; set; }
    }
}
