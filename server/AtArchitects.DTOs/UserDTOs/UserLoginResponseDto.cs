namespace AtArchitects.DTOs.UserDTOs
{
    using AtArchitects.Domain.Enums;

    public class UserLoginResponseDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; }
        public string Token { get; set; }
    }
}
