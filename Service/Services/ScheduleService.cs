using Domain.Models;
using Repository.IRepositories;
using Service.DTO;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ScheduleService : IScheduleService
    {


        private IScheduleRepository scheduleRepository { get; }



        public ScheduleService(IScheduleRepository _IscheduleRepository)
        {
            scheduleRepository = _IscheduleRepository;

        }

        public async Task<Schedule> AddSchedule(scheduleDto scheduledto)
        {
            var schedule = new Schedule
            {
                DoctorId = scheduledto.DoctorId,
                StartTime = TimeSpan.Parse(scheduledto.StartTime),
                EndTime =TimeSpan.Parse( scheduledto.EndTime),
                DayOfWork = (scheduledto.DayOfWork),
                TimePerPatient = TimeSpan.Parse(scheduledto.TimePerPatient)
            };
            return await scheduleRepository.Add(schedule);
        }

        public async Task<Schedule> UpdateSchedule(Schedule schedule)
        {
            return await scheduleRepository.Update(schedule);
        }
    }
}
