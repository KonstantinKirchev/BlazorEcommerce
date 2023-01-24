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

        public async Task<ActionResult<List<Product>>> GetProductsAsync()
        {   
            return await this.context.Products.ToListAsync();
        }
    }
}
