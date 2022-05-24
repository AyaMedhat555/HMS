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
    public class ScheduleRepository: GenericRepository<Schedule>, IScheduleRepository
    {
        private IUnitOfWork _unitOfWork;
        public ScheduleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IQueryable<Doctor> GetDoctorsByDepartment_Id(int Department_ID)
        {
            return _unitOfWork.Context.Doctors.Where(D => D.DepartmentId == Department_ID);
        }

        public IQueryable<Schedule> GetScheduleByDoctor_Id(int Doctor_Id)
        {
            return _unitOfWork.Context.Schedules.Where(S => S.DoctorId== Doctor_Id);
        }

        public IQueryable<Schedule> GetSchedulesByDoctorId(int Department_ID)
        {
            return _unitOfWork.Context.Schedules.Where(S => S.Doctor.DepartmentId == Department_ID).Include(S => S.Doctor);
        }
    }
}
