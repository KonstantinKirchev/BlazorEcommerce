namespace BlazorEcommerce.Server.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ActionResult<ServiceResponse<List<Category>>>> GetCategoriesAsync();
    }
}
