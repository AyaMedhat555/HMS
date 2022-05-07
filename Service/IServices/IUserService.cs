
using Domain.Models;
using Service.DTO;
using Repository;
using Service.Responses;

namespace Service.IServices
{
    public interface IUserService
    {
        Task<User> AddUser(UserDto user);
        Task<User> UpdateUser(User user);
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<IEnumerable<UserDto>> GetAllNurses();
        Task<User> GetUserById(int id);
        Task<User> DeleteUser(int id);
        Task<LoginResponse> Login(LoginRequest logInUser);
        Task<User> GetUserByName(String username);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
