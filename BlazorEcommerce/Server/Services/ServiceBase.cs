namespace BlazorEcommerce.Server.Services
{
    public class ServiceBase
    {
        protected readonly BlazorEcommerceDbContext context;

        public ServiceBase(BlazorEcommerceDbContext context)
        {
            this.context = context;
        }
    }
}
