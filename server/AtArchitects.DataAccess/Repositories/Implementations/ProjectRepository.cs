namespace AtArchitects.DataAccess.Repositories.Implementations
{
    using AtArchitects.DataAccess.Context;
    using AtArchitects.DataAccess.Repositories.Interfaces;
    using AtArchitects.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProjectRepository(AppDbContext dbContext) : IProjectRepository
    {

        public Task AddAsync(Project entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var project = await dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await dbContext.Projects.ToListAsync();
        }

        public Task<Project> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProjectReviews>> GetProjectReviewsByProjectIdAsync(int projectId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Project entity)
        {
            throw new NotImplementedException();
        }
    }
}
