namespace AtArchitects.Controllers
{
    using AtArchitects.DTOs.ProjectDTOs;
    using AtArchitects.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static System.Net.WebRequestMethods;

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController(IProjectService projectService) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllProjects()
        {
            try
            {
                var projects = await projectService.GetAllProjectsAsync();
                return Ok(projects);
            }
            catch (Exception ex)
            {
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
                var project = await projectService.GetProjectByIdAsync(id);
                return Ok(project);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject([FromBody] ProjectCreateDto projectCreateDto)
        {
            try
            {
                var project = await projectService.CreateProjectAsync(projectCreateDto);
                return Ok(project);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProject(int id, [FromBody] ProjectUpdateDto projectUpdateDto)
        {
            if (id <= 0 || !ModelState.IsValid)
                return BadRequest("Invalid product ID");

            try
            {
                await projectService.UpdateProjectAsync(id, projectUpdateDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid product ID");

            try
            {
                await projectService.DeleteProjectAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
