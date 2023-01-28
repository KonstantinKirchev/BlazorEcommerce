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
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;
        public List<Product> AdminProducts { get; set; }

        public event Action ProductsChanged;

        public async Task<Product> CreateProduct(Product product)
        {
            var result = await _httpClient.PostAsJsonAsync("api/product", product);
            var newProduct = (await result.Content
                .ReadFromJsonAsync<ServiceResponse<Product>>()).Data;
            return newProduct;
        }

        public async Task DeleteProduct(Product product)
        {
            var result = await _httpClient.DeleteAsync($"api/product/{product.Id}");
        }

        public async Task GetAdminProducts()
        {
            var result = await _httpClient
                .GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/admin");
            AdminProducts = result.Data;
            CurrentPage = 1;
            PageCount = 0;
            if (AdminProducts.Count == 0)
                Message = "No products found.";
        }

        public async Task<ServiceResponse<Product>> GetProduct(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{id}");
            return response;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var response = categoryUrl == null ?
               await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured") : 
               await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");
            
            if (response != null && response.Data != null)
                Products = response.Data;

            CurrentPage = 1;
            PageCount = 0;

            if (Products.Count == 0)
                Message = "No products found";

            ProductsChanged.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchsuggestions/{searchText}");
            return result.Data;
        }

        public async Task SearchProducts(string searchText, int page)
        {
            LastSearchText = searchText;

            var result = await _httpClient
                 .GetFromJsonAsync<ServiceResponse<ProductSearchResult>>($"api/product/search/{searchText}/{page}");

            if (result != null && result.Data != null)
            {
                Products = result.Data.Products;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }
            if (Products.Count == 0) 
                Message = "No products found.";
            
            ProductsChanged?.Invoke();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/product", product);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<Product>>();
            return content.Data;
        }
    }
}
