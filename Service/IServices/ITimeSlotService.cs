using Domain.Models;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Repository.Repositories;
using Service.Responses;

namespace Service.IServices
{
    public interface ITimeSlotService
    {
        IEnumerable<Slots> CalculateDaySlots (scheduleDto scheduleDto);
        Task AddTimeSlots(scheduleDto scheduleDto);    //to add time slots to table

        Task<IEnumerable<TimeSlot>> GetAllTimeSlotsService(int doctor_id); //get time slots for doctor by id
        Task<IEnumerable<TimeSlot>> GetAllTimeSlotsService();

        Task<Appointment> MakeAppointment(AppointmentDto appointment, TimeSlotDto timeslotdto);

       Task <IEnumerable<FullSlots>> GetFreeTimeSlots(int doctor_id);

       IEnumerable<BusySlotResponce> GetBusySlots(int DoctorId,DateTime StartDate ,DateTime EndDate);
       Task<IEnumerable<WorkScheduleByDept>> GetAllTimeSlotsByDepartmentId(int DepartmentId);



    }
}
