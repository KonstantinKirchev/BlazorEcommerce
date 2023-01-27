namespace BlazorEcommerce.Client.Pages
{
    public class LoginBase : ComponentBase
    {
        protected UserLogin user = new UserLogin();

        protected string errorMessage = string.Empty;

        [Inject]
        public IAuthService AuthService { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async Task HandleLogin()
        {
            var result = await AuthService.Login(user);
            if (result.Success)
            {
                errorMessage = string.Empty;

                await LocalStorage.SetItemAsync("authToken", result.Data);
                NavigationManager.NavigateTo("");
            }
            else
            {
                errorMessage = result.Message;
            }
        }
    }
}
