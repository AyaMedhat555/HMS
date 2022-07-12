using Domain.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Doctor,Patient,Receptionist")]
        [HttpGet("GetBusySlots/{DoctorId}/{StartDate}/{EndDate}")]
        public async Task<IActionResult> GetTimeSlots(int DoctorId, DateTime StartDate, DateTime EndDate)
        {

            return Ok( TimeSlotService.GetBusySlots(DoctorId, StartDate, EndDate));
        }

        [Authorize(Roles = "Doctor,Patient,Receptionist")]
        [HttpGet("GetSlotsByDepartment/{DepartmentId}")]
        public async Task<IActionResult> GetTimeSlots(int DepartmentId)
        {
            return Ok(await TimeSlotService.GetAllTimeSlotsByDepartmentId(DepartmentId));
        }


        [HttpGet("GetFreeTimeSlotsByDoctorId/{DoctorId}")]
        public async Task<IActionResult> GetFreeTimeSlots(int DoctorId)
        {
            return Ok(await TimeSlotService.GetFreeTimeSlotsByDoctorId(DoctorId));
        }
    }
}
