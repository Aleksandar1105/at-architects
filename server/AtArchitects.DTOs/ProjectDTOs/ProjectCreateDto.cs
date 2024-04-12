namespace AtArchitects.DTOs.ProjectDTOs
{
    using AtArchitects.Domain.Enums;
    using System.ComponentModel.DataAnnotations;

    public class ProjectCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Location { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public string Area { get; set; }

        [MaxLength(100)]
        public string ImageUrl { get; set; }

        [Required]
        public ProjectType ProjectType { get; set; }

        public int ArchitectId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
