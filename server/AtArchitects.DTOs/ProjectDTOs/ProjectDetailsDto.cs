namespace AtArchitects.DTOs.ProjectDTOs
{
    using AtArchitects.Domain.Enums;
    using AtArchitects.DTOs.ArchitectDTOs;

    public class ProjectDetailsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string Area { get; set; }

        public string ImageUrl { get; set; }

        public ProjectType ProjectType { get; set; }

        public Status Status { get; set; }

        public ArchitectDetailsDto Architect { get; set; }
    }
}
