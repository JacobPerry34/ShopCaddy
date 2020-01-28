using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShopCaddy.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VendorId { get; set; }
        public bool Received { get; set; }
        [Display(Name = "Date Received")]
        public DateTime DateReceived { get; set; }
        public Vendor Vendor { get; set; }
        public List<Product> Products { get; set; }
        public Product Product { get; set; }
        public PurchaseOrderProduct PurchaseOrderProduct { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
