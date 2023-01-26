namespace BlazorEcommerce.Client.Shared
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;


    public class SearchBase : ComponentBase
    {
        protected string searchText = string.Empty;
        protected List<string> suggestions = new List<string>();
        protected ElementReference searchInput;

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        [Inject]
        public IProductService? ProductService { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await searchInput.FocusAsync();
            }
        }

        public void SearchProducts()
        {
            NavigationManager?.NavigateTo($"search/{searchText}/1");
        }

        public async Task HandleSearch(KeyboardEventArgs args)
        {
            if (args.Key == null || args.Key.Equals("Enter"))
            {
                SearchProducts();
            }
            else if (searchText.Length > 1)
            {
                suggestions = await ProductService.GetProductSearchSuggestions(searchText);
            }
        }
    }
}
