namespace BlazorEcommerce.Client.Pages.Admin
{
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = "Admin")]
    public class ProductsBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ProductService.GetAdminProducts();
        }

        protected void EditProduct(int productId)
        {
            NavigationManager.NavigateTo($"admin/product/{productId}");
        }

        protected void CreateProduct()
        {
            NavigationManager.NavigateTo("admin/product");
        }
    }
}
