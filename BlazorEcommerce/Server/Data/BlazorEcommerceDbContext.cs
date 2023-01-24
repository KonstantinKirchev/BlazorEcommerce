using BlazorEcommerce.Shared.Models;

namespace BlazorEcommerce.Server.Data
{
    public class BlazorEcommerceDbContext : DbContext
    {
        public BlazorEcommerceDbContext(DbContextOptions<BlazorEcommerceDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
