using Domain.Models;
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
    }
}
