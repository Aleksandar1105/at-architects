namespace AtArchitects.Mappers
{
    using AtArchitects.Domain.Models;
    using AtArchitects.DTOs.ArchitectDTOs;
    using AtArchitects.DTOs.ProjectDTOs;

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

        public static Architect MapToArchitectModel(ArchitectCreateDto architectCreateDto)
        {
            return new Architect
            {
                FirstName = architectCreateDto.FirstName,
                LastName = architectCreateDto.LastName,
                Email = architectCreateDto.Email,
                PhoneNumber = architectCreateDto.PhoneNumber,
            };
        }

        public static void ApplyUpdateFromDto(ArchitectUpdateDto architectUpdateDto, Architect existingArchitect)
        {
            existingArchitect.FirstName = architectUpdateDto.FirstName;
            existingArchitect.LastName = architectUpdateDto.LastName;
            existingArchitect.Email = architectUpdateDto.Email;
            existingArchitect.PhoneNumber = architectUpdateDto.PhoneNumber;
        }
    }
}
