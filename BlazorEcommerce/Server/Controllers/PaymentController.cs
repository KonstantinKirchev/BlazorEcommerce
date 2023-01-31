namespace BlazorEcommerce.Server.Controllers
{
    using BlazorEcommerce.Server.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("checkout"), Authorize]
        public async Task<ActionResult<string>> CreateCheckoutSession()
        {
            try
            {
                var session = await _paymentService.CreateCheckoutSession();

                if (session == null)
                    return BadRequest();

                return Ok(session.Url);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorAdding);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<bool>>> FulfillOrder()
        {
            try
            {
                var response = await _paymentService.FulfillOrder(Request);
                
                if (!response.Success)
                    return BadRequest(response.Message);

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorAdding);
            }
        }
    }
}
