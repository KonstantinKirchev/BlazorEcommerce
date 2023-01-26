namespace BlazorEcommerce.Client.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegister request);
    }
}
