using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IAppointmentRepository :IGenericRepository<Appointment>
    {
        IQueryable<Appointment> GetAppointmentsByDate(DateTime StartDate, int DoctorId);
        IQueryable<Appointment> GetAppointmentsForTodayByDoctorId(DateTime Today, int DoctorId);
        IQueryable<Appointment> GetAppointmentsByPatientId( int PatientId);
        Task <Appointment> CancelAppointment(int PatientId ,DateTime AppointmentDate);
        IQueryable<Appointment> GetAllAppointmentsByDoctorId(int DoctorId);
        IQueryable<Appointment> GetTodayAppointments(DateTime Today);
        IQueryable<Appointment> GetAllAppointments();
        IQueryable<Appointment> AppointmentsPerMonthByDeptId(int DeptId,int Month);
        IQueryable<Appointment> AppointmentsPerMonthByDoctorId(int DoctorId, int Month);

    }
}
