using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.IServices;
using Service.Services;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private IScheduleService ScheduleService { get; }
        private ITimeSlotService TimeSlotService { get; }

        public ScheduleController(IScheduleService _IScheduleService, ITimeSlotService _TimeSlotService  )
        {
            ScheduleService = _IScheduleService;
            TimeSlotService = _TimeSlotService;

        }

        [HttpPost]
        public async Task<IActionResult> AddSchedule([FromBody] scheduleDto[] schedules)
        {
            for (int i = 0; i < schedules.Length; i++)
            {
                await ScheduleService.AddSchedule(schedules[i]);
                
                await TimeSlotService.AddTimeSlots(schedules[i]);

            }
            return Ok(schedules);
        }
    }
}
