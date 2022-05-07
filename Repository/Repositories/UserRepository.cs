using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Repository.UnitOfWorks;


namespace Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private IUnitOfWork _unitOfWork;
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        public async Task<User> Login(LoginRequest request)
        {
            var user = await _unitOfWork.Context.Users.SingleOrDefaultAsync(x => x.UserName == request.UserName);
            if (user == null || user.UserName != request.UserName)
            {
                return null;
            }
            return user;
        }

        public async Task<User> FindByName(String username)
        {
            var user = await _unitOfWork.Context.Users.SingleOrDefaultAsync(x => x.UserName == username);
            if (user == null || user.UserName != username)
            {
                return null;
            }
            return user;
        }

        public IQueryable<Nurse> GetAllNurses()
        {
            return _unitOfWork.Context.Set<Nurse>();
        }
    }
}
