using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.IServices;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private IScheduleService ScheduleService { get; }
        private ITimeSlotService TimeSlotService { get; }

       
        public AppointmentController(IScheduleService _IScheduleService, ITimeSlotService _TimeSlotService)
        {
            ScheduleService = _IScheduleService;
            TimeSlotService = _TimeSlotService;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetslotsbyDoctorId(int id)
        {
            var allslots = await TimeSlotService.GetAllTimeSlotsService(id);
            return Ok(allslots);
        }

        [HttpPost]
        public async Task<IActionResult> MakeAppointment([FromBody] APPSLOTDto APPSLOTDto)
        {
            AppointmentDto AppointmentDto = APPSLOTDto.AppointmentDto;
            TimeSlotDto timeslotdto = APPSLOTDto.timeslotdto;

            return Ok(await TimeSlotService.MakeAppointment(AppointmentDto, timeslotdto));
        }
    } 
}
