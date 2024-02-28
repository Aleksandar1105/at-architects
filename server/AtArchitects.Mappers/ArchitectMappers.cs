namespace AtArchitects.Mappers
{
    using AtArchitects.Domain.Models;
    using AtArchitects.DTOs.ArchitectDTOs;

    public static class ArchitectMappers
    {
        public static ArchitectDetailsDto MapToArchitectDetailsDto(Architect architect)
        {
            return new ArchitectDetailsDto
            {
                Id = architect.Id,
                FirstName = architect.FirstName,
                LastName = architect.LastName,
                Email = architect.Email,
                PhoneNumber = architect.PhoneNumber,
                Projects = architect.Projects.Select(ProjectMappers.MapToProjectDetailsDto).ToList()
            };
        }

        public static Architect MapToArchitectModel(ArchitectDetailsDto architect)
        {
            return new Architect
            {
                FirstName = architect.FirstName,
                LastName = architect.LastName,
                Email = architect.Email,
                PhoneNumber = architect.PhoneNumber,
                Projects = architect.Projects.Select(ProjectMappers.MapToProjectModel).ToList()
            };
        }
    }
}
