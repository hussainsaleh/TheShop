using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymShop.Models
{
    /// <summary>
    /// This class represents a joining entity to represent a many-to-many relationship between the Product and the Supplier.
    /// It consists of a foreign key property and a reference navigation property.
    /// </summary>
    public class ProductSupplier
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }

        
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
