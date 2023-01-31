namespace BlazorEcommerce.Server.Controllers
{
    using BlazorEcommerce.Server.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using System.Security.Claims;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister request)
        {
            try
            {
                var response = await _authService.Register(new User {Email = request.Email}, request.Password);

                if (!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorAdding);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin request)
        {
            try
            {
                var response = await _authService.Login(request.Email, request.Password);
                
                if (!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorRetrieving);
            }
        }

        [HttpPut("change-password"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword([FromBody] string newPassword)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                
                if (userId == null)
                    return NotFound();
                
                var response = await _authService.ChangePassword(int.Parse(userId), newPassword);

                if (!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ServerConstants.ServerErrorUpdating);
            }
        }
    }
}
