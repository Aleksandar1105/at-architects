namespace AtArchitects.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<int> CountByRole(string role);
    }
}
