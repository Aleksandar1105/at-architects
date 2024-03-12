namespace AtArchitects.Controllers
{
    using AtArchitects.DTOs.AdminDTOs;
    using AtArchitects.DTOs.CustomerDTOs;
    using AtArchitects.DTOs.UserDTOs;
    using AtArchitects.Services.Interfaces;
    using AtArchitects.Shared.Exceptions;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("customer/register")]
        public async Task<IActionResult> RegisterCustomer(CustomerRegisterDto customerRegisterDto)
        {
            try
            {
                await _authService.RegisterCustomer(customerRegisterDto);
                return StatusCode(StatusCodes.Status201Created, "Customer has been successfully registered.");
            }
            catch (UserRegisterException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("customer/login")]
        public async Task<ActionResult<CustomerLoginResponseDto>> LoginCustomer(UserLoginDto customerLoginDto)
        {
            try
            {
                await _authService.LoginCustomer(customerLoginDto);
                return StatusCode(StatusCodes.Status200OK, "Customer has been successfully logged in.");
            }
            catch (BadCredentialsException ex)
            {
                return BadRequest("Bad credentials.");
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("admin/register")]
        public async Task<IActionResult> RegisterAdmin(AdminRegisterDto adminRegisterDto)
        {
            try
            {
                await _authService.RegisterAdmin(adminRegisterDto);
                return StatusCode(StatusCodes.Status201Created, "Admin has been successfully registered.");
            }
            catch (UserRegisterException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("admin/login")]
        public async Task<ActionResult<AdminLoginResponseDto>> LoginAdmin(UserLoginDto adminLoginDto)
        {
            try
            {
                await _authService.LoginAdmin(adminLoginDto);
                return StatusCode(StatusCodes.Status200OK, "Admin has been successfully logged in.");
            }
            catch (BadCredentialsException ex)
            {
                return BadRequest("Bad credentials.");
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
