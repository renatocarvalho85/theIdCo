using DataAccess.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMaggieCard.Models
{
    public class UserRoleView
    {
        public int Id { get; set; }
        [Display(Name ="User Role Name")]
        [Required(ErrorMessage ="User name role is requied")]
        public string UserRoleName { get; set; }
        public SelectList UsersView { get; set; }
    }
}
