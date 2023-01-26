namespace BlazorEcommerce.Server.Services.Interfaces
{
    public interface IProductService
    {
        Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsAsync();
        Task<ActionResult<ServiceResponse<Product>>> GetProductAsync(int id);
        Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategoryAsync(string categoryUrl);
        Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);
        Task<ServiceResponse<List<Product>>> GetFeaturedProducts();
    }
}
