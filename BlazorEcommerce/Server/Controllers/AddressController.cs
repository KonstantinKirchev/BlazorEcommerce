namespace BlazorEcommerce.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Address>>> GetAddress()
        {
            return await _addressService.GetAddress();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Address>>> AddOrUpdateAddress(Address address)
        {
            return await _addressService.AddOrUpdateAddress(address);
        }
    }
}
