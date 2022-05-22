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
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private IUnitOfWork _unitOfWork;
        public DepartmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Department> GetEmpsById(int id)
        {
            return await _unitOfWork.Context.Department.Include(D => D.Doctors).Include(D => D.Nurses).SingleOrDefaultAsync(D => D.Id == id);
        }

        public async Task<Department> GetEmpsByName(string name)
        {
            return await _unitOfWork.Context.Department.Include(D => D.Doctors).Include(D => D.Nurses).SingleOrDefaultAsync(D => D.Department_Name == name);
        }

        public async Task<Department> GetPatientsById(int id)
        {
            return await _unitOfWork.Context.Department.Include(D => D.Patients).SingleOrDefaultAsync(D => D.Id == id);
        }

        public async Task<Department> GetPatientsByName(string name)
        {
            return await _unitOfWork.Context.Department.Include(D => D.Patients).SingleOrDefaultAsync(D => D.Department_Name == name);
        }
    }
}
