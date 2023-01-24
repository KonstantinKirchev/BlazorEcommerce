namespace BlazorEcommerce.Client.Services
{
    public abstract class ServiceBase
    {
        protected readonly HttpClient httpClient;

        public ServiceBase(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
