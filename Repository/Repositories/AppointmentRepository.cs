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

        public IQueryable<Appointment> AppointmentsPerMonthByDeptId(int DeptId,int Month)
        {
            return _unitOfWork.Context.Appointments.Where(A => (A.AppointmentDate.Month == Month) && (A.Doctor.DepartmentId == DeptId)) ;
        }

        public IQueryable<Appointment> AppointmentsPerMonthByDoctorId(int DoctorId, int Month)
        {
            return _unitOfWork.Context.Appointments.Where(A => (A.AppointmentDate.Month == Month) && (A.Doctor.Id == DoctorId)).Include(A=>A.Doctor);
        }

        public Task <Appointment> CancelAppointment(int PatientId, DateTime AppointmentDate)
        {
          return  _unitOfWork.Context.Appointments.Where(A => (A.AppointmentDate == AppointmentDate) && (A.PatientId == PatientId)).SingleAsync();
            
        }

        public IQueryable<Appointment> GetAllAppointments()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Appointment> GetAllAppointmentsByDoctorId(int DoctorId)
        {
            return _unitOfWork.Context.Appointments.Where(A=>(A.DoctorId == DoctorId));
        }

        public IQueryable<Appointment> GetAppointmentsByDate(DateTime StartDate, int DoctorId)
        {
           return _unitOfWork.Context.Appointments.Where(A=>(A.AppointmentDate.Date== StartDate.Date)&&(A.DoctorId== DoctorId));
        }

        public IQueryable<Appointment> GetAppointmentsByPatientId(int PatientId)
        {
            return _unitOfWork.Context.Appointments.Where(A=>(A.PatientId== PatientId)&&(A.AppointmentDate.Date>=DateTime.Now.Date)).Include(A=>A.Doctor);
        }

        public IQueryable<Appointment> GetAppointmentsForTodayByDoctorId(DateTime Today, int DoctorId)
        {
            return _unitOfWork.Context.Appointments.Where(A => (A.AppointmentDate.Date == Today.Date) && (A.DoctorId == DoctorId)).Include(A => A.Patient); 
        }

        public IQueryable<Appointment> GetTodayAppointments(DateTime Today)
        {
            return _unitOfWork.Context.Appointments.Where(A => (A.AppointmentDate.Date == Today.Date)) ;
        }
    }
}
