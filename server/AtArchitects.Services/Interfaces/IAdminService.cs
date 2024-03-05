namespace AtArchitects.Services.Interfaces
{
    using AtArchitects.DTOs.AdminDTOs;

    public interface IAdminService
    {
        Task ResetPasswordAsync(AdminPasswordResetDto adminPasswordResetDto);
    }
}
