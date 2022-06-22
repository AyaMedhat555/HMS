using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Repository.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class NurseRepository:GenericRepository<Nurse>, INurseRepository
    {
        private IUnitOfWork _unitOfWork;
        public NurseRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<Nurse> FindByName(String username)
        {
            var user = await _unitOfWork.Context.Nurses.SingleOrDefaultAsync(x => x.UserName == username);
            if (user == null || user.UserName != username)
            {
                return null;
            }
            return user;
        }

        public IQueryable<Nurse> GetNursesBySpecialization(string specialization)
        {
            return _unitOfWork.Context.Nurses.Where(N => N.NurseSpecialization == specialization);
        }

        public IQueryable<Nurse> GetNursesByState(bool state)
        {
            return _unitOfWork.Context.Nurses.Where(N => N.IsActive == state);
        }

        public async Task<Nurse> GetNurseById(int id)
        {
            return await _unitOfWork.Context.Nurses.Include(N => N.Department).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}

