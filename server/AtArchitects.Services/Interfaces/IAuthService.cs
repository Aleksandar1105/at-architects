namespace AtArchitects.Services.Interfaces
{
    using AtArchitects.DTOs.UserDTOs;

    public interface IAuthService
    {
        Task<UserLoginResponseDto> LoginCustomer(UserLoginDto dto);
        Task<UserLoginResponseDto> RegisterCustomer(UserRegisterDto dto);
        Task<UserLoginResponseDto> LoginAdmin(UserLoginDto dto);
        Task<UserLoginResponseDto> RegisterAdmin(UserRegisterDto dto);
    }
}
