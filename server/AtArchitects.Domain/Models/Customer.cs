using System.ComponentModel.DataAnnotations;

namespace AtArchitects.Domain.Models
{
    public class Customer : BaseUser
    {
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        public List<ProjectReviews> ProjectReviews { get; set; } = [];
    }
}
