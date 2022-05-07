using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotcontroller : ControllerBase
    {
        private ITimeSlotService TimeSlotService { get; }

        public TimeSlotcontroller(ITimeSlotService _TimeSlotService)
        {
            TimeSlotService = _TimeSlotService;

        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetTimeSlots(int id)
        //{


        //    return Ok(await TimeSlotService.GetDoctorSlotsById(id));
        //}
    }
}
