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
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private IUnitOfWork _unitOfWork;
        public PatientRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<Patient> FindByName(String username)
        {
            var user = await _unitOfWork.Context.Patients.SingleOrDefaultAsync(x => x.UserName == username);
            if (user == null || user.UserName != username)
            {
                return null;
            }
            return user;
        }
    }
}
