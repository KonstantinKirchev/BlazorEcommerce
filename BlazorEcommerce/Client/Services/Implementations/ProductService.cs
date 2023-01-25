namespace BlazorEcommerce.Client.Services.Implementations
{
    public class ProductService : ServiceBase, IProductService
    {
        public ProductService(HttpClient httpClient) 
            : base(httpClient)
        {
        }

        public List<Product> Products { get; set; } = new List<Product>();

        public Product Product { get; set; } = new Product();

        public event Action ProductsChanged;

        public async Task<ServiceResponse<Product>> GetProduct(int id)
        {
            var response = await this.httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{id}");
            return response;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var response = categoryUrl == null ?
               await this.httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product") :
               await this.httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");
            
            if (response != null && response.Data != null)
                Products = response.Data;

            ProductsChanged.Invoke();
        }
    }
}
