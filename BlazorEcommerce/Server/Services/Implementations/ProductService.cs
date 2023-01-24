namespace BlazorEcommerce.Server.Services.Implementations
{
    using BlazorEcommerce.Server.Data;
    using BlazorEcommerce.Server.Services.Interfaces;
    using BlazorEcommerce.Shared.Models;
    using Microsoft.AspNetCore.Mvc;

    public class ProductService : ServiceBase, IProductService
    {
        public ProductService(BlazorEcommerceDbContext context) 
            : base(context)
        {
        }

        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsAsync()
        {   
            var products = await this.context.Products.ToListAsync();
            
            var response = new ServiceResponse<List<Product>>()
            {
                Data = products
            };

            return response;
        }
    }
}
