using Microsoft.AspNetCore.Mvc;
using TestMediatR.Converters;
using TestMediatR.Domain;
using TestMediatR.Domain.Interfaces;

namespace TestMediatR.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _productService.GetProducts();

            if (products == null || products.Count() == 0) return NoContent();

            return Ok(products.ToList().ToProductContracts());
        }

        [HttpGet("{id:Guid}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(Guid id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null) return NoContent();

            return Ok(product.ToProductContract());
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return BadRequest("Le produit ne peut pas être null.");

            Product product = new Product
            {
                Name = name
            };

            product.Id = await _productService.AddProduct(product);

            return CreatedAtRoute("GetProductById", new { id = product.Id }, product.ToProductContract());
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] string name)
        {
            if (!await _productService.CheckIfProductExists(id))
            {
                return BadRequest("L'id ne correspond pas à un produit existant.");
            }

            await _productService.UpdateProduct(id, name);

            return StatusCode(202, "Update OK");
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            if (!await _productService.CheckIfProductExists(id))
            {
                return BadRequest("L'id ne correspond pas à un produit existant.");
            }

            await _productService.DeleteProduct(id);

            return StatusCode(202, "Delete OK");
        }
    }
}
