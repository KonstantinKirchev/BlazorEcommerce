namespace BlazorEcommerce.Client.Pages.Admin
{
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = "Admin")]
    public class ProductTypesBase : ComponentBase, IDisposable
    {
        protected ProductType editingProductType = null;

        [Inject]
        public IProductTypeService ProductTypeService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ProductTypeService.GetProductTypes();
            ProductTypeService.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            ProductTypeService.OnChange -= StateHasChanged;
        }

        protected void EditProductType(ProductType productType)
        {
            productType.Editing = true;
            editingProductType = productType;
        }

        protected void CreateNewProductType()
        {
            editingProductType = ProductTypeService.CreateNewProductType();
        }

        protected async Task UpdateProductType()
        {
            if (editingProductType.IsNew)
                await ProductTypeService.AddProductType(editingProductType);
            else
                await ProductTypeService.UpdateProductType(editingProductType);
            editingProductType = new ProductType();
        }
    }
}
