 namespace BlazorEcommerce.Server.Services.Implementations
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        public CategoryService(BlazorEcommerceDbContext context) 
            : base(context)
        {
        }

        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();

            var response = new ServiceResponse<List<Category>>()
            {
                Data = categories
            };

            return response;
        }
    }
}
