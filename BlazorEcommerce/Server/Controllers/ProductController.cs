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
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await this.productService.GetProductsAsync();

            return Ok(products.Value);
        }
    }
}
