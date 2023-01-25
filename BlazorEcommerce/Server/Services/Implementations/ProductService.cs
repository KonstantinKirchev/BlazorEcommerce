﻿using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Services.Implementations
{
    public class ProductService : ServiceBase, IProductService
    {
        public ProductService(BlazorEcommerceDbContext context) 
            : base(context)
        {
        }

        public async Task<ActionResult<ServiceResponse<Product>>> GetProductAsync(int id)
        {
            var response = new ServiceResponse<Product>();

            var product = await context.Products
                .Include(p => p.Variants)
                .ThenInclude(v => v.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this product does not exist";
            }
            else
            {
                response.Data = product;
            }

            return response;

        }

        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsAsync()
        {   
            var products = await this.context.Products
                .Include(p => p.Variants)
                .ToListAsync();
            
            var response = new ServiceResponse<List<Product>>()
            {
                Data = products
            };

            return response;
        }

        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategoryAsync(string categoryUrl)
        {
            var products = await context.Products
                .Where(c => c.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
                .Include(p => p.Variants)
                .ToListAsync();

            var response = new ServiceResponse<List<Product>>()
            {
                Data = products
            };

            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            var products = await FindProductsBySearchText(searchText);

            List<string> result = new List<string>();

            foreach (var product in products)
            {
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if (product.Description != null)
                {
                    var punctuation = product.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = product.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Data = result };
        }

        public async Task<ServiceResponse<List<Product>>> SearchProducts(string searchText)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await FindProductsBySearchText(searchText)
            };

            return response;
        }

        private async Task<List<Product>> FindProductsBySearchText(string searchText)
        {
            return await context.Products
                                .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                                ||
                                p.Description.ToLower().Contains(searchText.ToLower()))
                                .Include(p => p.Variants)
                                .ToListAsync();
        }
    }
}
