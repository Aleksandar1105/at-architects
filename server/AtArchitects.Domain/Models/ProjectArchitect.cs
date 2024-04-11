namespace AtArchitects.Domain.Models
{
    public class ProjectArchitect
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int ArchitectId { get; set; }
        public Architect Architect { get; set; }
    }
}
