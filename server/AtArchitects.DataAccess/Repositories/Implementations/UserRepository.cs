namespace AtArchitects.DataAccess.Repositories.Implementations
{
    using AtArchitects.DataAccess.Context;
    using AtArchitects.DataAccess.Repositories.Interfaces;
    using AtArchitects.Domain.Enums;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<int> CountByRole(Roles role)
        {
            return _dbContext.Users.CountAsync(u => u.Role == role);
        }
    }
}
