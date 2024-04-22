namespace AtArchitects.DTOs.ArchitectDTOs
{
    using AtArchitects.Domain.Models;
    using System.ComponentModel.DataAnnotations;

    public class ArchitectUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string PhoneNumber { get; set; }
    }
}
