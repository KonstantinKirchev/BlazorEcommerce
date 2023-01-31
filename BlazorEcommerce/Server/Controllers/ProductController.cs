namespace BlazorEcommerce.Server.Controllers
{
    using BlazorEcommerce.Server.Infrastructure;
    using BlazorEcommerce.Shared.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetAdminProducts()
        {
            try
            {
                var result = await _productService.GetAdminProducts();

                if (result == null)
                {
                    return NotFound();
                }
                
                return Ok(result);
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorRetrieving);
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Product>>> CreateProduct(Product product)
        {
            try
            {
                var result = await _productService.CreateProduct(product);

                if (result == null)
                {
                    return NotFound();
                }
                
                return CreatedAtAction(nameof(CreateProduct), new { id = result.Data.Id }, result);
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorAdding);
            }
            
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Product>>> UpdateProduct(Product product)
        {
            try
            {
                var result = await _productService.UpdateProduct(product);
                
                if (result == null)
                    return NotFound();
                
                return AcceptedAtAction(nameof(UpdateProduct), new { id = result.Data.Id }, result);
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorUpdating);
            }
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteProduct(int id)
        {
            try
            {
                var result = await _productService.DeleteProduct(id);

                if (result == null)
                    return BadRequest();

                return AcceptedAtAction(nameof(DeleteProduct), result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorDeleting);
            }
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            try
            {
                var products = await _productService.GetProductsAsync();

                if (products == null)
                    return NotFound();

                return Ok(products.Value);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorRetrieving);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int id)
        {
            try
            {
                var product = await _productService.GetProductAsync(id);

                if (product == null)
                    return BadRequest();

                return Ok(product.Value);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorRetrieving);
            }
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(string categoryUrl)
        {
            try
            {
                var products = await _productService.GetProductsByCategoryAsync(categoryUrl);

                if (products == null)
                    return NotFound();

                return Ok(products.Value);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorRetrieving);
            }
            
        }

        [HttpGet("search/{searchText}/{page}")]
        public async Task<ActionResult<ServiceResponse<ProductSearchResult>>> SearchProducts(string searchText, int page = 1)
        {
            try
            {
                var result = await _productService.SearchProducts(searchText, page);
                
                if (result == null)
                    return NotFound();
                
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorRetrieving);
            }
        }

        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductSearchSuggestions(string searchText)
        {
            try
            {
                var result = await _productService.GetProductSearchSuggestions(searchText);
                
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorRetrieving);
            }
        }

        [HttpGet("featured")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProducts()
        {
            try
            {
                var result = await _productService.GetFeaturedProducts();
                
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorRetrieving);
            }
        }
    }
}
