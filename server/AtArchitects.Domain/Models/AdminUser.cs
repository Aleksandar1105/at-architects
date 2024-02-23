namespace AtArchitects.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    public class AdminUser : BaseUser
    {
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
            
        public List<Project> Projects { get; set; } = [];

    }
}
