namespace AtArchitects.Controllers
{
    using AtArchitects.DTOs.UserDTOs;
    using AtArchitects.Services.Interfaces;
    using AtArchitects.Shared.Exceptions;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("register/customer")]
        public async Task<ActionResult<UserLoginResponseDto>> RegisterCustomer([FromBody] UserRegisterDto userRegisterDto)
        {
            try
            {
                var loginResponse = await _authService.RegisterCustomer(userRegisterDto);
                _logger.LogInformation("User registered and logged in successfully: {Username}", userRegisterDto.Username);
                return Ok(loginResponse);
            }
            catch (UserRegisterException ex)
            {
                _logger.LogWarning("Registration failed: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error during registration");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("login/customer")]
        public async Task<ActionResult<UserLoginResponseDto>> LoginCustomer(UserLoginDto userLoginDto)
        {
            try
            {
                await _authService.LoginCustomer(userLoginDto);
                _logger.LogInformation("User logged in successfully: {Username}", userLoginDto.Username);
                return StatusCode(StatusCodes.Status200OK, $"Customer with username {userLoginDto.Username} has been successfully logged in.");
            }
            catch (BadCredentialsException)
            {
                _logger.LogWarning("Login failed for {Username}: Bad credentials", userLoginDto.Username);
                return BadRequest("Bad credentials.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error during login for {Username}", userLoginDto.Username);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("register/admin")]
        public async Task<ActionResult<UserLoginResponseDto>> RegisterAdmin([FromBody] UserRegisterDto userRegisterDto)
        {
            try
            {
                var loginResponse = await _authService.RegisterAdmin(userRegisterDto);
                _logger.LogInformation("User registered and logged in successfully: {Username}", userRegisterDto.Username);
                return Ok(loginResponse);
            }
            catch (UserRegisterException ex)
            {
                _logger.LogWarning("Registration failed: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error during registration");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("login/admin")]
        public async Task<ActionResult<UserLoginResponseDto>> LoginAdmin(UserLoginDto userLoginDto)
        {
            try
            {
                await _authService.LoginAdmin(userLoginDto);
                _logger.LogInformation("User logged in successfully: {Username}", userLoginDto.Username);
                return StatusCode(StatusCodes.Status200OK, $"Admin with username {userLoginDto.Username} has been successfully logged in.");
            }
            catch (BadCredentialsException)
            {
                _logger.LogWarning("Login failed for {Username}: Bad credentials", userLoginDto.Username);
                return BadRequest("Bad credentials.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error during login for {Username}", userLoginDto.Username);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
