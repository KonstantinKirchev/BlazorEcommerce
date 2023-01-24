namespace BlazorEcommerce.Client.Shared
{
    using Microsoft.AspNetCore.Components;
    using System.Threading.Tasks;

    public class ProductListBase : ComponentBase
    {
        [Inject]
        public IProductService? ProductService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await ProductService.GetProducts();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}