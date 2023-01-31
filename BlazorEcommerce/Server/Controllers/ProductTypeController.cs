using BlazorEcommerce.Server.Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ProductType>>>> GetProductTypes()
        {
            try
            {
                var result = await _productTypeService.GetProductTypes();

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorRetrieving);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ProductType>>>> AddProductType(ProductType productType)
        {
            try
            {
                var result = await _productTypeService.AddProductType(productType);

                if (result == null)
                    return NotFound();

                return CreatedAtAction(nameof(AddProductType), result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorAdding);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<ProductType>>>> UpdateProductType(ProductType productType)
        {
            try
            {
                var result = await _productTypeService.UpdateProductType(productType);
                
                if (result == null)
                    return BadRequest();
                
                return AcceptedAtAction(nameof(UpdateProductType), result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorUpdating);
            }
            
        }
    }
}
