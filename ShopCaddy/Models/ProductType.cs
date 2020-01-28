using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCaddy.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ApplicationUserId { get; set; }
        public string Image { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
