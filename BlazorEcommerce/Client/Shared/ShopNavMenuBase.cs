namespace BlazorEcommerce.Client.Shared
{
    public class ShopNavMenuBase : ComponentBase, IDisposable
    {
        [Inject]
        public ICategoryService CategoryService { get; set; }

        protected bool collapseNavMenu = true;

        protected string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        protected void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        protected override async Task OnInitializedAsync()
        {
            await CategoryService.GetCategories();
            CategoryService.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            CategoryService.OnChange -= StateHasChanged;
        }
    }
}
