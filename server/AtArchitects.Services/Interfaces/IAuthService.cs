namespace AtArchitects.Services.Interfaces
{
    using AtArchitects.DTOs.AdminDTOs;
    using AtArchitects.DTOs.CustomerDTOs;
    using AtArchitects.DTOs.UserDTOs;

    public interface IAuthService
    {
        Task RegisterCustomer(CustomerRegisterDto dto);
        Task RegisterAdmin(AdminRegisterDto dto);
        Task<CustomerLoginResponseDto> LoginCustomer(UserLoginDto dto);
        Task<CustomerLoginResponseDto> LoginSeller(UserLoginDto dto);
    }
}
