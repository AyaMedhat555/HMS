using Domain.Models.Users;
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
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        private IUnitOfWork _unitOfWork;
        public DoctorRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<Doctor> FindByName(String username)
        {
            var user = await _unitOfWork.Context.Doctors.Include(D => D.Department).SingleOrDefaultAsync(x => x.UserName == username);
            if (user == null || user.UserName != username)
            {
                return null;
            }
            return user;
        }

        public IQueryable<Doctor> GetDoctorsBySpecialization(string specialization)
        {
            return _unitOfWork.Context.Doctors.Where(D => D.DocSpecialization == specialization).Include(D => D.Department);
        }

        public IQueryable<Doctor> GetDoctorsByState(bool state)
        {
            return _unitOfWork.Context.Doctors.Where(D => D.IsActive == state).Include(D => D.Department);
        }

        public IQueryable<Doctor> GetDoctorsByDepartment_Id(int Department_ID)
        {
            return _unitOfWork.Context.Doctors.Where(D => D.DepartmentId == Department_ID).Include(D => D.Department);
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _unitOfWork.Context.Doctors.Include(D => D.Department).SingleOrDefaultAsync(x => x.Id == id);
        }
        public IQueryable<Doctor> GetAllDoctors()
        {
            return _unitOfWork.Context.Doctors.Include(D => D.Department);
        }

        public IQueryable<Doctor> GetClinicalDoctorsByDepartment_Id(int Department_ID)
        {
            return _unitOfWork.Context.Doctors.Where(D=>D.clinicalDoctor==true);
        }
    }
}
