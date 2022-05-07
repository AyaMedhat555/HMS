using Domain.Models;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IScheduleService
    {
        Task<Schedule> AddSchedule(scheduleDto schedule);
        Task<Schedule> UpdateSchedule(Schedule schedule);
    }
}
