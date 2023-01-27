namespace BlazorEcommerce.Client.Pages
{
    public class RegisterBase : ComponentBase
    {
        protected UserRegister userRegister = new UserRegister();
        protected UserLogin userLogin = new UserLogin();

        protected string message = string.Empty;
        protected string messageCssClass = string.Empty;

        [Inject]
        public IAuthService AuthService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

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
                    NavigationManager.NavigateTo("");
                }
            }
            else
                messageCssClass = "text-danger";
        }
    }
}
