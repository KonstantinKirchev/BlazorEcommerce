namespace BlazorEcommerce.Server.Services.Implementations
{
    public class AddressService : ServiceBase, IAddressService
    {
        private readonly IAuthService _authService;

        public AddressService(BlazorEcommerceDbContext context, IAuthService authService) 
            : base(context)
        {
            _authService = authService;
        }

        public async Task<ServiceResponse<Address>> AddOrUpdateAddress(Address address)
        {
            var response = new ServiceResponse<Address>();
            var dbAddress = (await GetAddress()).Data;
            if (dbAddress == null)
            {
                address.UserId = _authService.GetUserId();
                _context.Addresses.Add(address);
                response.Data = address;
            }
            else
            {
                dbAddress.FirstName = address.FirstName;
                dbAddress.LastName = address.LastName;
                dbAddress.State = address.State;
                dbAddress.Country = address.Country;
                dbAddress.City = address.City;
                dbAddress.Zip = address.Zip;
                dbAddress.Street = address.Street;
                response.Data = dbAddress;
            }

            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<ServiceResponse<Address>> GetAddress()
        {
            int userId = _authService.GetUserId();
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.UserId == userId);
            var result = new ServiceResponse<Address>();
            
            if (address == null)
            {
                result.Success = false;
                result.Message = "Address not found";

                return result;
            }
            
            result.Data = address;
            
            return result;
        }
    }
}
