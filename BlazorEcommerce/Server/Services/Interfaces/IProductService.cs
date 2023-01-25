namespace BlazorEcommerce.Server.Services.Interfaces
{
    public interface IProductService
    {
        Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsAsync();

        Task<ActionResult<ServiceResponse<Product>>> GetProductAsync(int id);

        Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategoryAsync(string categoryUrl);
    }
}
