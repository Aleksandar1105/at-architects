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

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
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
                return Ok("Password has been successfully reset.");
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
