namespace AtArchitects.DataAccess.Repositories.Implementations
{
    using AtArchitects.DataAccess.Context;
    using AtArchitects.DataAccess.Repositories.Interfaces;
    using AtArchitects.Domain.Models;
    using AtArchitects.Shared.Exceptions;
    using Microsoft.EntityFrameworkCore;

    public class ArchitectRepository : IArchitectRepository
    {
        private readonly AppDbContext _dbContext;
        public ArchitectRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Architect entity)
        {
            await _dbContext.Architects.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteByIdAsync(int id)
        {
            var architect = _dbContext.Architects.FirstOrDefault(a => a.Id == id)
                ?? throw new ArchitectNotFoundException(id);

            _dbContext.Architects.Remove(architect);
            return _dbContext.SaveChangesAsync();

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
