using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.IRepositories;
using Service.IServices;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Repository;
using Service.Helpers;
using Service.Responses;
using Domain.Models.Users;
using Service.DTO.Users;

namespace Service.Services
{
    public class UserService :IUserService
    {
        private readonly IConfiguration _configuration;
        private IUserRepository _userRepository { get; }
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<User> AddUser(UserDto user)
        {
            Console.WriteLine(user);
            var newUser = UserFactory.CreateUser(user);
            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;
            newUser.PhoneNumber = user.PhoneNumber;
            newUser.UserName = user.UserName;
            newUser.BloodType = user.BloodType == null ? "" : user.BloodType;
            newUser.Age = user.Age;
            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;
            newUser.Address = user.Address;
            newUser.NationalId = user.NationalId;
            newUser.Gender = user.Gender;
            newUser.Image = user.Image;
            newUser.Mail = user.Mail;
            return await _userRepository.Add(newUser);
        }

        public async Task<User> DeleteUser(int id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            return await _userRepository.GetAll().Select(u => new UserDto
            {   
                FirstName = u.FirstName,
                LastName = u.LastName,
                Mail = u.Mail,
                PhoneNumber = u.PhoneNumber,
            }).ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<User> UpdateUser(User user)
        {
            return await _userRepository.Update(user);
        }

        public async Task<LoginResponse> Login(LoginRequest logInUser)
        {
            var user = await _userRepository.Login(logInUser);
            LoginResponse loginResponse;
            if (user == null)
            {
                loginResponse = new LoginResponse() { Role = null, status= "User not found.", Token= null, UserName= null };
                return loginResponse;
            }
            if (!VerifyPasswordHash(logInUser.Password, user.PasswordHash, user.PasswordSalt))
            {
                loginResponse = new LoginResponse() { Role = user.Role, status= "Wrong password.", Token= null, UserName= user.UserName };
                return loginResponse;
            }
            string token = CreateToken(user);
            loginResponse = new LoginResponse()
            {
                Role = user.Role,
                status= "successful",
                Token= token,
                UserName= user.UserName
            };
            return loginResponse;
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())               
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public async Task<User> GetUserByName(string username)
        {
            return await _userRepository.FindByName(username);
        }

    }
}
