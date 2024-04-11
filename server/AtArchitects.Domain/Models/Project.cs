namespace AtArchitects.Domain.Models
{
    using AtArchitects.Domain.Enums;
    using System.ComponentModel.DataAnnotations;

    public class Project : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Location { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public string Area { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? ImageUrl { get; set; }

        [Required]
        public ProjectType ProjectType { get; set; }

        public List<ProjectReviews> ProjectReviews { get; set; } = [];

        public Status Status { get; set; }

        public Architect Architect { get; set; } = new();

        public int ArchitectId { get; set; }

        public ICollection<UserProject> UserProjects { get; set; }

        public ICollection<ProjectArchitect> ProjectArchitects { get; set; }
    }
}
