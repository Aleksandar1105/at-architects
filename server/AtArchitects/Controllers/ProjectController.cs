namespace AtArchitects.Controllers
{
    using AtArchitects.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController(IProjectService projectService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAllProjects() => await projectService.GetAll()
    }
}
