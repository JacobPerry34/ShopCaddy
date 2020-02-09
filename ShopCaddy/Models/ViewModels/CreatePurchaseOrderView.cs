using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCaddy.Models.ViewModels
{
    public class CreatePurchaseOrderView
    {
        public List<SelectListItem> Vendors { get; set; }
        public Vendor Vendor { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
    }
}
