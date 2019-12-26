using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMaggieCard.Models
{
    public class ManageUserView
    {
        public bool IsEmailConfirmrd { get; set; }
        public string UserName { get; set; }
        [Phone]
        [Display(Name ="Phone Number")]
        [Required]
        public string  PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string StatusMeessage { get; set; }
    }
}
