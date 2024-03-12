namespace AtArchitects.Services.Imlementations
{
    using AtArchitects.DataAccess.Repositories.Interfaces;
    using AtArchitects.Domain.Enums;
    using AtArchitects.Domain.Models;
    using AtArchitects.DTOs.AdminDTOs;
    using AtArchitects.DTOs.CustomerDTOs;
    using AtArchitects.DTOs.UserDTOs;
    using AtArchitects.Services.Interfaces;
    using AtArchitects.Shared.Exceptions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using AtArchitects.Mappers;

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

        public async Task<CustomerLoginResponseDto> LoginCustomer(UserLoginDto dto)
        {
            User customer = await _userManager.FindByNameAsync(dto.Username);

            if (customer == null || customer.Role != Roles.Customer)
            {
                throw new BadCredentialsException();
            }
            if (!await _userManager.CheckPasswordAsync(customer, dto.Password))
            {
                throw new BadCredentialsException();
            }

            string token = GenerateToken(customer);
            return customer.ToCustomerLoginResponse(token);

        }
        public async Task RegisterCustomer(CustomerRegisterDto dto)
        {
            if (string.IsNullOrEmpty(dto.Username) || string.IsNullOrEmpty(dto.Password) || string.IsNullOrEmpty(dto.Email))
            {
                throw new UserRegisterException("Username, password and email are required fields.");
            }

            if (dto.Password != dto.ConfirmPassword)
            {
                throw new UserRegisterException("Password and confirm password do not match.");
            }

            if (await _userManager.FindByNameAsync(dto.Username) != null)
            {
                throw new UserRegisterException("Username already exists.");
            }

            User customer = new User
            {
                UserName = dto.Username,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Role = Roles.Customer
            };

            await _userManager.CreateAsync(customer, dto.Password);
        }

        public async Task<CustomerLoginResponseDto> LoginAdmin(UserLoginDto dto)
        {
            User admin = await _userManager.FindByNameAsync(dto.Username);

            if (admin == null || admin.Role != Roles.Admin)
            {
                throw new BadCredentialsException();
            }

            if (!await _userManager.CheckPasswordAsync(admin, dto.Password))
            {
                throw new BadCredentialsException();
            }

            string token = GenerateToken(admin);
            return admin.ToCustomerLoginResponse(token);
        }

        public async Task RegisterAdmin(AdminRegisterDto dto)
        {
            if(string.IsNullOrEmpty(dto.Username) || string.IsNullOrEmpty(dto.Password) || string.IsNullOrEmpty(dto.Email))
            {
                throw new UserRegisterException("Username, password and email are required fields.");
            }

            if (dto.Password != dto.ConfirmPassword)
            {
                throw new UserRegisterException("Password and confirm password do not match.");
            }

            if (await _userManager.FindByNameAsync(dto.Username) != null)
            {
                throw new UserRegisterException("Username already exists.");
            }

            User admin = new User
            {
                UserName = dto.Username,
                Email = dto.Email,
                Name = dto.Name,
                Role = Roles.Admin
            };

            await _userManager.CreateAsync(admin, dto.Password);
        }


        private string GenerateToken(User user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            Claim[] claims = new Claim[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(int.Parse(_configuration["Jwt:Expire"])),
                SigningCredentials = credentials,
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
