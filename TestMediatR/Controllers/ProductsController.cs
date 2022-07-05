using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestMediatR.Domain;
using TestMediatR.Domain.Interfaces;

namespace TestMediatR.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
		private readonly IMapper _mapper;
		private readonly IProductService _productService;
		public ProductsController(IProductService productService, IMapper mapper)
        {
			_productService = productService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult> GetProducts()
		{
			var products = await _productService.GetProducts();

			if (products == null || products.Count() == 0) return NoContent();

			return Ok(_mapper.Map<IEnumerable<ProductContract>>(products));
		}

		[HttpGet("{id:int}", Name = "GetProductById")]
		public async Task<ActionResult> GetProductById(int id)
		{
			var product = await _productService.GetProductById(id);

			if (product == null) return NoContent();

			return Ok(_mapper.Map<ProductContract>(product));
		}

		[HttpPost]
		public async Task<ActionResult> AddProduct([FromBody] ProductContract productContract)
		{
			if (productContract == null) return BadRequest("Le produit ne peut pas être null.");

			if (await _productService.CheckIfProductExists(productContract.Id))
			{
				return BadRequest("Ce produit existe déjà.");
			}

			Product product = _mapper.Map<Product>(productContract);

			await _productService.AddProduct(product);

			return CreatedAtRoute("GetProductById", new { id = product.Id }, product);
		}

        [HttpPut("{id:int}")]
		public async Task<ActionResult> UpdateProduct([FromRoute] int id, [FromBody] string name)
        {
			if(! await _productService.CheckIfProductExists(id))
            {
				return BadRequest("L'id ne correspond pas à un produit existant.");
            }

			await _productService.UpdateProduct(id, name);

			return StatusCode(202, "Update OK");
        }

        [HttpDelete("{id:int}")]
		public async Task<ActionResult> DeleteProduct(int id)
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
