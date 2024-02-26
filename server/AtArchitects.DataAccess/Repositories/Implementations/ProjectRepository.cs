namespace AtArchitects.DataAccess.Repositories.Implementations
{
    using AtArchitects.DataAccess.Context;
    using AtArchitects.DataAccess.Repositories.Interfaces;
    using AtArchitects.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProjectRepository(AppDbContext dbContext) : IProjectRepository
    {
        private readonly AppDbContext dbContext = dbContext;

        public Task AddAsync(Project entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Project>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProjectReviews>> GetProductReviewsByProductIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Project entity)
        {
            throw new NotImplementedException();
        }
    }
}
