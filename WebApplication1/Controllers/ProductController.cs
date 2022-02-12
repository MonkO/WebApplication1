using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> _products;
        private readonly ILogger<ProductController> _logger;

        static ProductController()
        {
            _products = new List<Product>();
        }
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetProductsList()
        {
            return Ok(_products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(Guid id)
        {
            Product product = _products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            _products.Add(product);

            return Created(product.Id.ToString(), product);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            Product dbProduct = _products.FirstOrDefault(x => x.Id == product.Id);
            if (dbProduct != null)
            {
                int index = _products.IndexOf(dbProduct);
                _products[index] = product;
                
                return Ok(product);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            Product dbProduct = _products.FirstOrDefault(x => x.Id == id);
            if (dbProduct != null)
            { 
                _products.Remove(dbProduct);

                return Ok(dbProduct);
            }

            return NotFound();
        }
    }
}
