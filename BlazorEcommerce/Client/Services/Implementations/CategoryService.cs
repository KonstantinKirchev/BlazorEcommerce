﻿using BlazorEcommerce.Shared.Models;

namespace BlazorEcommerce.Client.Services.Implementations
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        public CategoryService(HttpClient httpClient) 
            : base(httpClient)
        {
        }

        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task GetCategories()
        {
            var response = await this.httpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/category");
            if (response != null && response.Data != null)
                Categories = response.Data;
        }
    }
}
