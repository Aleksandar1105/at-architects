namespace AtArchitects.Mappers
{
    using AtArchitects.Domain.Models;
    using AtArchitects.DTOs.UserDTOs;

    public static class UserMappers
    {
        public static UserLoginResponseDto ToUserLoginResponse(this User user, string token)
        {
            return new UserLoginResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.UserName,
                Role = user.Role,
                Token = token
            };
        }
    }
}
