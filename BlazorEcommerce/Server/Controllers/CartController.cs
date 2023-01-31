using BlazorEcommerce.Server.Infrastructure;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("products")]
        public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> GetCartProducts(List<CartItem> cartItems)
        {
            try
            {
                var result = await _cartService.GetCartProducts(cartItems);
                
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorRetrieving);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> StoreCartItems(List<CartItem> cartItems)
        {
            try
            {
                var result = await _cartService.StoreCartItems(cartItems);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorAdding);
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<bool>>> AddToCart(CartItem cartItem)
        {
            try
            {
                var result = await _cartService.AddToCart(cartItem);

                if (result == null)
                    return NotFound();

                return CreatedAtAction(nameof(AddToCart), result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorAdding);
            }
        }

        [HttpPut("update-quantity")]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateQuantity(CartItem cartItem)
        {
            try
            {
                var result = await _cartService.UpdateQuantity(cartItem);

                if (result == null)
                    return NotFound();

                return AcceptedAtAction(nameof(UpdateQuantity), result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorUpdating);
            }
        }

        [HttpDelete("{productId}/{productTypeId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> RemoveItemFromCart(int productId, int productTypeId)
        {
            try
            {
                var result = await _cartService.RemoveItemFromCart(productId, productTypeId);

                if (result == null)
                    return BadRequest();

                return AcceptedAtAction(nameof(UpdateQuantity), result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorDeleting);
            }
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> GetCartItemsCount()
        {
            try
            {
                var result = await _cartService.GetCartItemsCount();

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorRetrieving);
            }
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> GetDbCartProducts()
        {
            try
            {
                var result = await _cartService.GetDbCartProducts();

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorRetrieving);
            }
        }
    }
}
