namespace BlazorEcommerce.Server.Services.Interfaces
{
    using BlazorEcommerce.Shared.Models;
    using Microsoft.AspNetCore.Mvc;
    public interface IProductService
    {
        Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsAsync();

        Task<ActionResult<ServiceResponse<Product>>> GetProductAsync(int id);
    }
}
