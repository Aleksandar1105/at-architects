namespace AtArchitects.Controllers
{
    using AtArchitects.DTOs.AdminDTOs;
    using AtArchitects.Services.Interfaces;
    using AtArchitects.Shared.Exceptions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IAdminService adminService, ILogger<AdminController> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        [HttpPost("ResetPassword")]
        [Authorize]
        public async Task<IActionResult> ResetPassword([FromBody] AdminPasswordResetDto adminPasswordResetDto)
        {
            try
            {
                string userId = User.FindFirstValue("id");
                adminPasswordResetDto.AdminId = userId;
                await _adminService.ResetPasswordAsync(adminPasswordResetDto);
                _logger.LogInformation("Password has been successfully reset.");
                return Ok("Password has been successfully reset.");
            }
            catch (BadRequestException ex)
            {
                _logger.LogWarning("Password reset failed: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error during password reset.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
