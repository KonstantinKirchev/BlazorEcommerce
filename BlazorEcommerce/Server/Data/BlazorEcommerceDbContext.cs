using BlazorEcommerce.Shared.Models;

namespace BlazorEcommerce.Server.Data
{
    public class BlazorEcommerceDbContext : DbContext
    {
        public BlazorEcommerceDbContext(DbContextOptions<DbContext> options) 
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
