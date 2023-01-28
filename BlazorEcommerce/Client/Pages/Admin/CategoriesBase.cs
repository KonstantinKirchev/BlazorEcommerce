namespace BlazorEcommerce.Client.Pages.Admin
{
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = "Admin")]
    public class CategoriesBase : ComponentBase, IDisposable
    {
        protected Category editingCategory = null;

        [Inject]
        public ICategoryService CategoryService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await CategoryService.GetAdminCategories();
            CategoryService.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            CategoryService.OnChange -= StateHasChanged;
        }

        protected void CreateNewCategory()
        {
            editingCategory = CategoryService.CreateNewCategory();
        }

        protected void EditCategory(Category category)
        {
            category.Editing = true;
            editingCategory = category;
        }

        protected async Task UpdateCategory()
        {
            if (editingCategory.IsNew)
                await CategoryService.AddCategory(editingCategory);
            else
                await CategoryService.UpdateCategory(editingCategory);
            editingCategory = new Category();
        }

        protected async Task CancelEditing()
        {
            editingCategory = new Category();
            await CategoryService.GetAdminCategories();
        }

        protected async Task DeleteCategory(int id)
        {
            await CategoryService.DeleteCategory(id);
        }
    }
}
