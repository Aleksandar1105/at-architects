namespace AtArchitects.DataAccess.Repositories.Interfaces
{
    using AtArchitects.Domain.Models;

    public interface IProjectRepository : IRepository<Project>
    {
        Task<List<ProjectReviews>> GetProductReviewsByProductIdAsync(int productId);
    }
}
