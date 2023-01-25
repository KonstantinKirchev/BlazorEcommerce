namespace BlazorEcommerce.Server.Controllers
{
    using BlazorEcommerce.Shared.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var products = await this.productService.GetProductsAsync();

            return Ok(products.Value);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int id)
        {
            var product = await this.productService.GetProductAsync(id);

            return Ok(product.Value);
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(string categoryUrl)
        {
            var products = await this.productService.GetProductsByCategoryAsync(categoryUrl);

            return Ok(products.Value);
        }
    }
}
