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
        private IDoctorService DoctorService { get; }

        public ScheduleController(IScheduleService _IScheduleService, ITimeSlotService _TimeSlotService, IDoctorService _DoctorService)
        {
            ScheduleService = _IScheduleService;
            TimeSlotService = _TimeSlotService;
            DoctorService = _DoctorService;

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


        [HttpPut("UpdateSchedule")]
        public async Task<IActionResult> Update(scheduleDto ScheduleDto)
        {
            return Ok(await ScheduleService.UpdateSchedule(ScheduleDto));
        }


        [HttpDelete("DeleteSchedule/{ScheduleId}")]
        public async Task<IActionResult> Delete( [FromRoute]int ScheduleId)
        {
            await ScheduleService.DeleteSchedule(ScheduleId);
            return Ok($"Schedule With Id {ScheduleId} deleted Successfuly");
        }


        [HttpGet(" GetSchedulesByDoctor_Id/{Doctor_ID}")]
        public async Task<IActionResult> GetSchedulesByDoctor_Id([FromRoute] int Doctor_ID)
        {
            return Ok(await ScheduleService.GetSchedulesByDoctor_Id(Doctor_ID));
        }


        [HttpGet("GetSchedulesByDepartment_Id/{Department_ID}")]
        public async Task<IActionResult> GetSchedulesByDepartment_Id([FromRoute] int Department_ID)
        {
            return Ok(await ScheduleService.GetSchedulesByDepartment_Id(Department_ID));
        }

    }
}
