namespace BlazorEcommerce.Client.Pages.Admin
{
    using Microsoft.JSInterop;
    public class EditProductBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        protected Product product = new Product();
        protected bool loading = true;
        protected string btnText = "";
        protected string msg = "Loading...";

        [Inject]
        public IProductTypeService ProductTypeService { get; set; }
        [Inject]
        public ICategoryService CategoryService { get; set; }
        [Inject]
        public IProductService ProductService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public JSRuntime JSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ProductTypeService.GetProductTypes();
            await CategoryService.GetAdminCategories();
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Id == 0)
            {
                product = new Product { IsNew = true };
                btnText = "Create Product";
            }
            else
            {
                Product dbProduct = (await ProductService.GetProduct(Id)).Data;
                if (dbProduct == null)
                {
                    msg = $"Product with Id '{Id}' does not exist!";
                    return;
                }
                product = dbProduct;
                product.Editing = true;
                btnText = "Update Product";
            }
            loading = false;
        }

        protected void RemoveVariant(int productTypeId)
        {
            var variant = product.Variants.Find(v => v.ProductTypeId == productTypeId);
            if (variant == null)
            {
                return;
            }
            if (variant.IsNew)
            {
                product.Variants.Remove(variant);
            }
            else
            {
                variant.Deleted = true;
            }
        }

        protected void AddVariant()
        {
            product.Variants
                .Add(new ProductVariant { IsNew = true, ProductId = product.Id });
        }

        protected async void AddOrUpdateProduct()
        {
            if (product.IsNew)
            {
                var result = await ProductService.CreateProduct(product);
                NavigationManager.NavigateTo($"admin/product/{result.Id}");
            }
            else
            {
                product.IsNew = false;
                product = await ProductService.UpdateProduct(product);
                NavigationManager.NavigateTo($"admin/product/{product.Id}", true);
            }
        }

        protected async void DeleteProduct()
        {
            bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm",
                $"Do you really want to delete '{product.Title}'?");
            if (confirmed)
            {
                await ProductService.DeleteProduct(product);
                NavigationManager.NavigateTo("admin/products");
            }
        }
    }
}
