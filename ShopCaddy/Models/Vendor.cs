using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShopCaddy.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Contact { get; set; }
        [Display(Name="Phone Number")]
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
