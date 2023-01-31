namespace BlazorEcommerce.Server.Controllers
{
    using BlazorEcommerce.Server.Infrastructure;
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
            try
            {
                var result = await _addressService.GetAddress();

                if (result == null)
                    return BadRequest();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorRetrieving);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Address>>> AddOrUpdateAddress(Address address)
        {
            try
            {
                var result = await _addressService.AddOrUpdateAddress(address);
                
                if (result == null)
                    return BadRequest();

                return AcceptedAtAction(nameof(AddOrUpdateAddress), result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorAdding);
            }
        }
    }
}
