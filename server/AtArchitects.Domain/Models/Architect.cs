namespace AtArchitects.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Architect : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? PhoneNumber { get; set; }

        public List<Project> Projects { get; set; } = [];

        public ICollection<ProjectArchitect> ProjectArchitects { get; set; }
    }
}
