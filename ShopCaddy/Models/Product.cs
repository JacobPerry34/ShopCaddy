using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShopCaddy.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Season { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Serial Number")]
        public int SerialNumber { get; set; }
        public string ApplicationUserId { get; set; }
        public ProductType ProductType { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
        

    }
}
