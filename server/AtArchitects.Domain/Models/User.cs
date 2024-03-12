namespace AtArchitects.Domain.Models
{
    using AtArchitects.Domain.Enums;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(20)]
        public Roles Role { get; set; }

        public List<Project> Projects { get; set; } = [];

        public List<ProjectReviews> ProjectReviews { get; set; } = [];

        public List<Message> Messages { get; set; } = [];
    }
}
