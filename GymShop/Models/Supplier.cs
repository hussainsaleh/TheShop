using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static GymShop.Enums;

namespace GymShop.Models
{
    public class Supplier
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public Title Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        public string AddressLineOne { get; set; }

        public string AddressLineTwo { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        public string Postcode { get; set; }

        public ICollection<ProductSupplier> ProductSuppliers { get; set; }
    }
}
