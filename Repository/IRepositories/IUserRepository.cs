using Domain.Models.Users;

namespace Repository.IRepositories
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User> Login(LoginRequest request);
        Task<User> FindByName(string username);

        IQueryable<User> GetAllUsers();
      //  IQueryable<Nurse> GetAllNurses();

    }
}
