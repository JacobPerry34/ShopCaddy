using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCaddy.Models.ViewModels
{
    public class DetailsPurchaseOrderViewModel
    {
        public List<PurchaseOrderProduct> PurchaseOrderProducts { get; set; }
        public PurchaseOrderProduct PurchaseOrderProduct {get;set;}
        public PurchaseOrder PurchaseOrder { get; set; }
        public Vendor Vendor { get; set; }
    }
}
