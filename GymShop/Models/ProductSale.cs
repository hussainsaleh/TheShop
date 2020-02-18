using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymShop.Models
{
    public class ProductSale
    {
        public long Id { get; set; }
        public int Quantity { get; set; }

        public long SaleOrderId { get; set; }
        public SaleOrder SaleOrder { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
