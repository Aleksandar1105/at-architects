namespace AtArchitects.DataAccess.Repositories.Interfaces
{
    using AtArchitects.Domain.Enums;

    public interface IUserRepository
    {
        Task<int> CountByRole(Roles role);
    }
}
