namespace AtArchitects.Services.Imlementations
{
    using AtArchitects.Domain.Models;
    using AtArchitects.DTOs.AdminDTOs;
    using AtArchitects.Services.Interfaces;
    using AtArchitects.Shared.Exceptions;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    public class AdminService : IAdminService
    {
        private readonly UserManager<User> _userManager;

        public AdminService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task ResetPasswordAsync(AdminPasswordResetDto adminPasswordResetDto)
        {
            if (adminPasswordResetDto.NewPassword != adminPasswordResetDto.ConfirmNewPassword)
            {
                throw new ArgumentException("New password and confirm new password do not match.");
            }

            var admin = await _userManager.FindByIdAsync(adminPasswordResetDto.AdminId);
            if (admin == null)
            {
                throw new AdminNotFoundException(adminPasswordResetDto.AdminId);
            }

            if (!await _userManager.CheckPasswordAsync(admin, adminPasswordResetDto.OldPassword))
            {
                throw new BadRequestException("Old password is incorrect.");
            }

            await _userManager.ChangePasswordAsync(admin, adminPasswordResetDto.OldPassword, adminPasswordResetDto.NewPassword);
        }
    }
}
