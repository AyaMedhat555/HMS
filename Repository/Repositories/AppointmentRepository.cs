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
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private IUnitOfWork _unitOfWork;
        public AppointmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IQueryable<Appointment> GetAppointmentsByDate(DateTime StartDate, int DoctorId)
        {
           return _unitOfWork.Context.Appointments.Where(A=>(A.AppointmentDate.Date== StartDate.Date)&&(A.DoctorId== DoctorId));
        }

        public IQueryable<Appointment> GetAppointmentsForTodayByDoctorId(DateTime Today, int DoctorId)
        {
            return _unitOfWork.Context.Appointments.Where(A => (A.AppointmentDate.Date == Today.Date) && (A.DoctorId == DoctorId)).Include(A => A.Patient); 
        }
    }
}
