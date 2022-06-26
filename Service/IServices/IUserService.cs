using Repository;
using Service.Responses;
using Domain.Models.Users;
using Service.DTO.Users;

namespace Service.IServices
{
    public interface IUserService
    {
        Task<User> AddUser(UserDto user);
        Task<User> UpdateUser(User user);
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> DeleteUser(int id);
        Task<LoginResponse> Login(LoginRequest logInUser);
        Task<User> GetUserByName(String username);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
