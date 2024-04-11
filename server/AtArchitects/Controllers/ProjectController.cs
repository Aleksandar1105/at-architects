namespace AtArchitects.Controllers
{
    using AtArchitects.DTOs.ProjectDTOs;
    using AtArchitects.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(IProjectService projectService, ILogger<ProjectController> logger)
        {
            _projectService = projectService;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllProjects()
        {
            try
            {
                var projects = await _projectService.GetAllProjectsAsync();
                _logger.LogInformation("All projects retrieved successfully");
                return Ok(projects);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve all projects");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetProjectById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid product ID");

            try
            {
                var project = await _projectService.GetProjectByIdAsync(id);
                _logger.LogInformation("Project with ID {Id} retrieved successfully", id);
                return Ok(project);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve project with ID {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateProject([FromBody] ProjectCreateDto projectCreateDto)
        {
            try
            {
                var project = await _projectService.CreateProjectAsync(projectCreateDto);
                _logger.LogInformation("Project with ID {Id} created successfully", project.Id);
                return Ok(project);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create project");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateProject(int id, [FromBody] ProjectUpdateDto projectUpdateDto)
        {
            if (id <= 0 || !ModelState.IsValid)
                return BadRequest("Invalid product ID");

            try
            {
                await _projectService.UpdateProjectAsync(id, projectUpdateDto);
                _logger.LogInformation("Project with ID {Id} updated successfully", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update project with ID {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (id <= 0)
                return BadRequest("Invalid product ID");

            try
            {
                if (userRole == "Admin")
                {
                    await _projectService.DeleteProjectAsync(id);
                    _logger.LogInformation("Project with ID {Id} deleted successfully", id);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete project with ID {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
