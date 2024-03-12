namespace AtArchitects.Services.Interfaces
{
    using AtArchitects.DTOs.AdminDTOs;
    using AtArchitects.DTOs.CustomerDTOs;
    using AtArchitects.DTOs.UserDTOs;

    public interface IAuthService
    {
        Task<CustomerLoginResponseDto> LoginCustomer(UserLoginDto dto);
        Task RegisterCustomer(CustomerRegisterDto dto);
        Task<CustomerLoginResponseDto> LoginAdmin(UserLoginDto dto);
        Task RegisterAdmin(AdminRegisterDto dto);
    }
}
