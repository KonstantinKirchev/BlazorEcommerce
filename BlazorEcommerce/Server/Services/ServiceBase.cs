namespace BlazorEcommerce.Server.Services
{
    public abstract class ServiceBase
    {
        protected readonly BlazorEcommerceDbContext _context;

        public ServiceBase(BlazorEcommerceDbContext context)
        {
            _context = context;
        }
    }
}
