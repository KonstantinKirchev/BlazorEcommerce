namespace BlazorEcommerce.Client.Shared
{
    using Microsoft.AspNetCore.Components;
    using System.Threading.Tasks;

    public class ProductDetailsBase : ComponentBase
    {   
        protected Product? product = null;
        protected string message = string.Empty;
        protected int currentTypeId = 1;

        [Inject]
        public IProductService? ProductService { get; set; }

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                message = "Loading product ...";
                var result = await ProductService.GetProduct(Id);
                
                if (!result.Success)
                {
                    message = result.Message;
                }
                else
                {
                    product = result.Data;
                    if (product.Variants.Count > 0)
                    {
                        currentTypeId = product.Variants[0].ProductTypeId;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected ProductVariant GetSelectedVariant()
        {
            var variant = product.Variants.FirstOrDefault(v => v.ProductTypeId == currentTypeId);
            return variant;
        }
    }
}