using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBL;
using WebAppBL.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productsService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(
            ILogger<ProductController> logger,
            ProductService productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_productsService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(Guid id)
        {
            Product product = _productsService.GetProductById(id);
            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (product != null)
            {
                Guid createdGuid;
                try
                {
                    createdGuid = _productsService.AddProduct(product);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }

                return Created(createdGuid.ToString(), product);
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var successed = _productsService.UpdateProduct(product);
            return StatusCode(successed ? 200 : 404);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var successed = _productsService.RemoveProduct(id);

            return StatusCode(successed ? 200 : 404);
        }
    }
}
