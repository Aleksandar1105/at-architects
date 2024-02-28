namespace AtArchitects.Domain.Models
{
    public class ProjectReviews : BaseEntity
    {
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
        public Project? Project { get; set; }
        public int ProjectId { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
    }
}
