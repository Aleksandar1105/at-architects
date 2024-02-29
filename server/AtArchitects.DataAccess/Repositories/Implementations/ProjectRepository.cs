namespace AtArchitects.DataAccess.Repositories.Implementations
{
    using AtArchitects.DataAccess.Context;
    using AtArchitects.DataAccess.Repositories.Interfaces;
    using AtArchitects.Domain.Models;
    using AtArchitects.Shared.Exceptions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProjectRepository(AppDbContext dbContext) : IProjectRepository
    {

        public async Task AddAsync(Project entity)
        {
            await dbContext.Projects.AddAsync(entity);

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var project = await dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id)
                ?? throw new ProjectNotFoundException(id);

            dbContext.Projects.Remove(project);

            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<ProjectReviews>> GetProjectReviewsByProjectIdAsync(int projectId)
        {
            return await dbContext.ProjectReviews
                 .Where(p => p.Id == projectId)
                 .ToListAsync();
        }

        public async Task UpdateAsync(Project entity)
        {
            dbContext.Projects.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
