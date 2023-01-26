namespace BlazorEcommerce.Client.Services.Implementations
{
    public class AuthService : ServiceBase, IAuthService
    {
        public AuthService(HttpClient _httpClient) 
            : base(_httpClient)
        {
        }

        public async Task<ServiceResponse<int>> Register(UserRegister request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/register", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }
    }
}
