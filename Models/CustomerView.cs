using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMaggieCard.Models
{
    public class CustomerView
    {
        public int Id { get; set; }
        [Display(Name ="Customer Name")]
        [Required(ErrorMessage ="The customer name is required")]
        public string CustomerName { get; set; }
        [Display(Name ="Customer Address")]
        public string CustomerAddress { get; set; }
        [Display(Name ="Customer Phone")]
        [DataType(DataType.PhoneNumber)]
        public string CustomerPhone { get; set; }
        [Display(Name = "Customer Email")]
        [Required(ErrorMessage ="The customer email is required")]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }
        [Display(Name ="Customer Password")]
        [DataType(DataType.Password)]
        public string CustomerPassword { get; set; }
        public int UserId { get; set; }
    }
}
