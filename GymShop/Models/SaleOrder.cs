using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static GymShop.Enums;

namespace GymShop.Models
{
    public class SaleOrder
    {
        public long Id { get; set; }

        public DateTime PurchaseDate { get; set; }
        public Delivery Delivery { get; set; }
        public string Note { get; set; }

        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<ProductSale> ProductSales { get; set; }
    }
}
