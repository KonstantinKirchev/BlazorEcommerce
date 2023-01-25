using static System.Net.WebRequestMethods;

namespace BlazorEcommerce.Client.Services.Implementations
{
    public class ProductService : ServiceBase, IProductService
    {
        public ProductService(HttpClient _httpClient) 
            : base(_httpClient)
        {
        }

        public List<Product> Products { get; set; } = new List<Product>();

        public Product Product { get; set; } = new Product();
        public string Message { get; set; } = "Loading products...";

        public event Action ProductsChanged;

        public async Task<ServiceResponse<Product>> GetProduct(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{id}");
            return response;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var response = categoryUrl == null ?
               await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product") :
               await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");
            
            if (response != null && response.Data != null)
                Products = response.Data;

            ProductsChanged.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchsuggestions/{searchText}");
            return result.Data;
        }

        public async Task SearchProducts(string searchText)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/search/{searchText}");
            
            if (result != null && result.Data != null)
                Products = result.Data;
            if (Products.Count == 0) 
                Message = "No products found.";
            
            ProductsChanged?.Invoke();
        }
    }
}
