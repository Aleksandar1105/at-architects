namespace AtArchitects.DataAccess.Repositories.Implementations
{
    using AtArchitects.DataAccess.Context;
    using AtArchitects.DataAccess.Repositories.Interfaces;
    using AtArchitects.Domain.Models;
    using AtArchitects.Shared.Exceptions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class ArchitectRepository : IArchitectRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<ArchitectRepository> _logger;
        public ArchitectRepository(AppDbContext dbContext, ILogger<ArchitectRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task AddAsync(Architect entity)
        {
            _logger.LogInformation("Adding architect with ID {Id}", entity.Id);
            await _dbContext.Architects.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation("Architect with ID {Id} added successfully", entity.Id);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var architect = await _dbContext.Architects.FirstOrDefaultAsync(a => a.Id == id)
                ?? throw new ArchitectNotFoundException(id);

            _dbContext.Architects.Remove(architect);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<List<Architect>> GetAllAsync()
        {
            return await _dbContext.Architects.ToListAsync();
        }

        public async Task<Architect> GetByIdAsync(int id)
        {
            return await _dbContext.Architects.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(Architect entity)
        {
             _dbContext.Architects.Update(entity);
             await _dbContext.SaveChangesAsync();
        }
    }
}
