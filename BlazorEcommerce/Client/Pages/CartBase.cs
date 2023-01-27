namespace BlazorEcommerce.Client.Pages
{
    public class CartBase : ComponentBase
    {
        protected List<CartProductResponse> cartProducts = null;
        protected string message = "Loading cart...";
        protected bool orderPlaced = false;

        [Inject]
        public ICartService CartService { get; set; }

        [Inject]
        public IOrderService OrderService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            orderPlaced = false;
            await LoadCart();
        }

        protected async Task RemoveProductFromCart(int productId, int productTypeId)
        {
            await CartService.RemoveProductFromCart(productId, productTypeId);
            await LoadCart();
        }

        protected async Task LoadCart()
        {
            await CartService.GetCartItemsCount();
            cartProducts = await CartService.GetCartProducts();
            
            if (cartProducts == null || cartProducts.Count == 0)
            {
                message = "Your cart is empty.";
            }
        }

        protected async Task UpdateQuantity(ChangeEventArgs e, CartProductResponse product)
        {
            product.Quantity = int.Parse(e.Value.ToString());
            if (product.Quantity < 1)
                product.Quantity = 1;
            await CartService.UpdateQuantity(product);
        }

        protected async Task PlaceOrder()
        {
            await OrderService.PlaceOrder();
            await CartService.GetCartItemsCount();
            orderPlaced = true;
        }
    }
}
