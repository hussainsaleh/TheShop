using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static GymShop.Enums;

namespace GymShop.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Flavour { get; set; }

        public string Description { get; set; }
        [Required]
        public double Size { get; set; }

        public MassUnit MassUnit { get; set; }

        [Required]
        public Decimal Price { get; set; }
        
        public int SupplierId { get; set; }

        public ICollection<ProductSale> ProductSales { get; set; }
        public ICollection<ProductSupplier> ProductSuppliers { get; set; }

    }
}
