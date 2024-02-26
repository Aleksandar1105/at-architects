namespace AtArchitects.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Message : BaseEntity
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

        [Required]
        [MaxLength(50)]
        public string Subject { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string Content { get; set; } = string.Empty;

        public User? User { get; set; }
        public string? UserId { get; set; }
    }
}
