namespace BlazorEcommerce.Client.Shared
{
    using Microsoft.AspNetCore.Components;
    using System.Threading.Tasks;

    public class ProductDetailsBase : ComponentBase
    {
        protected Product? product = null;
        protected string message = string.Empty;

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
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}