using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMaggieCard.Models
{
    public class ChangePasswordView
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Old Password")]
        public string  OldPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage ="The passwords must be equal")]
        public string ConfirmPassword { get; set; }
    }
}
