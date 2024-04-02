namespace AtArchitects.Services.Interfaces
{
    using AtArchitects.DTOs.UserDTOs;

    public interface IAuthService
    {
        Task<UserLoginResponseDto> LoginCustomer(UserLoginDto dto);
        Task RegisterCustomer(UserRegisterDto dto);
        Task<UserLoginResponseDto> LoginAdmin(UserLoginDto dto);
        Task RegisterAdmin(UserRegisterDto dto);
    }
}
