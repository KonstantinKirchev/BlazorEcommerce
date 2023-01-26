namespace BlazorEcommerce.Client.Shared
{
    public class CartCounterBase : ComponentBase, IDisposable
    {
        [Inject]
        public ISyncLocalStorageService LocalStorage { get; set; }

        [Inject]
        public ICartService CartService { get; set; }

        protected int GetCartItemsCount()
        {
            var cart = LocalStorage.GetItem<List<CartItem>>("cart");
            return cart != null ? cart.Count : 0;
        }

        protected override void OnInitialized()
        {
            CartService.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            CartService.OnChange -= StateHasChanged;
        }
    }
}
