using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.IServices;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitalSignsController : ControllerBase
    {
        private IVitalSignesService VitalSignsService { get; }

        public VitalSignsController(IVitalSignesService _IVitalSignesService)
        {
            VitalSignsService = _IVitalSignesService;
           
        }


        [HttpPost("AddVitalSignes")]
        public async Task<IActionResult> AddVitalSignes([FromBody] VitalSigneDto VitalSignsDto)
        {

            return Ok(await VitalSignsService.AddVitalSignes(VitalSignsDto));
        }


        [HttpGet("GetVitalSignesByRangeOfDateTime/{PatientId}/{StartDate}/{EndDate}")]
        public async Task<IActionResult> GetVitalSignesByRangeOfDateTime(int PatientId, DateTime StartDate, DateTime EndDate)
        {
            return Ok(await VitalSignsService.GetVitalSignesByRangeOfDate(PatientId, StartDate, EndDate));
        }


        [HttpGet("GetVitalSignesByRangeOfDateOnly/{PatientId}/{StartDate}/{EndDate}")]
        public async Task<IActionResult> GetVitalSignesByRangeOfDateOnly(int PatientId, DateTime StartDate, DateTime EndDate)
        {
            return Ok(await VitalSignsService.GetVitalSignesByRangeOfDateOnly(PatientId, StartDate, EndDate));
        }

        [HttpGet("GetVitalSignesBySpecificDate/{PatientId}/{SpecificDate}")]
        public async Task<IActionResult> GetVitalSignesBySpecificDate(int PatientId, DateTime Date)
        {
            return Ok(await VitalSignsService.GetVitalSignesBySpecificDate(PatientId,Date));
        }

    }
}
