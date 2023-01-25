namespace BlazorEcommerce.Client.Shared
{
    using Microsoft.AspNetCore.Components;

    public class ProductListBase : ComponentBase, IDisposable
    {
        [Inject]
        public IProductService? ProductService { get; set; }

        protected override void OnInitialized()
        {
            ProductService.ProductsChanged += StateHasChanged;
        }

        public void Dispose()
        {
            ProductService.ProductsChanged -= StateHasChanged;
        }
    }
}