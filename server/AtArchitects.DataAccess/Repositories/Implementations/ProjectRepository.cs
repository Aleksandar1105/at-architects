namespace AtArchitects.DataAccess.Repositories.Implementations
{
    using AtArchitects.DataAccess.Context;
    using AtArchitects.DataAccess.Repositories.Interfaces;
    using AtArchitects.Domain.Models;
    using AtArchitects.Shared.Exceptions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _dbContext;
        public ProjectRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Project entity)
        {
            await _dbContext.Projects.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id)
                ?? throw new ProjectNotFoundException(id);

            _dbContext.Projects.Remove(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<ProjectReviews>> GetProjectReviewsByProjectIdAsync(int projectId)
        {
            return await _dbContext.ProjectReviews
                 .Where(p => p.ProjectId == projectId)
                 .ToListAsync();
        }

        public async Task UpdateAsync(Project entity)
        {
            _dbContext.Projects.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
