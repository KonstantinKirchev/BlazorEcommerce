namespace BlazorEcommerce.Server.Services.Interfaces
{
    using BlazorEcommerce.Shared.Models;
    using Microsoft.AspNetCore.Mvc;
    public interface IProductService
    {
        Task<ActionResult<List<Product>>> GetProducts();
    }
}
