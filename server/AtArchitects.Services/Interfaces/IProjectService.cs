namespace AtArchitects.Services.Interfaces
{
    using AtArchitects.DTOs.ProjectDTOs;

    public interface IProjectService
    {
        Task<List<ProjectDetailsDto>> GetAllProjectsAsync();
        Task<ProjectDetailsDto> GetProjectByIdAsync(int id);
        Task<ProjectDetailsDto> CreateProjectAsync(ProjectCreateDto projectCreateDto);
        Task UpdateProjectAsync(int id, ProjectUpdateDto projectUpdateDto);
        Task DeleteProjectAsync(int id);
    }
}
