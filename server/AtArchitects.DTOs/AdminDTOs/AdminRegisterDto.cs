namespace AtArchitects.DTOs.AdminDTOs
{
    public class AdminRegisterDto
    {
        public string AdminId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
