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
        Task<ServiceResponse<List<Product>>> GetAdminProducts();
        Task<ServiceResponse<Product>> CreateProduct(Product product);
        Task<ServiceResponse<Product>> UpdateProduct(Product product);
        Task<ServiceResponse<bool>> DeleteProduct(int productId);
    }
}
