using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.IServices;
using Service.Responses;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private IScheduleService ScheduleService { get; }
        private ITimeSlotService TimeSlotService { get; }
        private IDoctorService DoctorService { get; }


        public AppointmentController(IScheduleService _IScheduleService, ITimeSlotService _TimeSlotService, IDoctorService _DoctorService)
        {
            ScheduleService = _IScheduleService;
            TimeSlotService = _TimeSlotService;
            DoctorService = _DoctorService;
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


        [HttpGet("GetFreeTimeSlots/{id}")]

        public async Task<IActionResult> GetFreeTimeSlots(int id)
        {
            var Freeslots =  await TimeSlotService.GetFreeTimeSlots(id);
            return Ok(Freeslots);
        }


        [HttpGet("GetAppointmentsForTodayByDoctorId/{DoctorId}/{Today}")]

        public async Task<IActionResult> GetAppointmentsForTodayByDoctorId(int DoctorId,DateTime Today)
        {
            return Ok(await DoctorService.GetAppointmentsForTodayByDoctorId(Today, DoctorId));

        }


        [HttpPut("ExaminedAppointment/{AppointmentId}/{Examined}")]
        public async Task<IActionResult> ExaminedAppointment(int AppointmentId, bool Examined)
        {
            ExaminedAppointment ExaminedAppointment = new ExaminedAppointment()
            {
                AppointmentId = AppointmentId,
                 Examined = Examined
            };

            await DoctorService.ExaminedApoointment(ExaminedAppointment);

            return Ok($"Appointment With Id {ExaminedAppointment.AppointmentId} has been examined");
        }
    } 
}
