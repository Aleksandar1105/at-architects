namespace AtArchitects.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    public class AdminUser : BaseUser
    {
        [MaxLength(50)]
        public string Name { get; set; } 
            
        public List<Project> Projects { get; set; } = [];

    }
}
