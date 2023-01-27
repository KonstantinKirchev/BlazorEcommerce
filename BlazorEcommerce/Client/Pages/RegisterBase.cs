using Microsoft.AspNetCore.WebUtilities;

namespace BlazorEcommerce.Client.Pages
{
    public class RegisterBase : ComponentBase
    {
        protected UserRegister userRegister = new UserRegister();
        protected UserLogin userLogin = new UserLogin();

        protected string message = string.Empty;
        protected string messageCssClass = string.Empty;
        protected string returnUrl = string.Empty;

        [Inject]
        public IAuthService AuthService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public ICartService CartService { get; set; }

        protected override void OnInitialized()
        {
            var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("returnUrl", out var url))
            {
                returnUrl = url;
            }
        }

        protected async Task HandleRegistration()
        {
            var result = await AuthService.Register(userRegister);
            message = result.Message;
            if (result.Success)
            {
                userLogin.Email = userRegister.Email;
                userLogin.Password = userRegister.Password;
                var resultLogin = await AuthService.Login(userLogin);
                if (resultLogin.Success)
                {
                    message = string.Empty;

                    await LocalStorage.SetItemAsync("authToken", result.Data);
                    await AuthenticationStateProvider.GetAuthenticationStateAsync();
                    await CartService.StoreCartItems(true);
                    await CartService.GetCartItemsCount();
                    NavigationManager.NavigateTo(returnUrl);
                }
            }
            else
                messageCssClass = "text-danger";
        }
    }
}
