namespace AtArchitects.Mappers
{
    using AtArchitects.Domain.Models;
    using AtArchitects.DTOs.ProjectDTOs;

    public static class ProjectMappers
    {
        public static ProjectDetailsDto MapToProjectDetailsDto(Project project)
        {
            return new ProjectDetailsDto
            {
                Id = project.Id,
                Name = project.Name,
                Location = project.Location,
                Description = project.Description,
                Area = project.Area,
                ImageUrl = project.ImageUrl,
                ProjectType = project.ProjectType,
                Status = project.Status,
            };
        }

        public static Project MapToProjectModel(ProjectCreateDto project)
        {
            return new Project
            {
                Name = project.Name,
                Location = project.Location,
                Description = project.Description,
                Area = project.Area,
                ImageUrl = project.ImageUrl,
                ProjectType = project.ProjectType,
                ArchitectId = project.ArchitectId
            };
        }

        public static void ApplyUpdateFromDto(ProjectUpdateDto projectUpdateDto, Project existingProject)
        {
            existingProject.Name = projectUpdateDto.Name;
            existingProject.Location = projectUpdateDto.Location;
            existingProject.Description = projectUpdateDto.Description;
            existingProject.Area = projectUpdateDto.Area;
            existingProject.ImageUrl = projectUpdateDto.ImageUrl;
            existingProject.ProjectType = projectUpdateDto.ProjectType;
            existingProject.ArchitectId = projectUpdateDto.ArchitectId;
        }
    }
}
