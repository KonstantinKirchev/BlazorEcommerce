namespace BlazorEcommerce.Client.Shared
{
    public class FeaturedProductsBase : ComponentBase, IDisposable
    {
        [Inject]
        public IProductService ProductService { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public EventCallback<string> WelcomeMessage { get; set; }

        protected override void OnInitialized()
        {
            WelcomeMessage.InvokeAsync("Welcome to the featured products page!");
            ProductService.ProductsChanged += StateHasChanged;
        }

        public void Dispose()
        {
            ProductService.ProductsChanged -= StateHasChanged;
        }
    }
}
