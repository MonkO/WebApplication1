using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppDAL.Entities
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ulong Stock { get; set; }
        public string Supplier { get; set; }
    }
}