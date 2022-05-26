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
        ////IQueryable<List<Slots>> CalculateDaySlots(DayOfWeek Desired_Day,TimeSpan Start,TimeSpan End,TimeSpan Patient_Time );

        //int CalculateOffset(DayOfWeek current, DayOfWeek desired);

        //DateTime performCalculateOffset(DayOfWeek desired);

        ////IEnumerable<TimeSlot> GetAllDoctorTimeSlotsById(int doctorid);

         IQueryable<TimeSlot> GetAllTimeSlots(int doctor_id);

        //IQueryable<FullSlots> GetFreeTimeSlots(int doctor_id);
        IQueryable<Appointment> GetReservedAppointments(int doctor_id);

        IQueryable<TimeSlot> GetFreeSlots(int doctor_id,TimeSpan ReservedTime);
        IQueryable<TimeSlot> GetSlotsByDayOfWork(DayOfWeek DayOfWeek, int doctor_id);

    }
}
