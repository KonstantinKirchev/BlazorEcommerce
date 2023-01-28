namespace BlazorEcommerce.Server.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ActionResult<ServiceResponse<List<Category>>>> GetCategoriesAsync();
        Task<ServiceResponse<List<Category>>> GetAdminCategories();
        Task<ServiceResponse<List<Category>>> AddCategory(Category category);
        Task<ServiceResponse<List<Category>>> UpdateCategory(Category category);
        Task<ServiceResponse<List<Category>>> DeleteCategory(int id);
    }
}
