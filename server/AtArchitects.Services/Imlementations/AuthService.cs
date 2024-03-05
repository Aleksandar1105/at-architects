namespace AtArchitects.Services.Imlementations
{
    using AtArchitects.DataAccess.Repositories.Interfaces;
    using AtArchitects.Domain.Models;
    using AtArchitects.DTOs.AdminDTOs;
    using AtArchitects.DTOs.CustomerDTOs;
    using AtArchitects.DTOs.UserDTOs;
    using AtArchitects.Services.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using System.Threading.Tasks;

    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthService(UserManager<User> userManager, IConfiguration configuration, IUserRepository userRepository)
        {
            _userManager = userManager;
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public Task<CustomerLoginResponseDto> LoginCustomer(UserLoginDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerLoginResponseDto> LoginSeller(UserLoginDto dto)
        {
            throw new NotImplementedException();
        }

        public Task RegisterAdmin(AdminRegisterDto dto)
        {
            throw new NotImplementedException();
        }

        public Task RegisterCustomer(CustomerRegisterDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
