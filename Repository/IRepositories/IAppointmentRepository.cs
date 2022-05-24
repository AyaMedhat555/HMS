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
    }
}
