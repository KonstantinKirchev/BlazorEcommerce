namespace BlazorEcommerce.Client.Services
{
    public abstract class ServiceBase
    {
        protected readonly HttpClient _httpClient;

        public ServiceBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
