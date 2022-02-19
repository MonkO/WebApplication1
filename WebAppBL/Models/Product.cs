using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppBL.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [Range(0, 10000)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 10000000)]
        public ulong Stock { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Supplier { get; set; }
    }
}
