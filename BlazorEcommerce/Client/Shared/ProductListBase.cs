namespace BlazorEcommerce.Client.Shared
{
    using BlazorEcommerce.Shared;
    using BlazorEcommerce.Shared.Models;
    using Microsoft.AspNetCore.Components;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    public class ProductListBase : ComponentBase
    {
        protected List<Product> Products { get; set; } = new List<Product>();

        [Inject]
        public HttpClient HttpClient { get; set; } = new HttpClient();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await HttpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product");
                if (response != null && response.Data != null)
                    Products = response.Data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}