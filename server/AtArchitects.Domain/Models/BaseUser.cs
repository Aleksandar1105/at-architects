namespace AtArchitects.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BaseUser : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string Email { get; set; } = string.Empty;

        public byte[]? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }

        [Required]
        [MaxLength(30)]
        public string Role { get; set; } = string.Empty;

    }
}
