using Contracts;
using Dtos;
using ItsMySocialDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace service
{
    public class AuthService
    {
        private readonly IUserRepository _userrepository;
        private readonly IConfiguration _configuration;
        public AuthService(IUserRepository userRepository, IConfiguration configuration )
        {
            _userrepository = userRepository;
            _configuration = configuration;
        }
        //password Hashing
        private string HashPasword(string password)
        {
            using(var hmac= new HMACSHA512())
            {
                var passworBytes = Encoding.UTF8.GetBytes(password);
                var hashbytes= hmac.ComputeHash(passworBytes);
                return Convert.ToBase64String(hashbytes);
            }
        }
        //REGISTER
        public async Task<User> RegisterASync(RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.Name,
                PasswordHash = HashPasword(registerDto.Password),
                Email = registerDto.Email
            };
            await _userrepository.AddUserAsync(user);
            return user;
        }
        //Login
        private bool verifyPassword(string storedHash, string password) 
        {
            var srtoreHashBytes= Convert.FromBase64String(storedHash);
            using(var hmac= new HMACSHA512(srtoreHashBytes))
            {
                 var passwodBytes=Encoding.UTF8.GetBytes(password);
                var computedHash = hmac.ComputeHash(passwodBytes);
                return Convert.ToBase64String(computedHash)==storedHash;

            }
        }
        //generate token 
        private string GenerateJwtToken(User user)
        {

        }
        public async Task<TokenDto> LoginAsync(LoginDto loginDto) 
        {

        }


    }
}
