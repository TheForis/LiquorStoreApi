using DataAccess.Interface;
using DomainModels;
using DTOs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Helper;
using Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IOptions<AppSettings> _options;
        public UserService(IUserRepository repo, IOptions<AppSettings> options)
        {
            _repository = repo;
            _options = options;
        }

        public UserDto LogInUser(string email, string password)
        {
            var resultFromBase = _repository.LogIn(email, HashPassword(password));
            if (resultFromBase != null)
            {
                return UserMapper.ToUserDto(resultFromBase,GenerateToken(resultFromBase));
            }
            else
            {
                throw new SafeArrayTypeMismatchException("Email or password do not match. Please try again!");
            }
        }
        public void RegisterUser(CreateUserDto userDto) 
        {

        }
        public string GenerateToken(User user) 
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] secretKeyBytes = Encoding.ASCII.GetBytes(_options.Value.SecretKey);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),
                                            SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                        new Claim("userEmail", user.Email)
                    })
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenResult = tokenHandler.WriteToken(token);
            return tokenResult;
        }
        public static string HashPassword(string password) 
        {
            MD5 md5CryptoServiceProvider = MD5.Create();
            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = md5CryptoServiceProvider.ComputeHash(passwordBytes);
            string hashedPassword = Encoding.ASCII.GetString(hashBytes);

            return hashedPassword;
        }
    }
}
