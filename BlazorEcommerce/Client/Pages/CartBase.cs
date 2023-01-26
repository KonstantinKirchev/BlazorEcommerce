﻿namespace BlazorEcommerce.Client.Pages
{
    public class CartBase : ComponentBase
    {
        protected List<CartProductResponse> cartProducts = null;
        protected string message = "Loading cart...";

        [Inject]
        public ICartService CartService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadCart();
        }

        protected async Task RemoveProductFromCart(int productId, int productTypeId)
        {
            await CartService.RemoveProductFromCart(productId, productTypeId);
            await LoadCart();
        }

        protected async Task LoadCart()
        {
            if ((await CartService.GetCartItems()).Count == 0)
            {
                message = "Your cart is empty.";
                cartProducts = new List<CartProductResponse>();
            }
            else
            {
                cartProducts = await CartService.GetCartProducts();
            }
        }

        protected async Task UpdateQuantity(ChangeEventArgs e, CartProductResponse product)
        {
            product.Quantity = int.Parse(e.Value.ToString());
            if (product.Quantity < 1)
                product.Quantity = 1;
            await CartService.UpdateQuantity(product);
        }
    }
}