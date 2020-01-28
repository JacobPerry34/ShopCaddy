using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShopCaddy.Models
{
    public class PurchaseOrderProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PurchaseOrderId { get; set; }
        [Display(Name = "Quantity Ordered")]
        public int QuantityOrdered { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public List<Product> Products { get; set; }
        public Product Product { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
