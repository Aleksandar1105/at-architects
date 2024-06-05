namespace AtArchitects.Controllers
{
    using AtArchitects.DTOs.ArchitectDTOs;
    using AtArchitects.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    [Route("api/[controller]")]
    [ApiController]
    public class ArchitectController : ControllerBase
    {
        private readonly IArchitectService _architectService;
        private readonly ILogger<ArchitectController> _logger;

        public ArchitectController(IArchitectService architectService, ILogger<ArchitectController> logger)
        {
            _architectService = architectService;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllArchitects()
        {
            try
            {
                var architects = await _architectService.GetAllArchitectsAsync();
                _logger.LogInformation("All architects retrieved successfully");
                return Ok(architects);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to retrieve all architects");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetArchitectById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid architect ID");

            try
            {
                var architect = await _architectService.GetArchitectByIdAsync(id);
                _logger.LogInformation("Architect with ID {Id} retrieved successfully", id);
                return Ok(architect);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to retrieve architect with ID {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Architect")]
        public async Task<ActionResult> AddArchitect([FromBody] ArchitectCreateDto architectCreateDto)
        {
            if (!ModelState.IsValid)            
                return BadRequest(ModelState);
            

            try
            {
                var architect = await _architectService.AddArchitectAsync(architectCreateDto);
                _logger.LogInformation("Architect with ID {Id} created successfully", architect.Id);
                return Ok(architect);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to create architect: {Message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Architect")]
        public async Task<ActionResult> UpdateArchitect(int id, [FromBody] ArchitectUpdateDto architectUpdateDto)
        {
            if (id <= 0 || !ModelState.IsValid)
                return BadRequest("Invalid architect ID or model state is not valid");

            try
            {
                await _architectService.UpdateArchitectAsync(id, architectUpdateDto);
                _logger.LogInformation("Architect with ID {Id} updated successfully", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to update architect with ID {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteArchitect(int id)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (id <= 0)
                return BadRequest("Invalid architect ID");

            try
            {
                if (userRole == "Admin")
                {
                    await _architectService.DeleteArchitectAsync(id);
                    _logger.LogInformation("Architect with ID {Id} deleted successfully", id);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to delete architect with ID {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
