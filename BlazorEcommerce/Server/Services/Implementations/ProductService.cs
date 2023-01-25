namespace BlazorEcommerce.Server.Services.Implementations
{
    public class ProductService : ServiceBase, IProductService
    {
        public ProductService(BlazorEcommerceDbContext context) 
            : base(context)
        {
        }

        public async Task<ActionResult<ServiceResponse<Product>>> GetProductAsync(int id)
        {
            var response = new ServiceResponse<Product>();

            var product = await context.Products
                .Include(p => p.Variants)
                .ThenInclude(v => v.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this product does not exist";
            }
            else
            {
                response.Data = product;
            }

            return response;

        }

        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsAsync()
        {   
            var products = await this.context.Products
                .Include(p => p.Variants)
                .ToListAsync();
            
            var response = new ServiceResponse<List<Product>>()
            {
                Data = products
            };

            return response;
        }

        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategoryAsync(string categoryUrl)
        {
            var products = await context.Products
                .Where(c => c.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
                .Include(p => p.Variants)
                .ToListAsync();

            var response = new ServiceResponse<List<Product>>()
            {
                Data = products
            };

            return response;
        }
    }
}
