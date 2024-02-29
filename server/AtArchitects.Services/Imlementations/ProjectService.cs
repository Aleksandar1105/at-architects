namespace AtArchitects.Services.Imlementations
{
    using AtArchitects.DataAccess.Repositories.Interfaces;
    using AtArchitects.DTOs.ProjectDTOs;
    using AtArchitects.Mappers;
    using AtArchitects.Services.Interfaces;
    using AtArchitects.Shared.Exceptions;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProjectService(IProjectRepository projectRepository) : IProjectService
    {
        public async Task<ProjectDetailsDto> CreateProjectAsync(ProjectCreateDto projectCreateDto)
        {
            var newProject = ProjectMappers.MapToProjectModel(projectCreateDto);
            await projectRepository.AddAsync(newProject);
            return ProjectMappers.MapToProjectDetailsDto(newProject);
        }

        public async Task DeleteProjectAsync(int id)
        {
            var existingProject = await projectRepository.GetByIdAsync(id);

            if (existingProject != null)
            {
                await projectRepository.DeleteByIdAsync(id);
            }
            else
            {
                throw new ProjectNotFoundException(id);
            }
        }

        public async Task<List<ProjectDetailsDto>> GetAllProjectsAsync()
        {
            var projects = await projectRepository.GetAllAsync();

            return projects != null
                ? projects.Select(ProjectMappers.MapToProjectDetailsDto).ToList()
                : [];
        }

        public async Task<ProjectDetailsDto> GetProjectByIdAsync(int id)
        {
            var project = await projectRepository.GetByIdAsync(id);

            return project != null
                ? ProjectMappers.MapToProjectDetailsDto(project)
                : throw new ProjectNotFoundException(id);
        }

        public async Task UpdateProjectAsync(int id, ProjectUpdateDto projectUpdateDto)
        {
            var existingProject = await projectRepository.GetByIdAsync(id);
            if (existingProject == null) throw new ProjectNotFoundException(id);

            ProjectMappers.ApplyUpdateFromDto(projectUpdateDto, existingProject);
            await projectRepository.DeleteByIdAsync(id);
        }
    }
}
