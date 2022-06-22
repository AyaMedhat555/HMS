using Domain.Models;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface ITimeSlotsRepository : IGenericRepository<TimeSlot>
    {
        

         IQueryable<TimeSlot> GetAllTimeSlots(int doctor_id);

        //IQueryable<FullSlots> GetFreeTimeSlots(int doctor_id);
        IQueryable<Appointment> GetReservedAppointments(int doctor_id);

        IQueryable<TimeSlot> GetFreeSlots(int doctor_id,TimeSpan ReservedTime);
        IQueryable<TimeSlot> GetFreeSlotsWithDay(DayOfWeek DayOfWeek, int doctor_id, TimeSpan ReservedTime);
        IQueryable<TimeSlot> GetSlotsByDayOfWork(DayOfWeek DayOfWeek, int doctor_id);

    }
}
