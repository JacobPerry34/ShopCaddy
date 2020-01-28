using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ShopCaddy.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
    }
}
