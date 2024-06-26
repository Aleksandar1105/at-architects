﻿namespace AtArchitects.Services.Imlementations
{
    using AtArchitects.Domain.Enums;
    using AtArchitects.Domain.Models;
    using AtArchitects.DTOs.UserDTOs;
    using AtArchitects.Mappers;
    using AtArchitects.Services.Interfaces;
    using AtArchitects.Shared.Exceptions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<UserLoginResponseDto> LoginCustomer(UserLoginDto dto)
        {
            User customer = await _userManager.FindByNameAsync(dto.Username);

            if (customer == null || !(await _userManager.IsInRoleAsync(customer, Roles.Customer.ToString())))
            {
                throw new BadCredentialsException();
            }
            if (!await _userManager.CheckPasswordAsync(customer, dto.Password))
            {
                throw new BadCredentialsException();
            }

            string token = GenerateToken(customer);
            return customer.ToUserLoginResponse(token);

        }
        public async Task<UserLoginResponseDto> RegisterCustomer(UserRegisterDto dto)
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

            var result = await _userManager.CreateAsync(customer, dto.Password);

            if (!result.Succeeded)
            {
                throw new UserRegisterException("Failed to create user.");
            }

            await _userManager.AddToRoleAsync(customer, Roles.Customer.ToString());

            string token = GenerateToken(customer);
            return customer.ToUserLoginResponse(token);
        }

        public async Task<UserLoginResponseDto> LoginAdmin(UserLoginDto dto)
        {
            var admin = await _userManager.FindByNameAsync(dto.Username);


            if (admin == null || !(await _userManager.IsInRoleAsync(admin, Roles.Admin.ToString())))
            {
                throw new BadCredentialsException();
            }

            if (!await _userManager.CheckPasswordAsync(admin, dto.Password))
            {
                throw new BadCredentialsException();
            }

            string token = GenerateToken(admin);
            return admin.ToUserLoginResponse(token);
        }

        public async Task<UserLoginResponseDto> RegisterAdmin(UserRegisterDto dto)
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

            User admin = new User
            {
                UserName = dto.Username,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Role = Roles.Admin
            };

            var result = await _userManager.CreateAsync(admin, dto.Password);

            if (!result.Succeeded)
            {
                throw new UserRegisterException("Failed to create user.");
            }

            await _userManager.AddToRoleAsync(admin, Roles.Admin.ToString());

            string token = GenerateToken(admin);
            return admin.ToUserLoginResponse(token);
        }

        //    private async Task<string> GenerateToken(User user)
        //    {
        //        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        //        var roles = await _userManager.GetRolesAsync(user);
        //        var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToArray();

        //        var claims = new List<Claim>
        //{
        //            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //            new Claim("id", user.Id),
        //            new Claim(ClaimTypes.NameIdentifier, user.UserName),
        //            new Claim(ClaimTypes.Email, user.Email)
        //};
        //        claims.AddRange(roleClaims);

        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(claims),
        //            Expires = DateTime.Now.AddMinutes(int.Parse(_configuration["Jwt:Expire"])),
        //            SigningCredentials = credentials
        //        };

        //        var token = tokenHandler.CreateToken(tokenDescriptor);
        //        return tokenHandler.WriteToken(token);
        //    }


        private string GenerateToken(User user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);


            Claim[] claims =
            [
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            ];
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
