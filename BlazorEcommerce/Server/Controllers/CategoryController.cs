namespace BlazorEcommerce.Server.Controllers
{
    using BlazorEcommerce.Server.Infrastructure;
    using Microsoft.AspNetCore.Authorization;

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategories()
        {
            try
            {
                var result = await _categoryService.GetCategoriesAsync();
                
                if (result == null)
                    return NotFound();
                
                return Ok(result.Value);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorRetrieving);
            }
            
        }

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetAdminCategories()
        {
            try
            {
                var result = await _categoryService.GetAdminCategories();

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorRetrieving);
            }
        }

        [HttpDelete("admin/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> DeleteCategory(int id)
        {
            try
            {
                var result = await _categoryService.DeleteCategory(id);

                if (result == null)
                    return BadRequest();

                return AcceptedAtAction(nameof(DeleteCategory), result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorDeleting);
            }
            
        }

        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> AddCategory(Category category)
        {
            try
            {
                var result = await _categoryService.AddCategory(category);

                if (result == null)
                    return BadRequest();

                return CreatedAtAction(nameof(AddCategory), result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorAdding);
            }
        }

        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> UpdateCategory(Category category)
        {
            try
            {
                var result = await _categoryService.UpdateCategory(category);
                
                if (result == null)
                    return BadRequest();

                return AcceptedAtAction(nameof(UpdateCategory), result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorUpdating);
            }
        }
    }
}
