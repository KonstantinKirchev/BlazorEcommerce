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

        protected string GetPriceText(Product product)
        {
            var variants = product.Variants;
            
            if (variants.Count == 0)
            {
                return string.Empty;
            }
            else if (variants.Count == 1)
            {
                return $"${variants[0].Price}";
            }
            
            decimal minPrice = variants.Min(v => v.Price);
            
            return $"Starting at ${minPrice}";
        }
    }
}